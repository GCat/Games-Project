using UnityEngine;
using System.Collections;
using System;

public class Wall : Building, Grabbable {

	// Use this for initialization
	public float health;
    public int cost_per_meter = 10;
    public bool held = false;
    private bool badplacement = false;
    private GameObject infoText;
    void Start () {
		health = 400;
        infoText = createInfoText("FaithCost");
        setInfoText(infoText, cost_per_meter);
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
        else if(badplacement)
        {
            DestroyObject(gameObject);
        }
    }

    public override string getName()
    {
        return "Wall";
    }

    public override void changeTextColour(Color colour)
    {
        infoText.GetComponent<TextMesh>().GetComponent<Renderer>().material.SetColor("_Color", colour);
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
        Destroy(infoText);
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
