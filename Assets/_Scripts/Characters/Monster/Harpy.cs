using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Harpy : Monster
{
    public GameObject projectile;

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
            GameObject spit = Instantiate(projectile, transform.position + Vector3.up*12f, transform.rotation);
            Vector3 direction = Vector3.Normalize(currentVictim.transform.position - transform.position) * 15;
            spit.GetComponent<Rigidbody>().velocity = direction;
            spit.GetComponent<ParticleSystem>().Clear();
            spit.GetComponent<ParticleSystem>().Play();

            Physics.IgnoreCollision(GetComponent<Collider>(), spit.GetComponent<Collider>());
            victimHealth.decrementHealth(strength);
        }
        else
        {
            Debug.LogError("Trying to attack something that doesn not have health");
        }
    }

    protected override bool atDestination(Vector3 target)
    {

        target.y = transform.position.y;
        return base.atDestination(target);
    }



}

