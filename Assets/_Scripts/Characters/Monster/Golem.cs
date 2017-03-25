using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Golem : Monster
{
    //can we make the spawn type an enum please xoxo
    public override void spawn()
    {
        base.spawn();
    }

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
            victimHealth.decrementHealth(strength);
        }
        else
        {
            Debug.LogError("Trying to attack something that doesn not have health");
        }
    }
}

