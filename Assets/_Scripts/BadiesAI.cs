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

public class BadiesAI : MonoBehaviour, Character
{

    /* Three type of badies will exist
     * Rushers: They'll go for the temple
     * Defenders: They'll follow the rushers and attack the temple if no humans or defend towers around
     * Killers: They'll attack humans
     *
     * Starting implementation of rushers
     */

    // Badie characteristic

    public float strength = 20.0f;
    public float health = 100.0f;
    public float totalHealth = 100.0f;
    GameObject healthBar;
    GameObject infoText;
    Quaternion infoTextOri;
    Quaternion healthBarOri;
    private float speed = 7.0f;
    public float rotationSpeed = 6.0f;
    public bool alive = false;

    // Components
    private Rigidbody rb;
    public Animation anim;

    // Movement
    public Vector3 startMarker;
    public Vector3 endMarker;

    private int maxCell;


    // Fighting
    public enum Fighter { Rusher, Defender, Killer, Training };
    public int fighterType;

    // Rusher
    private GameObject temple;
    private Vector3 templeAttackPoint; // nearest bound on temple



    // Killer
    public GameObject closestEnemy;
    public GameObject[] buildings;

    private ResourceCounter resources;
    private NavMeshAgent agent;

    //the nearest position on the navmesh to the desired target point
    private Vector3 nextBestTarget;
    private LineRenderer lineRenderer;

    enum MonsterState { AttackTemple, AttackHumans, AttackBuildings, Idle, PathBlocked };

    MonsterState currentState = MonsterState.AttackTemple;
    MonsterState prevState;
    private Vector3 sT;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        createHealthBar();
        healthBarOri = healthBar.transform.rotation;
        createInfoText();
        infoTextOri = infoText.transform.rotation;
        lineRenderer = GetComponent<LineRenderer>();
    }

    //can we make the spawn type an enum please xoxo
    public void spawn(int type)
    {


        anim = GetComponent<Animation>();
        rb = GetComponent<Rigidbody>();
        closestEnemy = null;

        fighterType = type;

        temple = GameObject.FindGameObjectWithTag("Temple");
        alive = true;
        Debug.Log(string.Format("Spawn at: {0} with Type: {1}", transform.position, fighterType));
        currentState = MonsterState.AttackTemple;
        gameObject.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", new Color(1, 0, 0));

        //maybe we want to do this regularly in case the monsters behaviour changes

        templeAttackPoint = temple.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
        resources = GameObject.FindGameObjectWithTag("Tablet").GetComponent<ResourceCounter>();
        resources.addBaddie();
    }

    void Update()
    {
        healthBar.transform.rotation = healthBarOri;
        infoText.transform.rotation = infoTextOri;
        if (alive)
        {



            switch (currentState)
            {
                case MonsterState.AttackTemple:
                    closestEnemy = temple;
                    walkTowards(templeAttackPoint);
                    break;
                case MonsterState.AttackHumans:
                    gameObject.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", new Color(0, 1, 0));
                    if (resources.getPop() > 0)
                    {
                        showPath();
                        humanAttack();
                    }
                    else currentState = MonsterState.AttackBuildings;
                    break;
                case MonsterState.AttackBuildings:
                    gameObject.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", new Color(0, 0, 1));

                    buildingAttack();
                    break;
                case MonsterState.PathBlocked:
                    destroyObstacle();
                    break;
                case MonsterState.Idle:
                    gameObject.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", new Color(1, 1, 1));

                    break;
            }
        }
    }

    private GameObject findObstacles()
    {
        NavMeshObstacle[] obstacles = GameObject.FindObjectsOfType(typeof(NavMeshObstacle)) as NavMeshObstacle[];
        closestEnemy = null;
        changeEnemy();
        if (obstacles.Length > 0)
        {
            float distance = Mathf.Infinity;
            foreach (NavMeshObstacle b in obstacles)
            {
                if (b.gameObject.layer != 10) continue;
                if (b.gameObject.transform.position.y > 10f) continue;
                Vector3 diff = b.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position) - transform.position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance && b.transform.position.y >= -1.0f)
                {
                    closestEnemy = b.gameObject;
                    distance = curDistance;
                }
            }
        }
        return closestEnemy;
    }

    private Vector3 getClosestPointToTarget(Vector3 target)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(target, out hit, 30.0f, NavMesh.AllAreas))
        {
            return hit.position;
        }
        else
        {
            Debug.LogError("Cannot walk here!");
            return transform.position;
        }
    }

    private Vector3 surroundTarget (Vector3 target)
    {
        if (currentState == MonsterState.AttackHumans) return target;

        int layerMask = 1 << 11;
        Collider[] team;
        team = Physics.OverlapSphere(target, 1.0f, layerMask);

        if (team.Length < 1)
        {
            return target;
        }

        else if (team.Length >= 1)
        {
            if (team.Length == 1)
            {
                if (team[0].gameObject == gameObject) return target;
            }

            for (int i = 0; i < 5; i++)
            {
                float randX = UnityEngine.Random.Range(-30, 30);
                float randZ = UnityEngine.Random.Range(-30, 30);
                if (closestEnemy == null) return target;
                Vector3 tempT = closestEnemy.GetComponent<Collider>().ClosestPointOnBounds(new Vector3(target.x + randX, target.y, target.z + randZ));
                NavMeshHit hit;
                if (NavMesh.SamplePosition(tempT, out hit, 30.0f, NavMesh.AllAreas))
                {
                    team = Physics.OverlapSphere(tempT, 1.0f, layerMask);
                    if (team.Length < 1)
                    {
                        return hit.position;
                    }
                    else if (team.Length == 1)
                    {
                        if (team[0].gameObject == gameObject) return hit.position;
                    }
                }
            }
            return target;
        }
        return target;
    }
    private void showPath()
    {
        if (agent.hasPath)
        {
            lineRenderer.SetPositions(agent.path.corners);
        }

    }

    private void destroyObstacle()
    {
        if (closestEnemy != null)
            walkTowards(closestEnemy.GetComponent<Collider>().ClosestPointOnBounds(transform.position));
        else
        {
            currentState = prevState;
            changeEnemy();
        }
    }


    private void buildingAttack()
    {
        // for now attack towers
        if (closestEnemy != null)
        {
            walkTowards(closestEnemy.GetComponent<Collider>().ClosestPointOnBounds(transform.position));
        }
        else
        {
            changeEnemy();
            closestEnemy = findClosestEnemy("Tower");
            if (closestEnemy == null) currentState = MonsterState.AttackTemple;
        }

    }
    private void humanAttack()
    {

        if (closestEnemy != null)
        {
            walkTowards(closestEnemy.GetComponent<Collider>().ClosestPointOnBounds(transform.position));
        }
        else
        {
            changeEnemy();
            closestEnemy = findClosestEnemy("Human");
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
        if (sT == Vector3.zero)
        {
            Vector3 tempsT = surroundTarget(nextBestTarget);
            if (Vector3.Distance(target, tempsT) > 0.5f)
            {
                sT = tempsT;
                target = sT;
            }
            
        }
        else target = sT;
 
        Vector3 offset = target - transform.position;
        
        //don't spin in circles
        if (offset.magnitude > 5)
        {
            NavMeshPath path = new NavMeshPath();
            agent.CalculatePath(target, path);
            if (path.status != NavMeshPathStatus.PathComplete)
            {
                closestEnemy = findObstacles();
                if (closestEnemy == null)
                {
                    Debug.LogError("NO OBSTACLE FOUND AND NO PATH U FUCKED!");
                }
                else
                {
                    prevState = currentState;
                    currentState = MonsterState.PathBlocked;
                }
            }
            else
            {
                agent.destination = target;
                showPath();
                offset.y = transform.position.y;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(offset), Time.deltaTime * rotationSpeed);
                anim.Play("walk");
            }
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
                attack(closestEnemy);
                break;
            case MonsterState.AttackHumans:
                attack(closestEnemy);
                break;
            case MonsterState.AttackBuildings:
                attack(closestEnemy);
                break;
            case MonsterState.PathBlocked:
                attack(closestEnemy);
                break;
            case MonsterState.Idle:

                break;
        }
    }

    bool attack(GameObject victim)
    {
        if (victim != null)
        {

            transform.rotation = Quaternion.LookRotation(victim.transform.position - transform.position);
            if (!anim.IsPlaying("hit"))
            {
                anim.Play("hit");
                HealthManager victimHealth = victim.GetComponent<HealthManager>();
                if (victimHealth != null)
                {
                    victimHealth.decrementHealth(strength);
                }
                else
                {
                    Debug.LogError("Trying to attack something that doesn not have health");
                }
            }
            return true;
        }
        changeEnemy();
        return false;
    }

    public void decrementHealth(float damage)
    {
        health -= damage;
        float scale = (health / totalHealth);
        float characterScale = gameObject.transform.localScale.x;
        healthBar.transform.localScale = new Vector3(0.1f / characterScale, scale / characterScale, 0.1f / characterScale);
        if (scale != 0) healthBar.GetComponent<Renderer>().material.SetColor("_Color", new Color(1.0f - scale, scale, 0));
        if (health <= 0 && alive == true)
        {
            alive = false;
            anim.Play("die");
            StartCoroutine(WaitToDestroy(0.7f));
            resources.removeBaddie();
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
        infoText = GameObject.Instantiate(Resources.Load("Info_Text")) as GameObject;
        infoText.transform.position = gameObject.transform.position;
        infoText.transform.localScale *= 2;
        infoText.transform.Translate(new Vector3(0, actualSize.y * 1.4f, 0));
        infoText.transform.localRotation = gameObject.transform.localRotation;
        infoText.transform.Rotate(new Vector3(0, -90, 0));
        infoText.transform.SetParent(gameObject.transform);
    }

    private GameObject findClosestEnemy(string tag)
    {
        GameObject[] humans;
        GameObject closest = null;
        changeEnemy();
        humans = GameObject.FindGameObjectsWithTag(tag);
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
        return closest;
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

    public void setTempleAttackPoint(Vector3 p)
    {
        templeAttackPoint = p;
    }

    private void changeEnemy()
    {
        sT = Vector3.zero;
    }

}