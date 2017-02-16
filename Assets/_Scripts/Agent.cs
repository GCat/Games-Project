using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
using System;
using UnityEngine.AI;


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



public class Agent : MonoBehaviour, Character, Placeable
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
    //public CharacterController controller;
    private NavMeshAgent agent;
    private HumanState currentState = HumanState.Wandering;

    private Vector3 wanderPoint = Vector3.zero;

    enum HumanState { Fighting, Wandering, Grabbed, Falling };

    void Start()
    {
        waypoints = new List<int>();

        priority = UnityEngine.Random.Range(0.0f, 20.0f);

        anim = GetComponent<Animation>();
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        temple = GameObject.FindGameObjectWithTag("Temple");
        maxCell = 5000;
        closestEnemy = null;
        fighterType = (int)Fighter.Killer;
        resources = GameObject.FindGameObjectWithTag("Tablet").GetComponent<ResourceCounter>();
        resources.addPop();
        agent = GetComponent<NavMeshAgent>();
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
                return;
            }
            if (resources.baddies > 0)
            {
                currentState = HumanState.Fighting;
            } else {
                currentState = HumanState.Wandering;
            }



            switch (currentState){
                case HumanState.Wandering:
                    wander();
                    break;

                case HumanState.Fighting:
                    attack();

                    break;

                case HumanState.Grabbed:
                    //sacrifice();
                    break;

                case HumanState.Falling:
                    if (transform.position.y < 1.0f)
                       {
                           rb.isKinematic = true;
                           rb.useGravity = false;
                           falling = false;
                           agent.enabled = true;
                           //controller.enabled = true;
                       }
                    break;

            }
        }
    }

    //we should only use this method for moving -- once per frame
    void walkTo(Vector3 target)
    {
        Vector3 offset = target - transform.position;
        if (offset.magnitude > 0.1f)
        {
            offset = offset.normalized * speed;
            agent.destination = target;
            //controller.Move(offset * Time.deltaTime);
            //don't spin in circles
            if (offset.magnitude > 2)
            {
                offset.y = transform.position.y;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(offset), Time.deltaTime * rotationspeed);
            }
            anim.Play("walk");
        }

    }

    private void wander()
    {
        if (wanderPoint == Vector3.zero || Vector3.Distance(transform.position, wanderPoint) < 5)
        {
            Debug.Log("finding a new target to wander to");
            wanderPoint = findNewTarget();
        }
        else
        {
            walkTo(wanderPoint);
        }
    }


    //generates a new point on the board to wander to
    private Vector3 findNewTarget()
    {
        float randX = UnityEngine.Random.Range(-50, 50);
        float randZ = UnityEngine.Random.Range(-100, 100);
        NavMeshHit hit;
        if (NavMesh.SamplePosition(new Vector3(randX, 0, randZ), out hit, 20.0f, NavMesh.AllAreas))
        {
            return hit.position;
        }
        else
        {
            Debug.LogError("Could not calculate a new wander target");
            return transform.position;
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

    private void moveStraightToTarget(GameObject target)
    {
        walkTo(target.transform.position);
    }

    private void attack()
    {
        if (closestEnemy == null)
        {
            closestEnemy = findClosestEnemy();
        }

        if (Vector3.Distance(transform.position, closestEnemy.transform.position) < 3.0f)
        {
            if (!attack(closestEnemy))
            {

                closestEnemy = null;
                currentState = HumanState.Wandering;
            }
        }
        else
        {
            moveStraightToTarget(closestEnemy);
        }

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

    public void grab ()
    {
        agent.enabled = false;
        beingGrabbed = true;
        nextNode.y = -50f;
        waypoints = new List<int>();
        realeased = false;
        rb.isKinematic = true;
        rb.useGravity = false;
        GetComponent<Collider>().enabled = false;
    }

    public void release(Vector3 vel)
    {
        realeased = true;
        if (transform.position.y > 1.0f)
        {
            rb.isKinematic = false;
            falling = true;
            rb.velocity = vel;
            Debug.Log("FALLING!");
        }
        else
        {
            agent.enabled = true;
            rb.isKinematic = true;
            GetComponent<Collider>().enabled = enabled;
        }
        rb.useGravity = true;
        beingGrabbed = false;

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


    public void activate()
    {
        active = true;
    }

    public void changeMoving(bool val)
    {
        throw new NotImplementedException();
    }

    public void changeMode(bool val)
    {
        throw new NotImplementedException();
    }
}
