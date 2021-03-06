﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swatter : Tool {
    private bool enemyHit = false;
    private float damage = 2.5f;
    private GameObject ExplosionEffect;

	// Use this for initialization
	void Start () {
        ExplosionEffect = Resources.Load("Particles/Explosion") as GameObject;
        if (ExplosionEffect != null)
        {
            Debug.Log("Effect loaded");
        }
    }

    public override string getName()
    {
        return "Swatter";
    }

    // Update is called once per frame
    void Update () {

    }

    public override void grab()
    {
        held = true;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;
    }

    public override void release(Vector3 vel)
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Collider>().enabled = true;
        GetComponent<Rigidbody>().AddForce(vel, ForceMode.VelocityChange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Badies") && (!enemyHit))
        {
            HealthManager victimHealth = other.gameObject.GetComponent<HealthManager>();
            if (victimHealth != null)
            {
                victimHealth.decrementHealth(damage);
            }
            GameObject explosion = GameObject.Instantiate(ExplosionEffect);
            explosion.transform.position = transform.position;
            Destroy(explosion, 1.0f);
            enemyHit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Badies")
        {
            enemyHit = false;
        }
    }
}
