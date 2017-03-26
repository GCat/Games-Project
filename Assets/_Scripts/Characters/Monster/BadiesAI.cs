﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.AI;
using UnityEngine.UI;


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
    public float health;
    public float totalHealth;
    public int faithValue;

    GameObject damageText;
    public float rotationSpeed = 6.0f;
    public bool alive = false;
    Vector3 cameraPos;
    private bool combatEngaged = false;

    // Components
    private Rigidbody rb;
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
    private LineRenderer lineRenderer;
    private Renderer[] renderers;

    private Collider[] ragdoll;

    protected GameObject currentVictim;

    public enum MonsterState { AttackTemple, AttackHumans, AttackBuildings, Idle, PathBlocked };

    MonsterState currentState = MonsterState.AttackTemple;
    MonsterState prevState;
    public MonsterState defaultState;


    // surround target position, used to decide where in teh perimeter of the building to attack
    private Vector3 sT;


    void Start()
    {
        cameraPos = GameObject.FindWithTag("MainCamera").transform.position;
        agent = GetComponent<NavMeshAgent>();
        createHealthBar();
        healthBarOri = healthBar.transform.rotation;
        lineRenderer = GetComponent<LineRenderer>();
        ragdoll = GetComponentsInChildren<Collider>();
        foreach (Collider collider in ragdoll)
        {
            collider.enabled = false;
        }
        foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
        {
            rb.isKinematic = true;
        }
        GetComponent<Collider>().enabled = true;
        damageText = Resources.Load("Damage Text") as GameObject;
        rb = GetComponent<Rigidbody>();
        closestEnemy = null;
        temple = GameObject.FindGameObjectWithTag("Temple");
        alive = true;
        Debug.Log(string.Format("Spawn at: {0} with Type: {1}", transform.position, monsterType));
        renderers = GetComponentsInChildren<Renderer>();
        templeAttackPoint = temple.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
        resources = GameObject.FindGameObjectWithTag("Tablet").GetComponent<ResourceCounter>();
        resources.addBaddie(monsterType);
        currentState = defaultState;
    }

    void Update()
    {
        if (healthBar != null)
        {
            healthBar.transform.rotation = healthBarOri;
        }

        if (alive)
        {
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
                        walkTowards(templeAttackPoint);
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
                damageIndicator.transform.Translate(new Vector3(0, 0.1f, 0));
                damageIndicator.transform.LookAt(cameraPos);
                yield return null;
            }
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
                walkTowards(closestEnemy.GetComponent<Collider>().ClosestPointOnBounds(transform.position));
        }
        else
        {
            currentState = prevState;
            changeEnemy();
        }
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
                walkTowards(closestEnemy.GetComponent<Collider>().ClosestPointOnBounds(transform.position));
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
        walkTowards(closestEnemy.GetComponent<Collider>().ClosestPointOnBounds(transform.position));

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
        health -= damage;
        StartCoroutine(DamageText("-" + damage, Color.red));
        if (health > 0 && healthBar != null)
        {
            float scale = (health / totalHealth);
            float characterScale = gameObject.transform.localScale.x;
            healthBar.transform.localScale = new Vector3(0.1f / characterScale, scale / characterScale, 0.1f / characterScale);
            healthBar.GetComponent<Renderer>().material.SetColor("_Color", new Color(1.0f - scale, scale, 0));
        }
        if (health <= 0 && alive == true)
        {
            Destroy(healthBar);
            StartCoroutine(DamageText("+" + faithValue, Color.magenta));
            resources.addFaith(faithValue);
            alive = false;
            //die animation here
            animator.enabled = false;
            foreach (Collider collider in ragdoll)
            {
                collider.enabled = false;
            }
            GameObject ghost = Instantiate(Resources.Load("Spooky_Explosion") as GameObject, transform.position, Quaternion.identity);
            Destroy(ghost, 3f);
            gameObject.tag = "Untagged";
            StartCoroutine(WaitToDestroy(0.1f));
            resources.removeBaddie(monsterType);
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
        string[] tags = new string[] { "Tower", "House", "Wall", "Farm" };
        GameObject closest = null;
        changeEnemy();
        foreach (string tag in tags)
        {
            buildings.AddRange((GameObject.FindGameObjectsWithTag(tag)));
        }

        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        if (buildings.Count > 0)
        {
            foreach (GameObject badie in buildings)
            {
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