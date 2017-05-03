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
 * 
 * 
 */


        
public class Agent : Character
{

    public float strength = 10.0f;
    public float gravity = 9.81F;
    public bool debug = false;
    private GameObject temple;
    private bool alive = true;
    public bool humanHeld = false;
    public bool droppedOnZone = false;
    public House myHome;

    // Components
    public AudioClip sacrificeClip;
    private Rigidbody rb;
    public Animation anim;
    public AudioClip[] attackClips;

    // God interactions
    private bool sacrificeEntered = false;

    // Fighting
    enum Fighter { Killer, Defender, Camper };
    public int fighterType;

    //Killer
    private GameObject closestEnemy;
    private int maxCell;
    private float dis2Enemy = 0;
    public bool active = true;
    //public CharacterController controller;
    private HumanState currentState = HumanState.Wandering;
    private Vector3 rallyZoneCentre;
    //private RallyPoint rallypoint;

    private Vector3 wanderPoint = Vector3.zero;
    private LineRenderer lineRenderer;

    private Vector3 bL;
    private Vector3 tR;
    private float rallyZoneRadius = 10;
    
    //determines if this chap is in a fight 
    private bool combatEngaged = false;

    public enum HumanState { Fighting, Wandering, Grabbed, Falling, Defending };

    void Start()
    {
        healthBar = GetComponentInChildren<HealthBar>();
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
        createInfoText();
        infoTextOri = infoText.transform.rotation;
        lineRenderer = GetComponent<LineRenderer>();
        tR = resources.getTopRight() - new Vector3(10,0,10);
        bL = resources.getBottomLeft() + new Vector3(10, 0, 10);
        StartCoroutine(acquireTargets());
    }

    // Update is called once per frame
    void Update()
    {
        infoText.transform.rotation = infoTextOri;
        if (active)
        {
            if (temple == null)
            {
                anim.Play("diehard");
                StartCoroutine(WaitToDestroy(2.1f));
                return;
            }
            switch (currentState)
            {
                case HumanState.Wandering:
                    if (resources.getGroundBaddies() > 0)
                    {
                        currentState = HumanState.Fighting;
                        infoText.SetActive(true);
                    }
                    else
                        wander();
                    break;

                case HumanState.Fighting:
                    if (resources.getGroundBaddies() <= 0)
                    {
                        currentState = HumanState.Wandering;
                        infoText.SetActive(false);
                    }
                    else
                        attack();
                    break;

                case HumanState.Grabbed:
                    break;

                case HumanState.Falling:
                    if (!sacrificeEntered)
                    {
                        if (resources.aboveBoard(transform.position))
                        {
                            if ((transform.position.y < 0.5) && droppedOnZone)
                            {
                                agent.enabled = true;
                                rb.isKinematic = true;
                                currentState = HumanState.Defending;
                                break;
                            }
                            if (transform.position.y < 0.3)
                            {
                                rb.velocity = Vector3.zero;
                                transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
                                agent.enabled = true;
                                rb.isKinematic = true;
                                currentState = HumanState.Wandering;
                            }
                        }
                        else
                        {
                            sacrifice();
                        }
                    }
                    break;

                case HumanState.Defending:
                    if (resources.getGroundBaddies() > 0)
                    {
                        attack();
                    }
                    else
                    {
                        walkTo(rallyZoneCentre);
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
            setDestination(target);
            showPath();
            //controller.Move(offset * Time.deltaTime);
            //don't spin in circles
            if (!atDestination(target))
            {
                offset.y = transform.position.y;
                if(agent.desiredVelocity.magnitude > 0)
                {
                    Quaternion desiredLookDirection = Quaternion.LookRotation(agent.desiredVelocity.normalized, Vector3.up);
                    transform.rotation = Quaternion.Slerp(transform.rotation, desiredLookDirection, Time.deltaTime);
                }
            }
            anim.Play("walk");
        }

    }

    private void wander()
    {
        if (wanderPoint == Vector3.zero || atDestination(wanderPoint))
        {
            try
            {
                wanderPoint = findNewTarget();
            }
            catch
            {
                wanderPoint = Vector3.zero + Vector3.forward * 20;
            }
        }
        else
        {
            walkTo(wanderPoint);
        }
    }

    void FixedUpdate()
    {
        if (currentState == HumanState.Falling)
        {
            if (!sacrificeEntered)
            {
                if (resources.aboveBoard(transform.position))
                {
                    if ((transform.position.y < 0.5) && droppedOnZone)
                    {
                        agent.enabled = true;
                        rb.isKinematic = true;
                        currentState = HumanState.Defending;
                    }
                    if (transform.position.y < 0.3)
                    {
                        rb.velocity = Vector3.zero;
                        agent.enabled = true;
                        transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
                        rb.isKinematic = true;
                        currentState = HumanState.Wandering;
                    }
                }
                else
                {
                    sacrifice();
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            agent.Warp(collision.contacts[0].point);
        }

    }

    //generates a new point on the board to wander to
    private Vector3 findNewTarget() 
    {
        float randX = UnityEngine.Random.Range(bL.x, tR.x);
        float randZ = UnityEngine.Random.Range(bL.z, tR.z);
        Vector3 v = new Vector3(randX, 0, randZ);
        //attempt to get a new wander point 3 times
        //we should probably use an area mask or something but easier to rebake navmesh to remove invalid areas
        for (int i = 0; i < 1; i++) {
            NavMeshHit hit;
            if (NavMesh.SamplePosition(v, out hit, 20.0f, NavMesh.AllAreas))
            {
                NavMeshPath path = new NavMeshPath();
                agent.CalculatePath(hit.position, path);
                if (path.status != NavMeshPathStatus.PathInvalid)
                {
                    return hit.position;
                }
            }
        }
        throw new TargetNotFoundException();
    }

    private void showPath()
    {
        if (agent.hasPath && debug)
        {
            lineRenderer.SetPositions(agent.path.corners);
        }

    }

    void sacrifice()
    {
        if (!sacrificeEntered)
        {
            AudioSource source = GetComponent<AudioSource>();
            source.PlayOneShot(sacrificeClip, 0.2f);
            resources.addFaith(15);
            sacrificeEntered = true;
            anim.Play("diehard");
            StartCoroutine(WaitToDestroy(2.1f));
        }
    }

    IEnumerator WaitToDestroy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        resources.removePop();
        if (myHome) myHome.spawnedPopulation--;
        GameObject.Destroy(gameObject);
    }
    //locks this chap in combat for some period of time, so they don't change target
    //also aggros the enemy
    IEnumerator CombatLock(float time, Monster opponent)
    {
        combatEngaged = true;
        opponent.aggro(gameObject);
        yield return new WaitForSeconds(time);
        combatEngaged = false;
    }

    private void attack()
    {
        //always find closest enemy unless otherwise engaged
        if (closestEnemy == null)
        {
            currentState = HumanState.Wandering;
            anim.Play("walk");
            return;
        }
        if (atDestination(closestEnemy.transform.position))
        {
            if (!attack(closestEnemy))
            {

                closestEnemy = null;
                currentState = HumanState.Wandering;
                anim.Play("walk");
                return;
            }
        }else
        {
            anim.Play("walk");
        }

    }

    IEnumerator acquireTargets()
    {
        while (active)
        {
            if (!combatEngaged && resources.getGroundBaddies() > 0)
            {
                closestEnemy = findClosestEnemy();
                walkTo(closestEnemy.transform.position);
            }
            yield return new WaitForSeconds(1);
        }
    }



    private GameObject findClosestEnemy()
    {
        GameObject[] badies;
        GameObject closest = null;
        badies = GameObject.FindGameObjectsWithTag("Badies");
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        if (badies.Length > 0)
        {
            foreach (GameObject badie in badies)
            {

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
        }

        return closest;
    }

    public override void decrementHealth(float damage)
    {
        healthBar.decrementHealth(damage);
        if (healthBar.health <= 0 && alive == true)
        {
            alive = false;
            anim.Play("diehard");
            StartCoroutine(WaitToDestroy(2.0f));
            GameObject ghost = Instantiate(Resources.Load("Particles/Spooky_Explosion") as GameObject, transform.position, Quaternion.identity);
            Destroy(ghost, 1f);
        }
    }



    public override void grab()
    {
        agent.enabled = false;
        currentState = HumanState.Grabbed;
        rb.isKinematic = true;
        rb.useGravity = false;
        //GetComponent<Collider>().enabled = false;
        humanHeld = true;
        droppedOnZone = false;
    }

    public override void release(Vector3 vel)
    {
        currentState = HumanState.Falling;
        GetComponent<Collider>().enabled = true;
        rb.useGravity = true;
        rb.isKinematic = false;
        rb.velocity = vel;
        humanHeld = false;
        removeOutline();

    }

    bool attack(GameObject victim)
    {
        if (victim != null)
        {
            transform.rotation = Quaternion.LookRotation(victim.transform.position - transform.position);
            if (!anim.IsPlaying("attack"))
            {
                anim.Play("attack");
                HealthManager victimHealth = victim.GetComponent<HealthManager>();
                if (victimHealth != null)
                {
                    victimHealth.decrementHealth(strength);
                    AudioSource source = GetComponent<AudioSource>();
                    source.PlayOneShot(getAttackSound(), 0.1f);
                    if (victim != null)
                    {
                        StartCoroutine(CombatLock(2, victim.GetComponent<Monster>()));
                    }
                }
                else
                {
                    Debug.LogError("Trying to attack something that doesn not have health");
                }
            }

            return true;
        }
        return false;
    }


    private AudioClip getAttackSound()
    {
        return attackClips[UnityEngine.Random.Range(0, attackClips.Length)];
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            setOutline();
        }
        if (other.gameObject.tag == "RallyPoint" && currentState == HumanState.Falling)
        {
            SphereCollider rallyZone = other as SphereCollider;
            rallyZoneRadius = rallyZone.radius;
            droppedOnZone = true;
            rallyZoneCentre = other.gameObject.transform.position;

            closestEnemy = null;
            //rallypoint = other.transform.parent.GetComponent<RallyPoint>();
            //rallySlots = rallypoint.getRallySlots();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            removeOutline();
        }
    }

    public void Deactivate()
    {
        active = false;
    }

    public override void hit()
    {
    }

    public void debugBlackhole(Vector3 vel1)
    {
        String s = String.Format("{0} : {1}", vel1, rb.velocity);
        Debug.Log(s);
    }
}