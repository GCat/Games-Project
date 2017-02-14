using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
using System;


/* AI LOGIC EXPLANATION
 *  PHASE 1
 *  -- Wander:
 *  The  AI wanders arround moving randomly 
 *  TODO: Smooth Rotation
 *  TODO: Avoidance
 *  
 * PHASE 2 
 * If at any moment temple detryed everyone dies
 * 
 * 
 * 
 * --Killers COMPLETED
 * Search for nearest enemy 
 * Go to its position
 * Attack it
 * When dead look for next enemy
 * If no humans remain either go for watch towers or go for temple 
 * 
 * --Defender
 * Go towards temple, if enemy near temple kill it
 * 
 * --Camper
 * 
 * 
 */



public class Agent : MonoBehaviour
{
    // Human characteristics
    public float health = 100.0f;
    public float strenght = 10.0f;
    private float speed = 2.0f;
    private float rotationspeed = 5.0f;
    public float gravity = 9.81F;
    public float weapon_strength;
    private GameObject temple;

    // Components
    public AudioClip sacrificeClip;
    private Rigidbody rb;
    public Animation anim;

    // movements
    private bool stopMoving;
    public float priority = 0;
    public Vector3 startMarker;
    public Vector3 endMarker;
    private float startTime;
    private float journeyLength;

    // Pathfinding
    private Thread t1;
    private bool threadRunning = false;
    List<int> waypoints;
    private PathFinding pathFinder;
    public Vector3 nextNode;
    public int targetCell;

    // God interactions
    bool beingMoved = false;
    private bool sacrificeEntered = false;
    private bool beingGrabbed = false;
    private bool realeased = false;
    private bool falling = false;


    // Fighting
    enum Fighter { Killer, Defender, Camper };
    public int fighterType;
    public bool fightMode = false;

    //Killer
    private GameObject closestEnemy;
    private bool noMoreEnemies;
    private int maxCell;
    private float dis2Enemy =0;



    public bool active = false;


    void Start()
    {
        stopMoving = false;
        nextNode = new Vector3(0.0f, -50.0f, 0.0f);
        waypoints = new List<int>();
        noMoreEnemies = false;
        fightMode = true;

        priority = UnityEngine.Random.Range(0.0f, 20.0f);

        anim = GetComponent<Animation>();
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        temple = GameObject.FindGameObjectWithTag("Temple");
        pathFinder = (PathFinding)GameObject.FindGameObjectWithTag("PathFinder").GetComponent(typeof(PathFinding));
        maxCell = 5000;
        closestEnemy = null;
        fighterType = (int)Fighter.Killer;

    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (temple == null)
            {
                anim.Play("diehard");
                StartCoroutine(WaitToDestroy(2.1f));
            }
            else if (beingGrabbed)
            {
                waypoints = new List<int>();
                nextNode.y = -50.0f;
                sacrifice();
            }
            else if (falling)
            {
                Debug.Log(rb.velocity);
                if (transform.position.y < 1.0f)
                {
                    rb.isKinematic = true;
                    rb.useGravity = false;
                    falling = false;
                }
            }
            else if (fightMode && !stopMoving)
                fightNav();
            else if (!stopMoving)
                wanderNav();
        }
    }


    void sacrifice()
    {

        if (realeased)
        {
            if (Mathf.Abs(transform.position.x) > 50f || Mathf.Abs(transform.position.z) > 100f)
            {
                if (!sacrificeEntered)
                {
                    sacrificeEntered = true;
                    rb.isKinematic = false;
                    rb.useGravity = true;
                    GameObject resourceTab = GameObject.Find("Resource_tablet");
                    resourceTab.SendMessage("addFaith", 100);
                    AudioSource source = GetComponent<AudioSource>();
                    source.PlayOneShot(sacrificeClip, 0.5f);
                    anim.Play("diehard");
                    Destroy(gameObject, 2.1f);
                }
            }
            else
            {
                realeased = false;
                beingGrabbed = false;
                rb.isKinematic = true;
                rb.useGravity = true;
                GetComponent<Collider>().enabled = enabled;
            }
        }
    }

    IEnumerator WaitToDestroy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GameObject.Destroy(gameObject);
    }




    void astar(int srcCell, int targetCell)
    {
        waypoints = new List<int>(pathFinder.Astar(srcCell, targetCell));
        threadRunning = false;
    }

    private void wanderNav()
    {
        // for this to work 2*tolerance >= speed/framerate  so tolerance is 0.1f therefore speed/frame < 0.2f
        if (nextNode.y == -50f) getNextNode();
        else
        {
            if (pathFinder.checkCell(targetCell) == "empty")
            {
                Vector3 offset = nextNode - transform.position;
                if (offset.magnitude > 0.5f)
                {
                    Vector3 finalVal = offset *100;
                    // rb.MovePosition(transform.position + finalVal * Time.deltaTime);
                    float distCovered = (Time.time - startTime) * speed;
                    float fracJourney = distCovered / journeyLength;
                    transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
                    transform.rotation = Quaternion.Slerp(
                        transform.rotation,
                        Quaternion.LookRotation(offset),
                        Time.deltaTime * rotationspeed);
                    anim.Play("walk");
                }
                else
                    getNextNode();
            }
            else
            {
                waypoints = new List<int>();
                nextNode.y = -50f;
                getNextNode();
            }
        }
    }


    private void fightNav()
    {
       if (fighterType == (int)Fighter.Killer)
        {
            killerNav();
        }
    }

    private void killerNav()
    {
        if (noMoreEnemies)
        {
            fightMode = false;
        }
        else if (closestEnemy != null)
        {
            if (Vector3.Distance(transform.position, closestEnemy.transform.position) < 2.0f)
            {
                if (!attack(closestEnemy)) closestEnemy = null;
            }
            else
            {
                wanderNav();
            }
        }
        else
        {
            closestEnemy = findClosestEnemy();
        }
    }

    private void getNextNode()
    {
        if (waypoints.Count > 0)
        {
            if (!fightMode)
            {
                targetCell = waypoints[0];
                waypoints.Remove(targetCell);
                Vector3 p = pathFinder.getCellPosition(targetCell);
                p.y = 0.0f;
                nextNode = p;
                startTime = Time.time;
                startMarker = transform.position;
                endMarker = p;
                journeyLength = Vector3.Distance(startMarker, endMarker);
            }
            else
            {
                if(closestEnemy != null)
                {
                    if (dis2Enemy - 0.2f > Vector3.Distance(transform.position, closestEnemy.transform.position))
                    {
                        int srcCell = coord2cellID(transform.position);
                        targetCell = coord2cellID(closestEnemy.transform.position);
                        dis2Enemy = Vector3.Distance(transform.position, closestEnemy.transform.position);
                        if (!threadRunning)
                        {
                            threadRunning = true;
                            t1 = new Thread(() => astar(srcCell, targetCell));
                            t1.Start();
                        }
                    }
                    else
                    {
                        targetCell = waypoints[0];
                        waypoints.Remove(targetCell);
                        Vector3 p = pathFinder.getCellPosition(targetCell);
                        p.y = 0.0f;
                        nextNode = p;
                        startTime = Time.time;
                        startMarker = transform.position;
                        endMarker = p;
                        journeyLength = Vector3.Distance(startMarker, endMarker);
                    }
                }
                
            }

        }
        else
        {   if (!fightMode)
            {
                int srcCell = coord2cellID(transform.position);
                targetCell = calculateNewTarget();
                if (!threadRunning)
                {
                    threadRunning = true;
                    t1 = new Thread(() => astar(srcCell, targetCell));
                    t1.Start();
                }
            }
            else
            {
                if (closestEnemy != null)
                {
                    int srcCell = coord2cellID(transform.position);
                    targetCell = coord2cellID(closestEnemy.transform.position);
                    dis2Enemy = Vector3.Distance(transform.position, closestEnemy.transform.position);
                    if (!threadRunning)
                    {
                        threadRunning = true;
                        t1 = new Thread(() => astar(srcCell, targetCell));
                        t1.Start();
                    }
                }
                
            }
        }
    }

    // lazy function cuz i can not be bothered to find the correct mathematical approach tonight
    private int coord2cellID(Vector3 coords)
    {
        int layerMask = 1 << 8;
        Vector3 target = new Vector3(coords.x, 0.05f, coords.z);

        Collider[] obstacles = Physics.OverlapSphere(target, 0.05f, layerMask);
        if (obstacles.Length != 0)
        {
            return obstacles[0].gameObject.GetComponent<Cell>().id;
        }
        return -1;
    }

    private GameObject findClosestEnemy()
    {
        GameObject[] badies;
        GameObject closest = null;
        badies = GameObject.FindGameObjectsWithTag("Badies");
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        if( badies.Length> 0)
        {
            foreach (GameObject badie in badies)
            {
                Vector3 diff = badie.transform.position - position;
                float current_distance = diff.sqrMagnitude;
                if (current_distance < distance)
                {
                    distance = current_distance;
                    closest = badie;
                }
            }  
        }
        else
        {
            noMoreEnemies = true;
        }
        return closest;
    }

    public void decrementHealth(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            anim.Play("diehard");
            StartCoroutine(WaitToDestroy(2.0f));
        }
    }

    int calculateNewTarget()
    {
        int target = (int)UnityEngine.Random.Range(0.0f, maxCell);
        string status = pathFinder.checkCell(target);
        while (status != "empty")
        {
            target = (int)UnityEngine.Random.Range(0.0f, maxCell);
            status = pathFinder.checkCell(target);
        }
        return target;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Human")
        {
            Debug.Log("Humans close to each other!");
            Agent nearHuman = (Agent)(other.gameObject).GetComponent(typeof(Agent));
            Vector3 mypos = new Vector3(transform.position.x, 0.0f, transform.position.y);
            Vector3 hispos = new Vector3(other.transform.position.x, 0.0f, other.transform.position.y);
            Vector3 lnn = nextNode;
            Vector3 hlnn = nearHuman.nextNode;
            float mym = (lnn.z - mypos.z) / (lnn.x - mypos.x);
            float hism = (hlnn.z - hispos.z) / (hlnn.x - mypos.x);
            if (mym == hism)
            {
                Debug.Log("Parrallel");
            }
            else
            {
                float myc = lnn.z - mym * lnn.x;
                float hisc = hlnn.z - hism * hlnn.x;
                float x = (hisc - myc) / (mym - hism);
                float z = mym * x + myc;

                if ((z > Mathf.Min(lnn.z, mypos.z)) && (z < Mathf.Max(lnn.z, mypos.z)) && (x > Mathf.Min(lnn.x, mypos.x)) && (x < Mathf.Max(lnn.x, mypos.x)))
                {
                    if ((z > Mathf.Min(hlnn.z, hispos.z)) && (z < Mathf.Max(hlnn.z, hispos.z)) && (x > Mathf.Min(hlnn.x, hispos.x)) && (x < Mathf.Max(hlnn.x, hispos.x)))
                    {
                        Debug.Log("Paths cross");
                    }
                }
                //m1x +c1 = m2x+c2
                // m1x-m2c = c2-c1
                //x(m-m2) = c2-c1
                //x = (c2-c1) / (m1-m2)
            }

        }
    }
    public void changeMoving(Boolean move)
    {
        stopMoving = move;

    }

    public void grabbed ()
    {
        beingGrabbed = true;
        realeased = false;
        rb.isKinematic = true;
        rb.useGravity = false;
        GetComponent<Collider>().enabled = false;
    }

    public void released(Vector3 vel)
    {
        realeased = true;
        if (transform.position.y > 1.0f)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
            falling = true;
            rb.velocity = vel;
            Debug.Log("FALLING!");
        }
        else
        {
            rb.isKinematic = true;
            rb.useGravity = true;
            GetComponent<Collider>().enabled = enabled;
        }
    }
    public void changeMode (bool val)
    {
        fightMode = val;
    }

    bool attack(GameObject victim)
    {
        if (victim != null)
        {
            anim.Play("attack");
            transform.rotation = Quaternion.LookRotation(victim.transform.position - transform.position);
            victim.SendMessage("decrementHealth", strenght * Time.deltaTime);
            return true;
        }
        return false;
    }
    public void activate()
    {
        active = true;
    }
}
