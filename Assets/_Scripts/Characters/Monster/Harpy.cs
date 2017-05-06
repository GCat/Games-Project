using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Harpy : Monster
{
    public GameObject projectile;
    public float range;
    void Awake()
    {
        if (projectile == null)
        {
            projectile = Resources.Load("Particles/Projectile") as GameObject;
        }
    }


    public override void hit()
    {
        if (currentVictim == null)
        {
            Debug.Log("No current victim");
            return;
        }
        HealthManager victimHealth = currentVictim.GetComponent<HealthManager>();
        if (victimHealth != null)
        {
            Vector3 direction = Vector3.Normalize(currentVictim.transform.position - transform.position) * 15;
            float travelTime = Vector3.Distance(currentVictim.transform.position, transform.position) /15f;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);
            StartCoroutine(WaitToDamage(travelTime, strength, currentVictim));
            GameObject spit = Instantiate(projectile, transform.position + Vector3.up, transform.rotation);
            spit.GetComponent<Rigidbody>().velocity = direction;
            spit.GetComponent<ParticleSystem>().Clear();
            spit.GetComponent<ParticleSystem>().Play();

            Physics.IgnoreCollision(GetComponent<Collider>(), spit.GetComponent<Collider>());
        }
        else
        {
            Debug.LogError("Trying to attack something that doesn not have health");
        }
    }

    protected override bool atDestination(Vector3 target)
    {
        
        target.y = transform.position.y;
        return Vector3.Distance(target, transform.position) < (range+agent.stoppingDistance);
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
}

