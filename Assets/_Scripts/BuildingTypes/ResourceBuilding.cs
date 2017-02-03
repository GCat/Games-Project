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
        if (held)
        {
            if (highlight != null)
            {
                if (transform.position.y > 0.0 && Mathf.Abs(transform.position.x) <= 50 && Mathf.Abs(transform.position.z) <= 100)
                {
                    highlight.GetComponent<Renderer>().enabled = true;
                    highlight.transform.position = new Vector3(Mathf.Floor(transform.position.x), 0.1f, Mathf.Floor(transform.position.z));
                    highlight.transform.rotation = Quaternion.LookRotation(Vector3.forward);

                }
                else
                {
                    highlight.GetComponent<Renderer>().enabled = false;
                }
            }
        }
    }


    public void activate()
    {
        startTime = Time.time;
        on_game_board = true;
        held = false;
        if (highlight != null) Destroy(highlight);
        highlight = null;
        //Debug.Log("Building placed");
    }
    void deactivate()
    {
        on_game_board = false;   
    }

    void grabbed()
    {
        held = true;
        // Deactivate  collider and gravity
    

        // highlight where object wiould place if falling straight down
        Material mat = Resources.Load("Materials/highlight.mat") as Material;
        if (highlight != null)
        {
            DestroyImmediate(highlight);
        }
        highlight = GameObject.CreatePrimitive(PrimitiveType.Cube);
        highlight.GetComponent<Renderer>().material = mat;
        highlight.transform.localScale = new Vector3(GetComponent<BoxCollider>().bounds.size.x, 0.1f, GetComponent<BoxCollider>().bounds.size.z); 
        highlight.transform.position = new Vector3(Mathf.Floor(transform.position.x), 0.1f, Mathf.Floor(transform.position.z));
        highlight.transform.rotation = Quaternion.LookRotation(Vector3.forward);

        highlight.GetComponent<Collider>().enabled = false;
        highlight.GetComponent<Renderer>().enabled = false;

        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;

    }
    void release(Vector3 vel)
    {

        //Snap to grid
        float y = transform.position.y;
        float x = transform.position.x;
        float z = transform.position.z;

        //test within table bounds
        if(GameBoard.withinBounds(transform.position)) {
            transform.position = new Vector3(Mathf.Floor(x), 0, Mathf.Floor(z));
            transform.rotation = Quaternion.LookRotation(Vector3.forward);
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Collider>().enabled = true;
            create_building();
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Collider>().enabled = true;
            GetComponent<Rigidbody>().velocity = vel;
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
        foreach (GameObject f in resourceCounter.forests)
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
}
