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



public class Agent : MonoBehaviour, Character
{
    // Human characteristics
    public float health = 100.0f;
    public float strength = 10.0f;
    public float speed = 2.0f;
    private float rotationspeed = 5.0f;
    public float gravity = 9.81F;
    public float weapon_strength;
    private GameObject temple;

    // Components
    public AudioClip sacrificeClip;
    private Rigidbody rb;
    public Animation anim;

    // movements
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

    //Killer
    private GameObject closestEnemy;
    private int maxCell;
    private float dis2Enemy =0;

    private ResourceCounter resources;

    private float last_search = 0;
    //Time between searching the scene for a new target
    public float time_between_searches = 5;

    public bool active = true;
    public CharacterController controller;

    void Start()
    {
        nextNode = new Vector3(0.0f, -50.0f, 0.0f);
        waypoints = new List<int>();

        priority = UnityEngine.Random.Range(0.0f, 20.0f);

        anim = GetComponent<Animation>();
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        temple = GameObject.FindGameObjectWithTag("Temple");
        pathFinder = (PathFinding)GameObject.FindGameObjectWithTag("PathFinder").GetComponent(typeof(PathFinding));
        maxCell = 5000;
        closestEnemy = null;
        fighterType = (int)Fighter.Killer;
        resources = GameObject.FindGameObjectWithTag("Tablet").GetComponent<ResourceCounter>();
        resources.addPop();
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
                sacrifice();
            }
            else if (falling)
            {
                if (transform.position.y < 1.0f)
                {
                    rb.isKinematic = true;
                    rb.useGravity = false;
                    falling = false;
                }
            }
            else if (resources.baddies > 0)
            {
                killerNav();
            }
            else
            {
                moveToNextTarget(false);
            }


            //else if (fightMode && !stopMoving)
            //    fightNav();
            //else if (!stopMoving)
            //    wanderNav();
        }
    }


    //we should only use this method for moving -- once per frame
    void walkTo(Vector3 target)
    {
        Vector3 offset = target - transform.position;
        if (offset.magnitude > 0.1f)
        {
            offset = offset.normalized * speed;
            controller.Move(offset * Time.deltaTime);
            //don't spin in circles
            if (offset.magnitude > 2)
            {
                offset.y = transform.position.y;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(offset), Time.deltaTime * rotationspeed);
            }
            anim.Play("walk");
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
                    resources.addFaith(100);
                    AudioSource source = GetComponent<AudioSource>();
                    source.PlayOneShot(sacrificeClip, 0.5f);
                    anim.Play("diehard");
                    resources.removePop();
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
        resources.removePop();
        GameObject.Destroy(gameObject);
    }




    void astar(int srcCell, int targetCell)
    {
        waypoints = new List<int>(pathFinder.Astar(srcCell, targetCell));
        threadRunning = false;
    }

    //what does this do?? 
    //okay so on spawn we set the next node to -50 presumably to indicate we haven't found one yet
    private void moveToNextTarget(bool fighting)
    {

        // for this to work 2*tolerance >= speed/framerate  so tolerance is 0.1f therefore speed/frame < 0.2f
        if (nextNode.y == -50f) getNextNode();
        else
        {
            if (pathFinder.checkCell(targetCell) == "empty")
            {
                Vector3 offset = nextNode - transform.position;
                //move character towards next target
                if (offset.magnitude > 0.5f)
                {
                    walkTo(nextNode);
                }
                else if (fighting)
                    getNextNodeFighter();
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


    //private void fightNav()
    //{
    //   if (fighterType == (int)Fighter.Killer)
    //    {
    //        killerNav();
    //    }
    //}

    private void moveStraightToTarget(GameObject target)
    {
        walkTo(target.transform.position);
    }

    private void killerNav()
    {


        if (closestEnemy != null)
        {
            if (Vector3.Distance(transform.position, closestEnemy.transform.position) < 3.0f)
            {
                if (!attack(closestEnemy)) closestEnemy = null;
            }
            else
            {
                moveStraightToTarget(closestEnemy);
            }
            //moveToNextTarget(true);
        }
        else
        {
           closestEnemy = findClosestEnemy();
        }
    }

    // NEED TO FIND ANOTHER WAY TO MOVE 
    private void getNextNodeFighter() {

        if (waypoints.Count > 0)
        {
            if (closestEnemy != null)
            {
                // check if distacne between you and target is growing
                if (dis2Enemy - 0.2f > Vector3.Distance(transform.position, closestEnemy.transform.position))
                {
                    dis2Enemy = Vector3.Distance(transform.position, closestEnemy.transform.position);
                    if (!threadRunning)
                    {
                        int srcCell = coord2cellID(transform.position);
                        targetCell = coord2cellID(closestEnemy.transform.position);
                        threadRunning = true;
                        t1 = new Thread(() => astar(srcCell, targetCell));
                        t1.Start();
                    }
                }
                else
                {
                    Debug.Log("Moving towards enemy");
                    // else keep on found path
                    dis2Enemy = Vector3.Distance(transform.position, closestEnemy.transform.position);
                    targetCell = waypoints[0];
                    waypoints.Remove(targetCell);
                    Vector3 p = pathFinder.getCellPosition(targetCell);
                    if (transform.position.y >= 0 && transform.position.y < 10)
                    {
                        p.y = transform.position.y;
                    }
                    else
                    {
                        p.y = 0;
                    }
                    nextNode = p;
                    startTime = Time.time;
                    startMarker = transform.position;
                    endMarker = p;
                    journeyLength = Vector3.Distance(startMarker, endMarker);
                }
            }
        }
        else
        {
            if (closestEnemy != null)
            {
                dis2Enemy = Vector3.Distance(transform.position, closestEnemy.transform.position);
                if (!threadRunning)
                {
                    Debug.Log("Finding path to enemy");
                    int srcCell = coord2cellID(transform.position);
                    targetCell = coord2cellID(closestEnemy.transform.position);
                    threadRunning = true;
                    t1 = new Thread(() => astar(srcCell, targetCell));
                    t1.Start();
                }
            }
        }
        
    }

    private void getNextNode()
    {
        if (waypoints.Count > 0)
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
            if (!threadRunning)
            {
                int srcCell = coord2cellID(transform.position);
                targetCell = calculateNewTarget();
                waypoints = new List<int>();
                nextNode.y = -50f;
                threadRunning = true;
                t1 = new Thread(() => astar(srcCell, targetCell));
                t1.Start();
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
        nextNode.y = -50f;
        waypoints = new List<int>();
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
        /*
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

        }*/
    }

    public void changeMoving(Boolean move)
    {
        

    }

    public void grabbed ()
    {
        beingGrabbed = true;
        nextNode.y = -50f;
        waypoints = new List<int>();
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

    bool attack(GameObject victim)
    {
        if (victim != null)
        {
            anim.Play("attack");
            transform.rotation = Quaternion.LookRotation(victim.transform.position - transform.position);
            HealthManager victimHealth = victim.GetComponent<HealthManager>();
            if (victimHealth != null)
            {
                victimHealth.decrementHealth(strength * Time.deltaTime);
            }
            else
            {
                Debug.LogError("Trying to attack something that doesn not have health");
            }
            return true;
        }
        return false;
    }

    public void changeMode(bool val)
    {
        
    }

    public void activate()
    {
        active = true;
    }
}
