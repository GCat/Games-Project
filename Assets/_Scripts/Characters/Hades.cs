using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hades : MonoBehaviour, HealthManager {

    public Animator animator;
    public Material original;
    public Material stoneMat;
    public GameObject playerHead;
    public GameObject projectile;
    public GameObject r_hand;
    public GameObject l_hand;
    public GameObject head;
    public GameObject chest;
    


    enum BossState {Idle, Ranged, Melee, Dead };
    BossState state = BossState.Idle;
	// Use this for initialization
	void Start () {
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {

            renderer.material = stoneMat;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    	
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
                    break;
                case BossState.Dead:
                    break;
            }
            yield return new WaitForSeconds(5f);
        }

    }


    void rangedAttack()
    {
        animator.SetBool("Fire", true);
    }

    void meleeAttack()
    {
        animator.SetBool("Punch", true);
    }

    public void fire()
    {
        Vector3 direction = Vector3.Normalize(playerHead.transform.position - r_hand.transform.position)*50;
        GameObject fireBall = Instantiate(projectile, r_hand.transform.position, Quaternion.identity);
        Physics.IgnoreCollision(r_hand.GetComponent<Collider>(), fireBall.GetComponent<Collider>());
        fireBall.GetComponent<Rigidbody>().AddForce(direction,ForceMode.VelocityChange);
        fireBall.GetComponent<ParticleSystem>().Clear();
        fireBall.GetComponent<ParticleSystem>().Play();
        fireBall.GetComponent<FireBall>().hades = this;
    }

    public void comeAlive()
    {
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            renderer.material = original;
        }
        state = BossState.Ranged;
        StartCoroutine(attack());
    }



    public void celebrate()
    {
        //animator.SetBool("Celebrate", true);

    }

    public void decrementHealth(float damage)
    {
        
    }
}
