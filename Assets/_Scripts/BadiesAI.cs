using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class BadiesAI : MonoBehaviour {

    /* Three type of badies will exist
     * Rushers: They'll go for the temple
     * Defenders: They'll follow the rushers and attack the temple if no humans or defend towers around
     * Killers: They'll attack humans
     *
     * Starting implementation of rushers
     */

    // Badie characteristic

    public float strenght = 20.0f;
    public float health = 100.0f;
    public float speed = 2.0f;
    public float rotationSpeed = 4.0f;

    // Components
    private Rigidbody rb;
    public Animation anim;

    // Movement
    public bool moving= true;

    //Pathfinding
    private PathFinding pathFinder;
    public List<int> waypoints;
    public Vector3 nextNode;
    public int targetCell;
    private bool threadRunning = false;
    private Thread t1;


    private int maxCell;


    // Fighting
    enum Fighter {  Rusher, Defender, Killer };
    int fighterType;
    private bool attacking = false;

    // Rusher
    private GameObject temple;
    public bool templeInRange = false;
    private bool pathToTempleFound = false;


    // Killer
    private GameObject closestEnemy;
    private bool noMoreEnemies;

    void Start()
    {
     
        moving  = true;
        nextNode = new Vector3(0.0f, -50.0f, 0.0f);
        waypoints = new List<int>();
        noMoreEnemies = false;

        anim = GetComponent<Animation>();
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Extrapolate;

        pathFinder = (PathFinding)GameObject.FindGameObjectWithTag("PathFinder").GetComponent(typeof(PathFinding));
        maxCell = 5000;
        closestEnemy = null;
        /* For now always rusher*/
        fighterType = (int)Fighter.Rusher;

        if (fighterType == (int)Fighter.Rusher)
        {
            temple = GameObject.FindGameObjectWithTag("Temple");
        }
    }

    private void Update()
    {
        if (!moving)
        {
            anim.Play("idle");
        }
        else if ( fighterType == (int)Fighter.Rusher )
        {
            rusherNav();
        }

    }

    private void rusherNav()
    {
        if (templeInRange) attack(temple);
        else
        {
            if (nextNode.y == -50.0f) getnextWaypoint();
            else if (pathFinder.checkCell(targetCell) == "empty")
            {
                Vector3 offset = nextNode - transform.position;
                if (offset.magnitude > 0.2f)
                {
                    Vector3 finalVal = offset.normalized * speed;
                    rb.MovePosition(transform.position + finalVal * Time.deltaTime);
                    transform.rotation = Quaternion.Slerp(
                        transform.rotation,
                        Quaternion.LookRotation(offset),
                        Time.deltaTime * rotationSpeed);
                    anim.Play("walk");
                }
                else getnextWaypoint();
            }
            else
            {
                int layermask = 1 << 10;
                List<Collider> hitColliders = new List<Collider>(Physics.OverlapSphere(nextNode, 2.0f, layermask));
                if(hitColliders.Count > 0)
                {
                    if (hitColliders.Exists(x => x.tag == "Temple")) {
                        templeInRange = true;
                        attack(temple);
                    }
                    else attack(hitColliders[0].gameObject);
                }
            }
        }

    }

    void astar(int srcCell, int targetCell)
    {
        waypoints = new List<int>(pathFinder.AstarB(srcCell, targetCell));
        threadRunning = false;
        pathToTempleFound = true;
        moving = true;
    }

    private void getnextWaypoint()
    {
        if (fighterType == (int)Fighter.Rusher)
        {
            if (!pathToTempleFound && !threadRunning)
            {
                moving = false;
                threadRunning = true;
                int srcCell = coord2cellID(transform.position);
                targetCell = coord2cellID(temple.GetComponent<Collider>().ClosestPointOnBounds(transform.position));
                t1 = new Thread(() => astar(srcCell, targetCell));
                t1.Start();
            }
            else if (pathToTempleFound)
            {
                if( waypoints.Count > 0)
                {
                    targetCell = waypoints[0];
                    waypoints.Remove(targetCell);
                    Vector3 p = pathFinder.getCellPosition(targetCell);
                    p.y = 0.0f;
                    nextNode = p;
                }
                else
                {
                    if (Vector3.Distance(temple.GetComponent<Collider>().ClosestPointOnBounds(transform.position), transform.position) > 2.0f)
                    {
                        Debug.Log("problem in Path finding");
                    }
                    else templeInRange = true;
                }
            }
        }

    }

    void attack(GameObject victim)
    {
        if (victim != null)
        {
            anim.Play("hit");
            victim.SendMessage("decrementHealth", strenght * Time.deltaTime);
        }
    }

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

    public void decrementHealth(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            anim.Play("die");
            StartCoroutine(WaitToDestroy(0.7f));
        }
    }

    IEnumerator WaitToDestroy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GameObject.Destroy(gameObject);
    }

}