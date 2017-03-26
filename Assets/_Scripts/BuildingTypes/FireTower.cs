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
    }

    public override void activeTower()
    {
        if (resourceCounter.getBaddies() > 0)
        {
            if (currentTarget == null)
            {
                audioSource.Stop();
                fireStream.SetActive(false);
                acquireTarget();
            }
            else
            {
                if (Vector3.Distance(currentTarget.transform.position, transform.position) < radius)
                {
                    fireStream.SetActive(true);
                    fireStream.transform.LookAt(currentTarget.transform.position);
                }
                else
                {
                    fireStream.SetActive(false);
                    audioSource.Stop();
                }
            }

        }
        else
        {
            fireStream.SetActive(false);
        }
    }

    //find a new nearby monster to attack
    public override bool acquireTarget()
    {
        List<Collider> hitColliders = new List<Collider>(Physics.OverlapSphere(transform.position, radius, attackMask));
        if (hitColliders.Count > 0)
        {
            currentTarget = hitColliders[0].gameObject;
            audioSource.Play();
            return true;
        }

        return false;
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
                    targetHealth.decrementHealth(fireDamagePerSecond);
                }
            }
            yield return new WaitForSeconds(1);
        }
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
        if (!activated)
        {
            StartCoroutine(attack());
            activated = true;
        }
    }
}