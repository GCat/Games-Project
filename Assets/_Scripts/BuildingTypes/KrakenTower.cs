using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenTower : Tower
{

    public AudioClip build;
    public AudioClip destroy;
    public LineRenderer linerenderer;
    public GameObject mirror;
    public float damage_per_second = 10;
    private Animation anim;

    public string buildingName;
    public GameObject target;

    
   

    void Start()
    {

        rangeHighlight = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        rangeHighlight.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
        rangeHighlight.transform.localScale = new Vector3(radius, 0.1f, radius);
        rangeHighlight.transform.position = new Vector3(gameObject.transform.position.x, 0.1f, gameObject.transform.position.z);
        rangeHighlight.transform.rotation = Quaternion.LookRotation(Vector3.forward);

        rangeHighlight.GetComponent<Collider>().enabled = false;
        rangeHighlight.GetComponent<Renderer>().enabled = true;
        rangeHighlight.SetActive(false);

        //Kraken animation
        anim = GetComponent<Animation>();
    }


    //find a new nearby monster to attack
    public override bool acquireTarget()
    {
        List<Collider> hitColliders = new List<Collider>(Physics.OverlapSphere(transform.position, radius, attackMask));
        if (hitColliders.Count > 0)
        {
            target = hitColliders[0].gameObject;
            return true;
        }
        else
        {
            linerenderer.SetPositions(new Vector3[0]);
        }

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
        return buildingName;
    }

    public override bool canBuy()
    {
        if (!bought && (resourceCounter.faith >= faithCost))
        {
            bought = true;
            resourceCounter.removeFaith(faithCost);
            return true;
        }
        return false;
    }

 

    public override void activate()
    {
        //when do you call create buiding for towers ? -- cost does not work 
        if (!bought) resourceCounter.removeFaith(faithCost);
        active = true;
        if (highlight != null) Destroy(highlight);
        highlight = null;
        held = false;
        buildingName = "TOWER";
        hideRange();
        StartCoroutine(attack());

    }
}
