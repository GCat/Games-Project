using UnityEngine;
using System.Collections;
using System;

public class Wall : Building, Grabbable {

	// Use this for initialization
	public float health;
    public int cost_per_meter = 10;
	void Start () {
		health = 400;
	}
	
	// Update is called once per frame
	void Update () {
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
        if (resourceCounter.faith >= faithCost())
        {
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

    }
    //Don't need this 
    public override void activate()
    {
        create_building();
    }

    //Don't need this
    public override void deactivate()
    {
    }



    public void decrementHealth(float damage){
		health -= damage;
		if (health <= 0){
			Destroy(gameObject);
		}
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

        // highlight where object wiould place if falling straight down
        createHighlight();

        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;

    }
}
