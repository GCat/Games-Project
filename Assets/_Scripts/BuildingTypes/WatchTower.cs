using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchTower : Tower
{

    public AudioClip arrowClip;
    private AudioSource arrowSource;
    public float arrowDamage = 5;
    float arrowSpeed = 30;
    

    public string buildingName;
    public GameObject target;
   
    GameObject pre;
   
    void Start()
    {
        pre = Resources.Load("Arrow_Regular") as GameObject;
        arrowSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        arrowSource.rolloffMode = AudioRolloffMode.Linear;
        arrowSource.volume = 0.7f;
        arrowSource.spatialBlend = 0.5f;
        arrowSource.clip = arrowClip;
    }

    //find a new nearby monster to attack
    public override bool acquireTarget()
    {
        List<Collider> hitColliders = new List<Collider>(Physics.OverlapSphere(transform.position, radius, attackMask));
        if (hitColliders.Count > 0)
        {
            Debug.Log("Acquired target");
            currentTarget = hitColliders[0].gameObject;
            return true;
        }

        return false;
    }

    private IEnumerator attack()
    {

        while (true)
        {
            if (currentTarget != null && Vector3.Distance(transform.position, currentTarget.transform.position) < radius)
            {
                throwArrow(currentTarget);
            }
            yield return new WaitForSeconds(2);
        }
    }

    void throwArrow(GameObject victim)
    {
        if (victim != null)
        {
            Vector3 pos = transform.TransformPoint(GetComponent<BoxCollider>().center);
            pos.y += 5f;
            Vector3 direction = Vector3.Normalize(victim.transform.position - pos) * arrowSpeed;
            GameObject arrow = GameObject.Instantiate(pre, pos, Quaternion.LookRotation(direction)) as GameObject;
            arrow.GetComponent<Projectile>().parent = gameObject;
            arrow.GetComponent<Rigidbody>().velocity = direction;
            Physics.IgnoreCollision(GetComponent<Collider>(), arrow.GetComponent<Collider>());
           
            float travelTime = Vector3.Distance(victim.transform.position, pos) / arrowSpeed;
            StartCoroutine(WaitToDamage(travelTime, arrowDamage, currentTarget));
            arrowSource.Play();
        }
    }


    IEnumerator WaitToDamage(float waitTime,float damage, GameObject victim)
    {
        yield return new WaitForSeconds(waitTime);
        if (victim != null)
        {
            HealthManager victimHealth = victim.GetComponent<HealthManager>();
            if (victimHealth != null)
            {
                victimHealth.decrementHealth(damage);
            }
        }
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

    public override string getName()
    {
        return buildingName;
    }

    public override void activate()
    {
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