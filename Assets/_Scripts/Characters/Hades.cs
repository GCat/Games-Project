using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hades : MonoBehaviour {

    public Animator animator;
    Material original;
    public Material stoneMat;
    public GameObject playerHead;

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
        }
        yield return new WaitForSeconds(5f);

    }


    void rangedAttack()
    {
        animator.SetTrigger("Fire");
    }

    void meleeAttack()
    {
        animator.SetBool("Punch", true);
    }

    void fire()
    {


    }

    public void comeAlive()
    {
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            renderer.material = original;
        }
        state = BossState.Ranged;
        animator.SetBool("Celebrate", true);
    }



    public void celebrate()
    {
        //animator.SetBool("Celebrate", true);

    }
}
