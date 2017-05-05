using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.AI;
using UnityEngine.UI;
using System;

public abstract class Monster : Character
{

    /* Three type of badies will exist
     * Rushers: They'll go for the temple
     * Defenders: They'll follow the rushers and attack the temple if no humans or defend towers around
     * Killers: They'll attack humans
     *
     * Starting implementation of rushers
     */

    // Badie characteristic
    public float strength;
    public int faithValue;
    public bool active;

    GameObject damageText;
    public float rotationSpeed = 6.0f;
    public bool alive = false;
    Vector3 cameraPos;
    private bool combatEngaged = false;
    public float speedModifier = 1;
    // Components
    public Animator animator;


    public Portal.MonsterType monsterType;

    // Rusher
    private GameObject temple;
    private Vector3 templeAttackPoint; // nearest bound on temple

    // Killer
    protected GameObject closestEnemy;
    protected GameObject[] buildings;


    //the nearest position on the navmesh to the desired target point
    private Vector3 nextBestTarget;

    private Collider[] ragdoll;

    protected GameObject currentVictim;

    public enum MonsterState { AttackTemple, AttackHumans, AttackBuildings, Idle, PathBlocked };

    MonsterState currentState = MonsterState.AttackTemple;
    MonsterState prevState;
    public MonsterState defaultState;


    // surround target position, used to decide where in teh perimeter of the building to attack
    private Vector3 sT;
    protected ParticleSystem stunEffect;
    //stunned should maybe be a state :)
    private bool isStunned = false;
    private bool resistStunning = false;

    void Start()
    {
        healthBar = GetComponentInChildren<HealthBar>();
        active = true;
        cameraPos = GameObject.FindWithTag("MainCamera").transform.position;
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
        ragdoll = GetComponentsInChildren<Collider>();
        foreach (Collider collider in ragdoll)
        {
            collider.enabled = false;
        }

        GetComponent<Collider>().enabled = true;
        float height = GetComponent<Collider>().bounds.size.y;
        damageText = Resources.Load("Damage Text") as GameObject;
        closestEnemy = null;
        temple = GameObject.FindGameObjectWithTag("Temple");
        alive = true;
        templeAttackPoint = temple.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
        resources = GameObject.FindGameObjectWithTag("Tablet").GetComponent<ResourceCounter>();
        resources.addBaddie(monsterType);
        currentState = defaultState;
        GameObject stun = Instantiate(Resources.Load("Particles/Seeing_Stars") as GameObject, healthBar.transform.position + Vector3.down * 1, Quaternion.identity);
        stun.transform.SetParent(transform);
        stunEffect = stun.GetComponent<ParticleSystem>();
        stunEffect.Stop();
        animator.speed = speedModifier;
    }

    void Update()
    {
        if (alive && active)
        {
            if (isStunned)
            {
                return;
            }
            switch (currentState)
            {
                case MonsterState.AttackTemple:
                    if (defaultState == MonsterState.AttackHumans && resources.getPop() > 0)
                    {
                        currentState = defaultState;
                    }
                    else
                    {
                        closestEnemy = temple;
                        try
                        {
                            walkTowards(templeAttackPoint);
                        }
                        catch (TargetNotFoundException e)
                        {
                            currentState = MonsterState.Idle;
                        }
                    }
                    break;
                case MonsterState.AttackHumans:
                    if (resources.getPop() > 0)
                    {
                        attackHumans();
                    }
                    else currentState = MonsterState.AttackBuildings;
                    break;
                case MonsterState.AttackBuildings:
                    attackBuildings();
                    break;
                case MonsterState.PathBlocked:
                    destroyObstacle();
                    break;
                case MonsterState.Idle:
                    break;
            }
        }
    }

    public IEnumerator DamageText(string textString, Color color)
    {
        GameObject damageIndicator = Instantiate(damageText, (new Vector3(transform.position.x, transform.position.y + 5, transform.position.z)), Quaternion.LookRotation(transform.position - cameraPos, Vector3.up)) as GameObject;
        Text text = damageIndicator.GetComponentInChildren<Text>();
        text.text = textString;
        text.color = color;
        Destroy(damageIndicator, 1);
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            if (damageIndicator != null)
            {
                Color c = text.color;
                c.a = f;
                text.color = c;
                if (damageIndicator != null)
                {
                    damageIndicator.transform.Translate(new Vector3(0, 0.1f, 0));
                    damageIndicator.transform.LookAt(cameraPos);
                }
                yield return null;
            }
        }
        if (damageIndicator != null)
        {
            Destroy(damageIndicator);
        }
    }

    //badies response to an attacker
    public void aggro(GameObject attacker)
    {
        if (attacker.GetComponent<Agent>() != null && !combatEngaged)
        {
            currentState = MonsterState.AttackHumans;
            closestEnemy = attacker;
            StartCoroutine(CombatLock(3));
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
        if (NavMesh.SamplePosition(target, out hit, 40.0f, NavMesh.AllAreas))
        {
            return hit.position;
        }
        else
        {
            throw new TargetNotFoundException();
        }
    }

    private Vector3 surroundTarget(Vector3 target)
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

    private void destroyObstacle()
    {
        if (closestEnemy != null)
        {
            if (Mathf.Abs(closestEnemy.transform.position.y) > 5.0f)
            {
                closestEnemy = null;
                changeEnemy();
                currentState = prevState;
            }
            else
            {
                try
                {
                    walkTowards(closestEnemy.GetComponent<Collider>().ClosestPointOnBounds(transform.position));
                }
                catch (TargetNotFoundException e)
                {
                    currentState = MonsterState.AttackHumans;
                }
            }
        }
        else
        {
            currentState = prevState;
            changeEnemy();
        }
    }

    IEnumerator preventLock(float time)
    {
        isStunned = false;
        resistStunning = true;
        yield return new WaitForSeconds(time);
        resistStunning = false;

    }

    IEnumerator stunLock(float time)
    {
        isStunned = true;
        if(agent != null) agent.isStopped = true;
        yield return new WaitForSeconds(time);

        isStunned = false;
        if (agent != null && agent.isOnNavMesh) agent.isStopped = false;
        preventLock(2);

    }

    public void stun()
    {
        stunEffect.Clear();
        stunEffect.Play();
        if (!resistStunning)
        {
            try
            {
                StartCoroutine(stunLock(2));
            }
            catch (Exception e)
            {
                Debug.LogError("FUCK");
            }
        }
    }

    public override void grab()
    {

    }

    public override void release(Vector3 vel)
    {
    }

    private void attackBuildings()
    {
        if (closestEnemy != null)
        {
            if (Mathf.Abs(closestEnemy.transform.position.y) > 5.0f)
            {
                closestEnemy = null;
                changeEnemy();
            }
            else
            {
                try
                {
                    walkTowards(closestEnemy.GetComponent<Collider>().ClosestPointOnBounds(transform.position));
                }
                catch (TargetNotFoundException e)
                {
                    currentState = MonsterState.AttackHumans;
                }
            }
        }
        else
        {
            changeEnemy();
            closestEnemy = findClosestBuilding();
            if (closestEnemy == null) currentState = MonsterState.AttackTemple;
        }

    }
    private void attackHumans()
    {
        //get new target if needed
        if (closestEnemy == null)
        {
            changeEnemy();
            closestEnemy = findClosestEnemy("Human");
        }
        //if there are no humans, go attack buildings
        if (closestEnemy == null)
        {
            currentState = MonsterState.AttackBuildings;
            return;
        }
        //otherwise walk towards target or attack if close
        try
        {
            walkTowards(closestEnemy.GetComponent<Collider>().ClosestPointOnBounds(transform.position));
        }
        catch (TargetNotFoundException e)
        {
            //ideally if you can't walk towards a human you should go to the next -- not implemented yet
            currentState = MonsterState.AttackTemple;
        }

    }
    IEnumerator CombatLock(float time)
    {
        combatEngaged = true;
        yield return new WaitForSeconds(time);
        combatEngaged = false;
    }
    private void walkTowards(Vector3 target)
    {
        if (target != nextBestTarget)
        {
            //if the target is not on the nav mesh, just get the nearest valid point for now
            try
            {
                nextBestTarget = getClosestPointToTarget(target);
            }
            catch (TargetNotFoundException exception)
            {
                Debug.LogError(exception);
                return;
            }
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
        //don't spin in circles
        if (!atDestination(target))
        {
            NavMeshPath path = new NavMeshPath();
            agent.CalculatePath(target, path);
            if (path.status != NavMeshPathStatus.PathComplete)
            {
                closestEnemy = findObstacles();
                if (closestEnemy == null)
                {

                }
                else
                {
                    prevState = currentState;
                    currentState = MonsterState.PathBlocked;
                }
            }
            else
            {
                setDestination(target);
                Vector3 offset = target - transform.position;
                offset.y = transform.position.y;
                if (sT == Vector3.zero)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(offset), Time.deltaTime * rotationSpeed);
                }
                else
                {
                    if (closestEnemy != null)
                    {
                        offset = closestEnemy.transform.position - transform.position;
                        offset.y = transform.position.y;
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(offset), Time.deltaTime * rotationSpeed);
                    }
                }
                animator.SetBool("Walking", true);
            }
        }
        else
        {
            reachedTarget();
        }
    }

    private void reachedTarget()
    {
        if (currentState != MonsterState.Idle)
        {
            attack(closestEnemy);
        }
    }

    bool attack(GameObject victim)
    {
        if (victim != null)
        {
            float y = transform.position.y;
            Vector3 victimPos = victim.transform.position;
            victimPos.y = y;
            //transform.rotation = Quaternion.LookRotation(victimPos - transform.position);
            currentVictim = victim;
            animator.SetBool("Attacking", true);
            return true;
        }
        else
        {
            currentVictim = null;
            changeEnemy();
            return false;

        }
    }

    public override void decrementHealth(float damage)
    {
        healthBar.decrementHealth(damage);
        try
        {
            StartCoroutine(DamageText("-" + damage, Color.red));
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
        if (healthBar.health <= 0 && alive == true)
        {
            Destroy(healthBar);

            //StartCoroutine(DamageText("+" + faithValue, Color.magenta));
            resources.addFaith(faithValue);
            alive = false;
            //die animation here
            animator.enabled = false;
            foreach (Collider collider in ragdoll)
            {
                collider.enabled = false;
            }
            if (GetComponent<Bee>() != null)
            {
                GameObject ghost = Instantiate(Resources.Load("Particles/Spooky_Explosion") as GameObject, transform.position, Quaternion.identity);
                Destroy(ghost, 3f);
            }
            gameObject.tag = "Untagged";
            //StartCoroutine(WaitToDestroy(0.1f));
            resources.removeBaddie(monsterType);
            Destroy(gameObject);
        }
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
            foreach (GameObject human in humans)
            {
                if (Mathf.Abs(human.transform.position.y) > 5.0f) continue;
                Vector3 diff = human.transform.position - position;
                float current_distance = diff.sqrMagnitude;
                if (current_distance < distance)
                {
                    distance = current_distance;
                    closest = human;
                }
            }
        }
        return closest;
    }

    private GameObject findClosestBuilding()
    {
        List<GameObject> buildings = new List<GameObject>();
        string[] tags = new string[] { "Tower", "House", "Wall" };
        GameObject closest = null;
        changeEnemy();
        foreach (string tag in tags)
        {
            GameObject [] bs = GameObject.FindGameObjectsWithTag(tag);
            if(bs.Length > 0) buildings.AddRange(bs);
        }

        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        if (buildings.Count > 0)
        {
            foreach (GameObject badie in buildings)
            {
                // This could cause a bug should be change for a system to check that building is active and all buildings in cloud should be inactive
                if (Mathf.Abs(badie.transform.position.y) > 5.0f) continue;
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
        animator.SetBool("Attacking", false);

        sT = Vector3.zero;
    }


}