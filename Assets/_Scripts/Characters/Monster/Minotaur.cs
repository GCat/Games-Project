using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Minotaur : Monster
{
    private ParticleSystem smokeEffect;

    //can we make the spawn type an enum please xoxo
    void Awake()
    {
        //GameObject smoke = Instantiate(Resources.Load("Particles/Dirty_Explosion") as GameObject, transform.position, Quaternion.LookRotation(Vector3.up, Vector3.forward));
        //smoke.transform.parent = transform;
        //smokeEffect = smoke.GetComponent<ParticleSystem>();
        //smokeEffect.Stop();
    }

    public override void hit()
    {
        if (currentVictim == null)
        {
            Debug.Log("No current victim");
            
            return;
        }
        damageInRadius(5f + transform.lossyScale.z);
        //smokeEffect.Clear();
        //smokeEffect.Play();
    }

    protected override bool atDestination(Vector3 target)
    {
        return Vector3.Distance(target, transform.position) < (agent.stoppingDistance + 5);
    }
    private void damageInRadius(float radius)
    {
        int layerMask = 1 << 9;
        layerMask |= 1 << 10;
        Collider[] hitColliders = Physics.OverlapSphere(new Vector3(transform.position.x, 0.0f, transform.position.z),radius, layerMask);
        foreach(Collider collider in hitColliders)
        {
            HealthManager health = collider.gameObject.GetComponent<HealthManager>();
            if(health != null && collider.gameObject.GetComponent<Monster>() == null)
            {
                health.decrementHealth(strength);
            }
        }

    }
}

