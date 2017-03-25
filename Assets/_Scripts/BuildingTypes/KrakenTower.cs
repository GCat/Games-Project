using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenTower : Tower
{
    public float damage_per_second = 10;
    private Animation anim;
    public GameObject target;
    public string buildingName;


    void Start()
    {
        //Kraken animation
        anim = GetComponent<Animation>();
    }


    //find a new nearby monster to attack
    public override bool acquireTarget()
    {
        return false;
    }

    private void playForwards()
    {
        anim["Attack"].speed = 1.0f;
        anim.Play("Attack");
    }

    private void playBackwards()
    {
        anim["Attack"].speed = -1.0f;
        anim["Attack"].time = anim["Attack"].length;
        anim.Play("Attack");
    }


    private IEnumerator attack()
    {
        while (true)
        {
            if (currentTarget != null && Vector3.Distance(currentTarget.transform.position, transform.position) < radius)
            {
                HealthManager targetHealth = currentTarget.GetComponent<HealthManager>();
                if (targetHealth != null)
                {
                    playForwards();
                    targetHealth.decrementHealth(damage_per_second);
                    playBackwards();
                }
            }
            yield return new WaitForSeconds(1);
        }
    }



    public override string getName()
    {
        return "";
    }

    public override bool canBuy()
    {
        return false;
    }

 

    public override void activate()
    {
    }
}
