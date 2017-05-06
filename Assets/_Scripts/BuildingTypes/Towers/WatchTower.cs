using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchTower : Tower
{

    public float arrowDamage = 5;
    float arrowSpeed = 30;
    public string buildingName;
    public GameObject target;

    GameObject pre;



    void Start()
    {
        pre = Resources.Load("Arrow_Regular") as GameObject;
        GetComponent<Rigidbody>().useGravity = false;
    }
    //find a new nearby monster to attack
    public override bool acquireTarget()
    {

        List<Collider> hitColliders = new List<Collider>(Physics.OverlapSphere(floor, radius, attackMask));
        if (hitColliders.Count > 0)
        {
            Debug.Log("Acquired target");
            currentTarget = hitColliders[0].gameObject;
            return true;
        }

        return false;
    }

    protected override IEnumerator attack()
    {

        while (true)
        {
            if (currentTarget != null && Vector3.Distance(floor, currentTarget.transform.position) < radius)
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
            Vector3 direction = Vector3.Normalize((victim.transform.position + Vector3.up * 2) - pos) * arrowSpeed;
             GameObject arrow = GameObject.Instantiate(pre, pos, Quaternion.LookRotation(direction)) as GameObject;
             arrow.GetComponent<Projectile>().parent = gameObject;
             arrow.GetComponent<Rigidbody>().velocity = direction;
             Physics.IgnoreCollision(GetComponent<Collider>(), arrow.GetComponent<Collider>());
            float travelTime = Vector3.Distance(victim.transform.position, pos) / arrowSpeed;
            if (travelTime > 10f || travelTime < 0.2f)
            {
                Destroy(arrow);
            }
            StartCoroutine(WaitToDamage(travelTime, arrowDamage, currentTarget));
            audioSource.PlayOneShot(attackClip[UnityEngine.Random.Range(0, attackClip.Length)], 0.5f);
        }
    }


    IEnumerator WaitToDamage(float waitTime, float damage, GameObject victim)
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

    public override string getName()
    {
        return "WatchTower";
    }

    public override void activate()
    {

        base.activate();
    }
}