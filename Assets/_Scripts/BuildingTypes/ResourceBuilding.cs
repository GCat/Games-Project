using UnityEngine;
using System.Collections;
using System;

public abstract class ResourceBuilding : Building, Grabbable
{ 
    public string buildingName;
    public bool on_game_board = false;
    public string required_resource_tag = "None";
    public GameObject resource_node;

    private float placementTime;

    public abstract void incrementResource();

    public override void die()
    {
        Destroy(gameObject, 0.5f);

    }

    public override string getName()
    {
        return buildingName;
    }

    public override Vector3 getLocation()
    {
        return this.gameObject.transform.position;
    }

    private void Start()
    {
        //boxSize = GetComponent<BoxCollider>().bounds.size / 2;
        //boxSize.y = 0.01f;
    }


    //fixedupdate can be run 100+ times per second...maybe this shouldn't be calling 'highlightcheck' here
    void Update()
    {
        if (held)
        {
            if (highlight != null)
            {
                highlightCheck();
            }
        }
    }

    //Don't need this 
    public override void activate()
    {
        if (!bought) resourceCounter.removeFaith(faithCost);
        create_building();
        held = false;
        highlightDestroy();
    }


    //Don't need this
    public override void deactivate()
    {
    }

    public void grab()
    {
        held = true;
        if (!bought)
        {
            bought = true;
            resourceCounter.removeFaith(faithCost);
        }

        // Deactivate  collider and gravity
        if (highlight != null)
        {
            DestroyImmediate(highlight);
        }
        // highlight where object wiould place if falling straight down
        createHighlight();

        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<BoxCollider>().enabled = false;

        //show highlights for corresponding resources
        if (required_resource_tag != "None")
        {
            foreach (GameObject n in resourceCounter.resource_nodes[required_resource_tag])
            {
                if (n.GetComponent<ResourceNode>() != null)
                {
                    n.GetComponent<ResourceNode>().showRange();
                }
            }
        }

    }




    public GameObject findNearestResourceNode()
    {
        if (required_resource_tag == "None")
        {
            return null;
        }
        float distance = float.MaxValue;
        GameObject chosenResource = null;
        Debug.Log(required_resource_tag);
        foreach (GameObject f in resourceCounter.resource_nodes[required_resource_tag])
        {
            if (Vector3.Distance(gameObject.transform.position, f.transform.position) < distance)
            {
                chosenResource = f;
            }
        }
        if (chosenResource == null)
        {
            Debug.Log("No " + required_resource_tag + " found");
        }
        else
        {
            Debug.Log("Found a " + required_resource_tag);
        }
        return chosenResource;
    }

    new void release(Vector3 vel)
    {
        base.release(vel);
        held = false;

    }
}
