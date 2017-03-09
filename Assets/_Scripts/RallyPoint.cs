using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RallyPoint : Building, Grabbable {

    public string buildingName;
    private int fCost = 0;

    public float timer1;
    private float StartTime1;

    bool active = false;
    public bool held = false;
    private bool badplacement = false;

    //private GameObject infoText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void grab()
    {
        held = true;
        badplacement = false;
        //Destroy(infoText);

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

    public override void create_building()
    {
        //
    }

    public override string getName()
    {
        return buildingName;
    }

    public override Vector3 getLocation()
    {
        return transform.position;
    }

    public override bool canBuy()
    {
        if (resourceCounter.faith >= fCost)
        {
            resourceCounter.removeFaith(fCost);
            return true;
        }
        return false;
    }

    public override void die()
    {
        Destroy(gameObject);
    }

    public override void activate()
    {
        active = true;
        if (highlight != null) Destroy(highlight);
        highlight = null;
        held = false;
        buildingName = "RALLY";
        timer1 = 0f;
        StartTime1 = Time.time;

    }

    public void createHighlight()
    {
        highlight = GameObject.CreatePrimitive(PrimitiveType.Cube);
        highlight.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        highlight.transform.localScale = new Vector3(GetComponent<BoxCollider>().bounds.size.x, 0.1f, GetComponent<BoxCollider>().bounds.size.z);
        highlight.transform.position = new Vector3(Mathf.Floor(transform.position.x), 0.1f, Mathf.Floor(transform.position.z));
        highlight.transform.rotation = transform.rotation;

        highlight.GetComponent<Collider>().isTrigger = true;
        highlight.GetComponent<Renderer>().enabled = false;
    }
    public override void deactivate()
    {
        active = false;
    }
}
