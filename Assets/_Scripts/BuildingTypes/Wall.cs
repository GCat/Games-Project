﻿using UnityEngine;
using System.Collections;
using System;

public class Wall : Building, Grabbable {

	// Use this for initialization
    public int cost_per_meter = 10;
    public bool held = false;

    private Transform turretB= null;
    private Transform turretA=null;
    private Transform wallSegment=null;
    public float adjustRange = 15.0f;
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (held)
        {
            if (highlight != null)
            {
                highlightCheck();
            }
        }
    }

    public override string getName()
    {
        return "Wall";
    }


    public override Vector3 getLocation()
    {
        return this.gameObject.transform.position;
    }

    public override bool canBuy()
    {
        if (!bought && (resourceCounter.faith >= faithCost()))
        {
            bought = true;
            resourceCounter.removeFaith(faithCost());
            return true;
        }
        return false;
    }

    private int faithCost()
    {
        return cost_per_meter;
    }

    public override void die()
    {
        Destroy(gameObject);
    }

    public override void create_building()
    {
       // WALL SNAPPING WITH EACH OTHER CODE HERE I FAILED MISERABLY
    }

    //Don't need this 
    public override void activate()
    {
        create_building();
        if (highlight != null) highlightDestroy();
        held = false;
    }

    //Don't need this
    public override void deactivate()
    {
    }

	void onCollisionEnter(Collision collision){
		Debug.Log("Sup");	
	}

    public void grab()
    {
        // Deactivate  collider and gravity
        if (highlight != null)
        {
            DestroyImmediate(highlight);
        }
        held = true;
        // highlight where object wiould place if falling straight down
        createHighlight();

        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;

    }
}