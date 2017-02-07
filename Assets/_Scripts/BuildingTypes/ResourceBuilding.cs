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

    private void Start()
    {
        GameObject tablet = GameObject.Find("Resource_tablet");
        badplacement = false;
        if (tablet != null) resourceCounter = (ResourceCounter)tablet.GetComponent<ResourceCounter>();
        else Debug.Log("Tablet not found");
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


    public void activate()
    {

        if (!badplacement)
        {
            startTime = Time.time;
            on_game_board = true;
            held = false;
            highlightDestroy();
        }
        
        //Debug.Log("Building placed");
    }
    void deactivate()
    {
        on_game_board = false;   
    }

    void grabbed()
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

    void release(Vector3 vel)
    {

        //Snap to grid
        float y = transform.position.y;
        float x = transform.position.x;
        float z = transform.position.z;
        int layerMask = (1 << 10);

        //test within table bounds
        if (GameBoard.withinBounds(transform.position))
        {
            GetComponent<BoxCollider>().enabled = true;
            if (Physics.CheckBox(new Vector3(Mathf.Floor(x), 0, Mathf.Floor(z)),boxSize, Quaternion.LookRotation(Vector3.forward), layerMask))
            {
                badplacement = true;
                held = false;
                placementTime = Time.time;
                GetComponent<BoxCollider>().enabled = false;
                highlightDestroy();
            }
            else
            {
                create_building();
            }
            
            transform.position = new Vector3(Mathf.Floor(x), 0, Mathf.Floor(z));
            transform.rotation = Quaternion.LookRotation(Vector3.forward);
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

    private void highlightDestroy()
    {
        if (highlight != null) Destroy(highlight);
    }
    private void highlightCheck()
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

    private void createHighlight()
    {
        highlight = GameObject.CreatePrimitive(PrimitiveType.Cube);
        highlight.GetComponent<Renderer>().material = matEmpty;
        highlight.transform.localScale = new Vector3(GetComponent<BoxCollider>().bounds.size.x, 0.1f, GetComponent<BoxCollider>().bounds.size.z);
        highlight.transform.position = new Vector3(Mathf.Floor(transform.position.x), 0.1f, Mathf.Floor(transform.position.z));
        highlight.transform.rotation = Quaternion.LookRotation(Vector3.forward);

        highlight.GetComponent<Collider>().enabled = false;
        highlight.GetComponent<Renderer>().enabled = false;
    }
}
