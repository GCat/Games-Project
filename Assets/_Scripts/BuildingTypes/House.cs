using UnityEngine;
using System.Collections;
using System;
using UnityEngine.AI;

public class House  : Building, Grabbable
{

    public AudioClip build;
    public AudioClip destroy;

    public ParticleSystem smokeEffect;
    private int capacity;      //size of house: bigger house => bigger capacity
    private int humans;        //human counter
    private double happiness;     //overall happiness of the house: the more crowded => less happy // this is a percentage
    public float timer;       //spawning timer
    private float StartTime;
    public Vector3 location;  //position of house 
    private bool full_house;   // flag of some sort
    private int foodCost = 10;
    private int faithCost = 1;


    public bool active = false;
    public bool held = false;
    GameObject highlight = null;
    private bool badplacement = false;
    private float placementTime;
    private Vector3 boxSize;


    Material matEmpty;
    Material matInval;

    //Constructor of a House
    //capacity = number of humans a house can hold; location = location of a house
    public void Awake()
    {
        badplacement = false;
        capacity = 2;
        location = transform.position;
        full_house = false;
        timer = 0f;
        humans = 0;
        StartTime = Time.time;
        smokeEffect.Stop();
        createHealthBar();
        createInfoText();

    }

    public override string getName()
    {
        return "house";
    }

    public override Vector3 getLocation()
    {
        return this.gameObject.transform.position;
    }
    float getHealth()
    {
        return health;
    }
 
    // Adding human to the count
    private void add_human()
    {
        humans += 1;
    }

    private void update_happiness()
    {
        happiness = 100 - (humans * 100 / capacity);
    }

    // Get number of humans the house has 
    public int get_humans()
    {
        return humans;
    }

    // Get how many humans the house can hold 
    public int get_capacity()
    {
        return capacity;
    }

    // Get overall happiness of the house 
    public double get_happiness()
    {
        return happiness;
    }
    
    void Start()
    {
        location = this.transform.position;
        matEmpty = Resources.Load("Materials/highlight2") as Material;
        matInval = Resources.Load("Materials/highlight") as Material;
        boxSize = GetComponent<BoxCollider>().bounds.size / 2;
        boxSize.y = 0.01f;
    }

    //Update is called once per frame
    void FixedUpdate()
    {
        if (held)
        {
            if (highlight != null)
            {
                highlightCheck();
            }
        }
        else if (badplacement)
        {
            if (Time.time - placementTime > 5.0f)
            {
                DestroyObject(gameObject);
            }
        }
        else if (active)
        {
            location = this.transform.position;
            //Calculate time
            timer = Time.time - StartTime;

            if (timer >= 3)
            {
               if (resourceCounter.getFood() > foodCost) spawn();
            }
        }
    }

    // Spawning a human 
    private void spawn()
    {
        //should add a check to see if space to put human already taken 
        if (humans <= capacity)
        {

            Vector3 location_human = new Vector3(location.x, 0.5f, (location.z + 4));
            Vector3 target = new Vector3(location_human.x, 0.05f, location_human.z);
            NavMeshHit hit;
            //spawn human in nearest valid nav mesh point
            Vector3 spawnPosition = transform.position;
            if (resourceCounter.aboveBoard(transform.position))
            {
                if (NavMesh.SamplePosition(transform.position, out hit, 20.0f, NavMesh.AllAreas))
                {
                    spawnPosition = hit.position;
                    Instantiate(Resources.Load("Characters/Human"), spawnPosition, Quaternion.identity);
                }
                else
                {
                    Debug.Log("Spawn Human Failed");
                }
            }
            else
            {
                Debug.Log("House Off Bounds");
            }
            

            add_human();
            update_happiness();
            resourceCounter.removeFood(foodCost);
        }
        else full_house = true;
    }

    public override void activate()
    {
        if (!badplacement)
        {
            active = true;
            held = false;
            highlightDestroy();
            StartTime = Time.time;
        }
    }
    public override void deactivate()
    {
        active = false;
    }
    public void grab()
    {
        badplacement = false;
        held = true;
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
            if (Physics.CheckBox(new Vector3(Mathf.Floor(x), 0, Mathf.Floor(z)), boxSize, Quaternion.LookRotation(Vector3.forward), layerMask))
            {
                badplacement = true;
                held = false;
                placementTime = Time.time;
                GetComponent<Collider>().enabled =false;
                highlightDestroy();
            }
            transform.position = new Vector3(Mathf.Floor(x), 0, Mathf.Floor(z));
            transform.rotation = Quaternion.LookRotation(Vector3.forward);
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = false;
            smokeEffect.Play();
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Collider>().enabled = true;
            Debug.Log("House vel:" + vel);
            GetComponent<Rigidbody>().AddForce(vel, ForceMode.VelocityChange);
        }
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
            if(Physics.CheckBox(new Vector3(Mathf.Floor(transform.position.x), 0, Mathf.Floor(transform.position.z)), boxSize, Quaternion.LookRotation(Vector3.forward), layerMask))
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

        highlight.GetComponent<Collider>().isTrigger = true;
        highlight.GetComponent<Renderer>().enabled = false;
    }

    public override void die()
    {
        Destroy(gameObject);
    }

    public override void create_building()
    {
        //
    }

    public override bool canBuy()
    {
        if (resourceCounter.faith >= faithCost)
        {
            resourceCounter.removeFaith(faithCost);
            return true;
        }
        return false;
    }
}
