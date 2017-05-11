using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : Tower
{
    public float fireDamagePerSecond = 5;
    public string buildingName;
    public GameObject target;
    public GameObject fireStream;
    void Start()
    {
        Vector3 pos = transform.position;
        pos.y += 5;
        fireStream.SetActive(false);
        audioSource.clip = attackClip[0];
        audioSource.volume = 0.4f;
        GetComponent<Rigidbody>().useGravity = false;
    }

    public override void activeTower()
    {
        if (currentTarget != null)
        {
            fireStream.transform.LookAt(currentTarget.transform.position);
        }
        else
        {
            audioSource.Stop();
            fireStream.SetActive(false);
            fireStream.GetComponent<ParticleSystem>().Stop();
        }
    }

    //find a new nearby monster to attack
    public override bool acquireTarget()
    {
        Debug.Log("acquiring target");

        List<Collider> hitColliders = new List<Collider>(Physics.OverlapSphere(floor, radius, attackMask));
        if (hitColliders.Count > 0)
        {
            Debug.Log("activate stream");
            fireStream.SetActive(true);
            fireStream.GetComponent<ParticleSystem>().Play();

            currentTarget = hitColliders[0].gameObject;
            fireStream.transform.LookAt(currentTarget.transform.position);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            return true;
        }
        else
        {
            audioSource.Stop();
            fireStream.SetActive(false);
            fireStream.GetComponent<ParticleSystem>().Stop();
        }

        return false;
    }

    void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(floor, radius);

    }

    protected override IEnumerator attack()
    {

        while (true)
        {
            Debug.Log("attacking");
            if (currentTarget != null && Vector3.Distance(currentTarget.GetComponent<Collider>().ClosestPointOnBounds(floor), floor) < radius)
            {
                HealthManager targetHealth = currentTarget.GetComponent<HealthManager>();
                if (targetHealth != null)
                {
                    targetHealth.decrementHealth(fireDamagePerSecond);
                }
            }
            yield return new WaitForSeconds(1);
        }
    }

    public override string getName()
    {
        return "FireTower";
    }

    public override void activate()
    {
        base.activate();
    }
}