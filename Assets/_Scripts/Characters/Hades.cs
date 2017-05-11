using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hades : MonoBehaviour, HealthManager
{

    public Animator animator;
    public Material original;
    public Material stoneMat;
    public GameObject playerHead;
    public GameObject projectile;
    public GameObject r_hand;
    public GameObject r_arm;
    public GameObject firePoint;
    public HealthBar healthBar;
    public GameObject meleePos;
    public WorldStarter world;
    GameObject playerBody;
    public int maxRangedAttacks = 5;
    int rangedAttacks = 0;
    enum BossState { Idle, Ranged, Melee, Dead };
    BossState state = BossState.Idle;
    // Use this for initialization
    void Start()
    {
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            if (renderer.gameObject.GetComponent<HealthBar>() == null)
            {
                renderer.material = stoneMat;
            }
        }
        foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
        {
            rb.isKinematic = true;
        }
        animator.enabled = false;
        playerBody = GameObject.FindGameObjectWithTag("PlayerBody");
    }

    // Update is called once per frame
    void Update()
    {
        if (state == BossState.Melee)
        {
            Vector3 target = playerBody.transform.position;
            target.y = transform.position.y;

            if (Vector3.Distance(transform.position, target) > 30f)
            {
                transform.position = Vector3.Lerp(transform.position, (target - transform.position).normalized, Time.deltaTime * 0.1f);
                animator.SetBool("Punching", false);
            }
            else if (Vector3.Distance(transform.position, target) > 20f)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(target - transform.position, Vector3.up), Time.deltaTime * 0.5f);
                transform.LookAt(target);
                animator.SetBool("Punching", false);
            }
            else
            {
                animator.SetBool("Punching", true);
            }
        }

    }


    IEnumerator attack()
    {
        while (state != BossState.Dead)
        {
            Debug.Log("attacking");
            switch (state)
            {
                case BossState.Idle:
                    break;
                case BossState.Ranged:
                    rangedAttack();
                    break;
                case BossState.Melee:
                    //meleeAttack();
                    break;
                case BossState.Dead:
                    Destroy(gameObject);
                    break;
            }
            yield return new WaitForSeconds(1f);
        }

    }


    void rangedAttack()
    {
        animator.SetBool("Fire", true);
    }

    void meleeAttack()
    {

        animator.SetBool("Fire", false);
        animator.SetBool("Punch", true);
    }

    public void fire()
    {
        Vector3 direction = Vector3.Normalize(playerHead.transform.position - firePoint.transform.position) * 50;
        GameObject fireBall = Instantiate(projectile, firePoint.transform.position, Quaternion.identity);
        fireBall.GetComponent<Rigidbody>().AddForce(direction, ForceMode.VelocityChange);
        fireBall.GetComponent<ParticleSystem>().Clear();
        fireBall.GetComponent<ParticleSystem>().Play();
        fireBall.GetComponent<FireBall>().hades = this;
        rangedAttacks++;
        if (rangedAttacks >= maxRangedAttacks)
        {
            nextStage();
        }
    }

    public void comeAlive()
    {
        healthBar.gameObject.SetActive(true);
        animator.enabled = true;

        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            if (renderer.gameObject.GetComponent<HealthBar>() == null)
            {
                renderer.material = original;
            }
        }
        state = BossState.Ranged;
        StartCoroutine(attack());
    }



    public void celebrate()
    {
        //animator.SetBool("Celebrate", true);

    }

    void nextStage()
    {
        healthBar.resetHealth();
        if (state == BossState.Ranged)
        {
            state = BossState.Melee;
            //transform.position = meleePos.transform.position;
            animator.SetBool("Fire", false);
            animator.SetBool("Walking", true);
        }
        else if (state == BossState.Melee)
        {
            state = BossState.Dead;
            die();
            animator.enabled = false;
        }

    }


    void die()
    {
        foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
        {
            rb.isKinematic = false;
        }
        StartCoroutine(waitToDestroy(5));
        world.stopGame();
}

    IEnumerator waitToDestroy(float time)
    {
        yield return new WaitForSeconds(time);
        if (gameObject != null)
        {
            Destroy(gameObject);
        }

    }

    public void decrementHealth(float damage)
    {
        healthBar.decrementHealth(damage);
        if (healthBar.health <= 0)
        {
            nextStage();

        }
    }
}
