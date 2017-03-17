using UnityEngine;
using System.Collections;
using System;
using UnityEngine.AI;

public class House : Building, Grabbable
{

    public AudioClip build;
    public AudioClip destroy;
    public GameObject humanSpawn;
    public ParticleSystem smokeEffect;
    public int capacity = 5;      //size of house: bigger house => bigger capacity
    public int inhabitants = 0;        //human counter
    public int foodCost = 10;
    public bool active = false;
    public bool held = false;
    private float placementTime = 0;
    private Vector3 boxSize;
    Material matEmpty;
    Material matInval;
    
    //Constructor of a House
    //capacity = number of humans a house can hold; location = location of a house


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

    void Start()
    {
        matEmpty = Resources.Load("Materials/highlight2") as Material;
        matInval = Resources.Load("Materials/highlight") as Material;
        boxSize = GetComponent<BoxCollider>().bounds.size / 2;
        boxSize.y = 0.01f;
    }

    // Spawning a human 
    private IEnumerator spawnHuman()
    {
        while (active)
        {
            yield return new WaitForSeconds(15f);
            Vector3 humanLocation = humanSpawn.transform.position;
            humanLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z + 10);
            NavMeshHit hit;
            if (NavMesh.SamplePosition(humanLocation, out hit, 30.0f, NavMesh.AllAreas))
            {
                Debug.Log("Spawning a human");
                Instantiate(Resources.Load("Characters/Human"), hit.position, Quaternion.identity);
                StartCoroutine(ResourceGainText(1, "Chap"));
            }
            else
                Debug.Log("Could not spawn human");

        }
    }

    public override void activate()
    {
        resourceCounter.removeFaith(faithCost);
        StartCoroutine(spawnHuman());
        //when do you call create buiding for towers ? -- cost does not work 
        active = true;
        if (highlight != null) highlightDestroy();
        //highlight = null;
        held = false;
        //ResourceGainText(1, "Chap");
    }
    public override void deactivate()
    {
        active = false;
    }
    public void grab()
    {
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
                held = false;
                placementTime = Time.time;
                GetComponent<Collider>().enabled = false;
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

    public override void die()
    {
        Destroy(gameObject);
    }

    public override bool canBuy()
    {
        if (!bought && (resourceCounter.faith >= faithCost))
        {
            bought = true;
            return true;
        }
        return false;
    }

    public override void create_building()
    {
    }
}
