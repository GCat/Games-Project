using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : Monster {


    public override void hit()
    {
        if (currentVictim == null || Vector3.Distance(currentVictim.transform.position, transform.position) > agent.stoppingDistance + 10)
        {
            return;
        }
        HealthManager victimHealth = currentVictim.GetComponent<HealthManager>();
        if (victimHealth != null)
        {
            victimHealth.decrementHealth(strength);
        }
        else
        {
            Debug.LogError("Trying to attack something that doesn not have health");
        }
    }
}
