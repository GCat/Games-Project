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

        if (resourceCounter.getBaddies() > 0)
        {
            if (currentTarget == null)
            {
                audioSource.Stop();
                fireStream.SetActive(false);
            }
            else
            {
                if (Vector3.Distance(currentTarget.transform.position, floor) < (radius+1))
                {
                    if (!audioSource.isPlaying)
                    {
                        audioSource.Play();
                    }
                    fireStream.SetActive(true);
                    fireStream.transform.LookAt(currentTarget.transform.position);
                }
                else
                {
                    currentTarget = null;
                    fireStream.SetActive(false);
                    audioSource.Stop();
                }
            }

        }
        else
        {
            fireStream.SetActive(false);
            audioSource.Stop();
        }
    }

    //find a new nearby monster to attack
    public override bool acquireTarget()
    {
        List<Collider> hitColliders = new List<Collider>(Physics.OverlapSphere(floor, transform.InverseTransformVector(radius, 0, 0).magnitude, attackMask));
        if (hitColliders.Count > 0)
        {
            currentTarget = hitColliders[0].gameObject;
            audioSource.Play();
            return true;
        }

        return false;
    }

    protected override IEnumerator attack()
    {

        while (true)
        {
            if (currentTarget != null && Vector3.Distance(currentTarget.transform.position, floor) < (radius + 1))
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