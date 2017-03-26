﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBolt : Tool {

    GameObject flash;    

    // Use this for initialization
    void Start () {
        outlineShader = Shader.Find("Toon/Basic Outline");
        renderer = GetComponent<Renderer>();   
    }

    public override void release(Vector3 vel)
    {
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Collider>().enabled = true;
        GetComponent<Rigidbody>().velocity = vel;

        Vector3 releasedPoint = transform.position;
        Vector3 predictedPoint = releasedPoint + vel * Time.deltaTime;
        Vector3 straightLinePath = predictedPoint - releasedPoint;
        Quaternion rotation = Quaternion.LookRotation(straightLinePath);
        transform.rotation = rotation;
    }

    private void playDestructionEffect(ContactPoint hit)
    {
        GameObject resource = Resources.Load("Bolt flash") as GameObject;
        flash = GameObject.Instantiate(resource, hit.point, Quaternion.identity);
        Destroy(flash.gameObject, 2f);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground") {
            //look at this because im pretty sure we call the canbuy function --> pay 2ice ??? 
            resourceCounter.removeFaith(faithCost);
            int layerMask = 1 << 11;
            ContactPoint hit = col.contacts[0];
            renderer.enabled = false;
            GetComponent<Collider>().enabled = false;
            Collider[] damageZone = Physics.OverlapSphere(hit.point, damageRadius, layerMask);

            playDestructionEffect(hit);
            audioSource.PlayOneShot(powerClip, 0.8f);

            //Remove Health from monsters in damageZone
            for (int i=0; i < damageZone.Length; i++)
            {
                HealthManager victimHealth = damageZone[i].gameObject.GetComponent<HealthManager>();
                //we can probably do something cleaner than comparing name - maybe some enums for different character types
                if (victimHealth != null)
                {
                    victimHealth.decrementHealth(damage);
                }

            }
            Physics.IgnoreCollision(GetComponent<Collider>(), col.collider);

            Destroy(gameObject, 0.3f);      
        }
    }

 
    public void activate()
    {
        throw new NotImplementedException();
    }

}
