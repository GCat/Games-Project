using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Minotaur : Monster
{
    private ParticleSystem smokeEffect;

    //can we make the spawn type an enum please xoxo
    public override void spawn()
    {
        GameObject smoke = Instantiate(Resources.Load("Explosion") as GameObject, transform);
        smokeEffect = smoke.GetComponent<ParticleSystem>();
        smokeEffect.Stop();
        base.spawn();
    }

    protected override void hit()
    {
        if (currentVictim == null)
        {
            Debug.Log("No current victim");
            return;
        }
        damageInRadius(5f);
        smokeEffect.Play();
    }
    protected override bool atDestination(Vector3 target)
    {
        return Vector3.Distance(target, transform.position) < (agent.stoppingDistance + 5);
    }

    private void damageInRadius(float radius)
    {
        int layerMask = 1 << 9;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider collider in hitColliders)
        {
            HealthManager health = collider.GetComponent<HealthManager>();
            if(health != null)
            {
                health.decrementHealth(strength);
            }
        }

    }
}

