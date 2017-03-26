using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Harpy : Monster
{
    public GameObject projectile;

    protected override void hit()
    {
        if (currentVictim == null)
        {
            Debug.Log("No current victim");
            return;
        }
        HealthManager victimHealth = currentVictim.GetComponent<HealthManager>();
        if (victimHealth != null)
        {
            GameObject spit = Instantiate(projectile, transform.position, transform.rotation);
            Vector3 direction = Vector3.Normalize(currentVictim.transform.position - transform.position) * 15;
            spit.GetComponent<Rigidbody>().velocity = direction;
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

