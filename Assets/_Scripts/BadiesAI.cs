using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.AI;

/* AI LOGIC EXPLANATION
 * 
 * --Rushers COMPLETED
 * Search fastest path to temple using A*
 * When found move a node at a time
 * If buildings in the way destroy building
 * When temple in range attack 
 * 
 * --Defenders COMPLETED
 * Go towards temple same way as rushers
 * Once on temple range 
 * If humans or watch towers nears attack them to protect rusher
 * If nothing near attack temple
 * 
 * 
 * --Killers
 * Search for nearest human 
 * Go to its position (not sure how this will be done yet)
 * Attack it
 * When dead look for next human
 * If no humans remain either go for watch towers or go for temple 
 * 
 */

public class BadiesAI : MonoBehaviour, Character {

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
    private float speed = 7.0f;
    public float rotationSpeed = 6.0f;
    private bool alive = false;

    // Components
    private Rigidbody rb;
    public Animation anim;

    // Movement
    private bool moving= true;
    public Vector3 startMarker;
    public Vector3 endMarker;

    private int maxCell;


    // Fighting
    public enum Fighter {  Rusher, Defender, Killer, Training };
    public int fighterType;

    // Rusher
    private GameObject temple;
    private Vector3 templeAttackPoint; // nearest bound on temple
    public bool templeInRange = false;
    public bool pathToTempleFound = false;


    // Killer
    public GameObject closestEnemy;
    private bool noMoreEnemies = false;
    private float dis2Enemy = 0;

    //Defender
    private float radius = 25.0f;
    private float dis2Temple;
    public bool enemyInrange = false;
    public bool defending = false;
    public bool path2Enemy = false;


    // Training
    private bool enemyFound;
    private bool buildingsLeft = true;
    public GameObject[] buildings;

    private ResourceCounter resources;
    private NavMeshAgent agent;

    //the nearest position on the navmesh to the desired target point
    private Vector3 nextBestTarget;

    enum MonsterState {AttackTemple, AttackHumans, AttackBuildings, Idle };

    MonsterState currentState = MonsterState.AttackTemple;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    //can we make the spawn type an enum please xoxo
    public void spawn(int type)
    {
        
        moving = true;
        noMoreEnemies = false;

        anim = GetComponent<Animation>();
        rb = GetComponent<Rigidbody>();
        //rb.interpolation = RigidbodyInterpolation.Interpolate;
        closestEnemy = null;

        fighterType = type;

        temple = GameObject.FindGameObjectWithTag("Temple");
        alive = true;
        Debug.Log(string.Format("Spawn at: {0} with Type: {1}", transform.position, fighterType));
        currentState = MonsterState.AttackTemple;

        //maybe we want to do this regularly in case the monsters behaviour changes

        templeAttackPoint = temple.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
        resources = GameObject.FindGameObjectWithTag("Tablet").GetComponent<ResourceCounter>();
        resources.addBaddie();

    }

    void Update()
    {   if (alive)
        {

            switch (currentState) {
                case MonsterState.AttackTemple:
                    walkTowards(templeAttackPoint);
                    break;
                case MonsterState.AttackHumans:
                    //find nearest human
                    
                    break;
                case MonsterState.AttackBuildings:

                    break;
                case MonsterState.Idle:

                    break;
            }

            

            //if (false/*temple == null*/)  anim.Play("rage");
            //else if (!moving) anim.Play("idle");
            //else if (fighterType == (int)Fighter.Rusher) rusherNav();
            //else if (fighterType == (int)Fighter.Defender) defenderNav();
            //else if (fighterType == (int)Fighter.Killer) killerNav();
            //else if (fighterType == (int)Fighter.Training) trainingNav();
        }
    }

    private void findBuidling()
    {
        buildings = GameObject.FindGameObjectsWithTag("Building");
        if( buildings.Length > 0)
        {
            
            closestEnemy = null;
            float distance = Mathf.Infinity;
            foreach (GameObject b in buildings)
            {
                Vector3 diff = b.GetComponent<Collider>().ClosestPointOnBounds(transform.position) - transform.position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance && b.transform.position.y >= -1.0f)
                {
                    closestEnemy = b;
                    distance = curDistance;
                }
            }
        }
    }

    private Vector3 getClosestPointToTarget(Vector3 target)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(target, out hit, 20.0f, NavMesh.AllAreas))
        {
            return hit.position;
        }
        else
        {
            Debug.LogError("Cannot walk here!");
            return transform.position;
        }

    }


    private void walkTowards(Vector3 target)
    {
        if (target != nextBestTarget)
        {
            //if the target is not on the nav mesh, just get the nearest valid point for now
            nextBestTarget = getClosestPointToTarget(target);
            target = nextBestTarget;
        }
        Vector3 offset = target - transform.position;
        offset = offset.normalized * speed;
        agent.destination = target;
        //controller.Move(offset * Time.deltaTime);
        //don't spin in circles
        if (offset.magnitude > 5)
        {
            offset.y = transform.position.y;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(offset), Time.deltaTime * rotationSpeed);
            anim.Play("walk");
        }
        else
        {

            reachedTarget();

        }
    }

    private void reachedTarget()
    {
        switch (currentState)
        {
            case MonsterState.AttackTemple:
                attack(temple);
                break;
            case MonsterState.AttackHumans:

                break;
            case MonsterState.AttackBuildings:

                break;
            case MonsterState.Idle:

                break;
        }


    }

    bool attack(GameObject victim)
    {
        if (victim != null)
        {
            anim.Play("hit");
            transform.rotation = Quaternion.LookRotation(victim.transform.position- transform.position);
            //if it's a building
            HealthManager victimHealth = victim.GetComponent<HealthManager>();
            if (victimHealth != null)
            {
                victimHealth.decrementHealth(strenght * Time.deltaTime);
            } else {
                Debug.LogError("Trying to attack something that doesn not have health");
            }
            return true;
        }
        return false;
    }

    public void decrementHealth(float damage)
    {
        health -= damage;
        if (health <= 0 && alive == true)
        {
            alive = false;
            anim.Play("die");
            StartCoroutine(WaitToDestroy(0.7f));
            resources.removeBaddie();
        }
    }

    private GameObject findClosestEnemy()
    {
        GameObject[] humans;
        GameObject closest = null;
        humans = GameObject.FindGameObjectsWithTag("Human");
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        if (humans.Length > 0)
        {
            foreach (GameObject badie in humans)
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
    public void changeMoving(bool val)
    {
        moving = val;
    }

    IEnumerator WaitToDestroy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GameObject.Destroy(gameObject);
    }

    public void changeMode(bool val)
    {
        //Not used for baddies atm
    }

}