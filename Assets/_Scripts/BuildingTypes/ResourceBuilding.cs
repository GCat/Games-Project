using UnityEngine;
using System.Collections;

public abstract class ResourceBuilding : Building, Grabbable
{
    public AudioClip build;
    public AudioClip destroy;
    public string buildingName;
    
    public bool on_game_board = false;
    public bool held = false;
    public string required_resource_tag = "None";
    public  GameObject resource_node;

    private bool badplacement = false;
    private float placementTime;
    private Vector3 boxSize;

    public abstract void incrementResource();
    public abstract int faithCost();

    public override void die()
    {
        Destroy(gameObject);
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
        boxSize = GetComponent<BoxCollider>().bounds.size / 2;
        boxSize.y = 0.01f;
        badplacement = false;
    }


    //fixedupdate can be run 100+ times per second...maybe this shouldn't be calling 'highlightcheck' here
    void FixedUpdate()
    {
        if (held)
        {
            if (highlight != null)
            {
                highlightCheck();
            }
        }else if (badplacement)
        {
            if (Time.time - placementTime > 5.0f)
            {
                DestroyObject(gameObject);
            }
        }
        
    }

    //Is there enough faith ..  to construct building
    public override bool canBuy()
    {
        if (resourceCounter.faith >= faithCost())
        {
            resourceCounter.removeFaith(faithCost());
            return true;
        }
        return false;
    }

    //Do not need this function
    public override void activate()
    {
        create_building();
    }

    //Don't need this
    public override void deactivate()
    {
        //on_game_board = false;   
    }

    public void grab()
    {
        held = true;
        badplacement = false;
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

    public void highlightDestroy()
    {
        if (highlight != null) Destroy(highlight);
    }

    public void highlightCheck()
    {
        if (transform.position.y > 0.0 && Mathf.Abs(transform.position.x) <= 50 && Mathf.Abs(transform.position.z) <= 100)
        {
            highlight.GetComponent<Renderer>().enabled = true;
            highlight.transform.position = new Vector3(Mathf.Floor(transform.position.x), 0.1f, Mathf.Floor(transform.position.z));
            highlight.transform.rotation = Quaternion.LookRotation(Vector3.forward);
            int layerMask = 1 << 10;
            if (Physics.CheckBox(new Vector3(Mathf.Floor(transform.position.x), 0, Mathf.Floor(transform.position.z)), boxSize, Quaternion.LookRotation(Vector3.forward), layerMask))
                highlight.GetComponent<Renderer>().material = matInval;
            else
                highlight.GetComponent<Renderer>().material = matEmpty;
        }
        else
        {
            highlight.GetComponent<Renderer>().enabled = false;
        }
    }

    public void createHighlight()
    {
        Debug.Log("Create highlight");
        highlight = GameObject.CreatePrimitive(PrimitiveType.Cube);
        highlight.GetComponent<Renderer>().material = matEmpty;
        highlight.transform.localScale = new Vector3(GetComponent<BoxCollider>().bounds.size.x, 0.1f, GetComponent<BoxCollider>().bounds.size.z);
        highlight.transform.position = new Vector3(Mathf.Floor(transform.position.x), 0.1f, Mathf.Floor(transform.position.z));
        highlight.transform.rotation = Quaternion.LookRotation(Vector3.forward);

        highlight.GetComponent<Collider>().enabled = false;
        highlight.GetComponent<Renderer>().enabled = false;
    }
    public bool getbp()
    {
        return badplacement;
    }
}
