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



public class Agent : MonoBehaviour, Character, Grabbable
{
    // Human characteristics
    public float health = 100.0f;
    public float totalHealth = 100.0f;
    GameObject healthBar;
    Quaternion healthBarOri;
    GameObject infoText;
    Quaternion infoTextOri;
    public float strength = 10.0f;
    public float gravity = 9.81F;
    public bool debug = false;
    private GameObject temple;
    private bool alive = true;
    public bool humanHeld = false;
    public bool droppedOnZone = false;

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

    private ResourceCounter resources;

    public bool active = true;
    //public CharacterController controller;
    private NavMeshAgent agent;
    private HumanState currentState = HumanState.Wandering;
    private Vector3 rallyZoneCentre;
    //private RallyPoint rallypoint;

    private Vector3 wanderPoint = Vector3.zero;
    private LineRenderer lineRenderer;

    protected Renderer[] child_materials;
    private Shader outlineShader;

    private Vector3 bL;
    private Vector3 tR;
    private float rallyZoneRadius = 10;
    
    //determines if this chap is in a fight 
    private bool combatEngaged = false;

    public enum HumanState { Fighting, Wandering, Grabbed, Falling, Defending };

    void Start()
    {

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
        createHealthBar();
        healthBarOri = healthBar.transform.rotation;
        createInfoText();
        infoTextOri = infoText.transform.rotation;
        child_materials = GetComponentsInChildren<Renderer>();
        outlineShader = Shader.Find("Toon/Basic Outline");
        lineRenderer = GetComponent<LineRenderer>();
        tR = resources.getTopRight();
        bL = resources.getBottomLeft();
        StartCoroutine(acquireTargets());
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.transform.rotation = healthBarOri;
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
                                currentState = HumanState.Defending;
                                break;
                            }
                            if (transform.position.y < 0.2)
                            {
                                rb.velocity = Vector3.zero;
                                agent.enabled = true;
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

                        //if (closestEnemy == null || !combatEngaged)
                        //{
                        //    closestEnemy = findClosestEnemy();
                        //}
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
            agent.destination = target;
            showPath();
            //controller.Move(offset * Time.deltaTime);
            //don't spin in circles
            if (!atDestination(target))
            {
                offset.y = transform.position.y;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(offset), Time.deltaTime * 10f);
            }
            anim.Play("walk");
        }

    }


    //checks whether agent has reached a point -- takes stopping distance into account
    private bool atDestination(Vector3 target)
    {
        return Vector3.Distance(target, transform.position) < (agent.stoppingDistance + 2);
    }

    private void wander()
    {
        if (wanderPoint == Vector3.zero || atDestination(wanderPoint))
        {
            wanderPoint = findNewTarget();
        }
        else
        {
            walkTo(wanderPoint);
        }
    }

    void FixedUpdate()
    {
        if (currentState == HumanState.Falling)
            if (!sacrificeEntered)
            {
                if (resources.aboveBoard(transform.position))
                {
                    if ((transform.position.y < 0.5) && droppedOnZone)
                    {
                        agent.enabled = true;
                        currentState = HumanState.Defending;
                    }
                    if (transform.position.y < 0.2)
                    {
                        rb.velocity = Vector3.zero;
                        agent.enabled = true;
                        currentState = HumanState.Wandering;
                    }
                }
                else
                {
                    sacrifice();
                }
            }
    }

    //generates a new point on the board to wander to
    private Vector3 findNewTarget() 
    {
        float randX = UnityEngine.Random.Range(bL.x, tR.x);
        float randZ = UnityEngine.Random.Range(bL.z, tR.z);
        Vector3 v = new Vector3(randX, 0, randZ);
        NavMeshHit hit;
        if (NavMesh.SamplePosition(v, out hit, 20.0f, NavMesh.AllAreas))
        {
            return hit.position;
        }
        else
        {
            Debug.Log("Could not calculate a new wander target");
            return transform.position;
        }
    }

    private void showPath()
    {
        if (agent.hasPath && debug)
        {
            lineRenderer.SetPositions(agent.path.corners);
        }

    }
    public void hit()
    {
        Debug.Log("hit");
    }

    void sacrifice()
    {
        if (!sacrificeEntered)
        {
            Debug.Log(transform.position);
            AudioSource source = GetComponent<AudioSource>();
            source.PlayOneShot(sacrificeClip, 0.5f);
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
        GameObject.Destroy(gameObject);
    }
    //locks this chap in combat for some period of time, so they don't change target
    //also aggros the enemy
    IEnumerator CombatLock(float time, BadiesAI opponent)
    {
        combatEngaged = true;
        opponent.aggro(gameObject);
        yield return new WaitForSeconds(time);
        combatEngaged = false;
    }

    private void moveStraightToTarget(GameObject target)
    {
        walkTo(target.transform.position);
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
        }
        else
        {
            moveStraightToTarget(closestEnemy);
        }

    }

    IEnumerator acquireTargets()
    {
        while (active)
        {
            if (!combatEngaged && resources.getGroundBaddies() > 0)
            {
                closestEnemy = findClosestEnemy();
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
                if (badie.GetComponent<BadiesAI>().monsterType != Portal.MonsterType.Harpy)
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

    public void decrementHealth(float damage)
    {
        health -= damage;
        if (health > 0)
        {
            float scale = (health / totalHealth);
            float characterScale = gameObject.transform.localScale.x;
            healthBar.transform.localScale = new Vector3(0.1f / characterScale, scale / characterScale, 0.1f / characterScale);
            healthBar.GetComponent<Renderer>().material.SetColor("_Color", new Color(1.0f - scale, scale, 0));
        }
        if (health <= 0 && alive == true)
        {
            alive = false;
            anim.Play("diehard");
            StartCoroutine(WaitToDestroy(2.0f));
            GameObject ghost = Instantiate(Resources.Load("Spooky_Explosion") as GameObject, transform.position, Quaternion.identity);
            Destroy(ghost, 1f);
        }
    }

    public void createHealthBar()
    {
        Bounds dims = gameObject.GetComponent<Collider>().bounds;
        Vector3 actualSize = dims.size;
        healthBar = GameObject.Instantiate(Resources.Load("CharacterHealthBar")) as GameObject;
        healthBar.transform.position = gameObject.GetComponent<Collider>().transform.position;
        healthBar.transform.Translate(new Vector3(0, 0, dims.size.y * -1.0f));
        healthBar.transform.SetParent(gameObject.transform);
    }

    public void createInfoText()
    {
        Bounds dims = gameObject.GetComponent<Collider>().bounds;
        Vector3 actualSize = dims.size;
        infoText = GameObject.Instantiate(Resources.Load("AttackSprite")) as GameObject;
        infoText.transform.position = gameObject.transform.position;
        infoText.transform.localScale *= 2;
        infoText.transform.Translate(new Vector3(0, actualSize.y * 1.4f, 0));
        infoText.transform.localRotation = gameObject.transform.localRotation;
        infoText.transform.Rotate(new Vector3(0, -90, 0));
        infoText.transform.SetParent(gameObject.transform);
        infoText.SetActive(false);
        //infoText.GetComponent<TextMesh>().text = currentState.ToString();
    }

    public void grab()
    {
        Debug.Log("Human Grabbed");
        agent.enabled = false;
        currentState = HumanState.Grabbed;
        rb.isKinematic = true;
        rb.useGravity = false;
        GetComponent<Collider>().enabled = false;
        humanHeld = true;
        droppedOnZone = false;
    }

    public void release(Vector3 vel)
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
                    StartCoroutine(CombatLock(2, victim.GetComponent<BadiesAI>()));
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


    private void setOutline()
    {
        foreach (Renderer renderer in child_materials)
        {
            renderer.material.shader = outlineShader;
            renderer.material.SetColor("_OutlineColor", Color.green);
        }
    }

    private void removeOutline()
    {
        foreach (Renderer renderer in child_materials)
        {
            renderer.material.shader = Shader.Find("Diffuse");
            //renderer.material.SetColor("_OutlineColor", Color.green);
        }
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


}