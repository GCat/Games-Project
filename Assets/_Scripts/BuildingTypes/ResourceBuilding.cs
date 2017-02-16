using UnityEngine;
using System.Collections;

public abstract class ResourceBuilding : MonoBehaviour, Building, Placeable
{
    public AudioClip build;
    public AudioClip destroy;
    public string buildingName;
    public float timer;
    public float startTime;
    public float timeStep;
    public ResourceCounter resourceCounter;
    public float health = 100.0f;
    public bool on_game_board = false;
    public bool held = false;
    GameObject highlight = null;
    public string required_resource_tag = "None";
    public  GameObject resource_node;

    private bool badplacement = false;
    private float placementTime;
    private Vector3 boxSize;
    Material matEmpty;
    Material matInval;

    public abstract void create_building();
    public abstract void incrementResource();
    public abstract int faithCost();

 
    string Building.getName()
    {
        return buildingName;
    }

    Vector3 Building.getLocation()
    {
        return this.gameObject.transform.position;
    }

    float getHealth()
    {
        return health;
    }
    private void Awake()
    {
        GameObject tablet = GameObject.FindGameObjectWithTag("Tablet");
        if (tablet != null)
        {
            resourceCounter = (ResourceCounter)tablet.GetComponent<ResourceCounter>();
            badplacement = false;
        }
        else Debug.Log("Tablet not found");
    }

    private void Start()
    {
      
        matEmpty = Resources.Load("Materials/highlight2") as Material;
        matInval = Resources.Load("Materials/highlight") as Material;
        boxSize = GetComponent<BoxCollider>().bounds.size / 2;
        boxSize.y = 0.01f;
    }
    public void decrementHealth(float damage) 
    {
        health -= damage;
        if (health <= 0)
        {
           
            AudioSource sc = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
            //sc.volume = 0.3f;
            //sc.PlayOneShot(destroy);
           // Debug.Log("Aduio playing");
            
            Destroy(gameObject);
        }
    }
    //fixedupdate can be run 100+ times per second...maybe this shouldn't be calling 'highlightcheck' here
    void FixedUpdate()
    {
        if (on_game_board)
        {
            timer = Time.time - startTime;
            if (timer > timeStep)
            {
                incrementResource();
                startTime = Time.time;
            }
        }
        else if (badplacement)
        {
            if (Time.time - placementTime > 5.0f)
            {
                DestroyObject(gameObject);
            }
        }
        else if (held)
        {
            if (highlight != null)
            {
                highlightCheck();
            }
        }
    }

    //Is there enough faith ..  to construct building
    public bool canBuy()
    {
        if (resourceCounter.faith >= faithCost())
        {
            resourceCounter.removeFaith(faithCost());
            return true;
        }
        return false;
    }

    //Do not need this function
    public void activate()
    {
        /*if (!badplacement)
        {
            if (canBuy())
            {
                startTime = Time.time;
                on_game_board = true;
                held = false;
                highlightDestroy();
            }else
            {
                Destroy(gameObject); // check if need to open hand and stuff
            }   
        }
        */
        //Debug.Log("RESOURCE W+ONE");
    }

    //Don't need this
    public void deactivate()
    {
        on_game_board = false;   
    }

    public void grab()
    {
        held = true;
        badplacement = false;
        // Deactivate  collider and gravity
    

        // highlight where object wiould place if falling straight down
        if (highlight != null)
        {
            DestroyImmediate(highlight);
        }
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

    public void release(Vector3 vel)
    {
        //Snap to grid
        float y = transform.position.y;
        float x = transform.position.x;
        float z = transform.position.z;
        int layerMask = (1 << 10);

        //test within table bounds
        if (GameBoard.withinBounds(transform.position))
        {
            bool success = true;
            GetComponent<BoxCollider>().enabled = true;
            if (Physics.CheckBox(new Vector3(Mathf.Floor(x), 0, Mathf.Floor(z)),boxSize, Quaternion.LookRotation(Vector3.forward), layerMask))
            {
                badplacement = true;
                held = false;
                placementTime = Time.time;
                GetComponent<BoxCollider>().enabled = false;
                highlightDestroy();
                success = false;
            }

            
            transform.position = new Vector3(Mathf.Floor(x), 0, Mathf.Floor(z));
            transform.rotation = Quaternion.LookRotation(Vector3.forward);
            if (success && canBuy())
            {
                create_building();
            }

            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;        
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Collider>().enabled = true;
            Debug.Log("Resource Building vel:" + vel);
            GetComponent<Rigidbody>().AddForce(vel, ForceMode.VelocityChange);
        }

        if (required_resource_tag != "None")
        {
            foreach (GameObject n in resourceCounter.resource_nodes[required_resource_tag])
            {
                n.GetComponent<ResourceNode>().hideRange();
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
