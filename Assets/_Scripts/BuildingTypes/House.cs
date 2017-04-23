using UnityEngine;
using System.Collections;
using System;
using UnityEngine.AI;

public class House : Building
{
    public GameObject humanSpawn;
    public GameObject heartEffect;
    public ParticleSystem smokeEffect;   
    public float humanSpawnDelay;
    Material matEmpty;
    Material matInval;
    public int spawnedPopulation;

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
        heartEffect = Resources.Load("Particles/Explosion_Lovely") as GameObject;
        boxSize = GetComponent<BoxCollider>().bounds.size / 2;
        boxSize.y = 0.01f;
        spawnedPopulation = 0;
    }

    // Spawning a human 
    private IEnumerator spawnHuman()
    {
        while (true)
        {
            yield return new WaitForSeconds(humanSpawnDelay);
            if (spawnedPopulation < 3)
            {
                Vector3 humanLocation = humanSpawn.transform.position;
                humanLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z + 10);
                NavMeshHit hit;
                if (NavMesh.SamplePosition(humanLocation, out hit, 30.0f, NavMesh.AllAreas))
                {
                    Debug.Log("Spawning a human");
                    GameObject thisHuman = Instantiate(Resources.Load("Characters/Human"), hit.position, Quaternion.identity) as GameObject;
                    thisHuman.GetComponent<Agent>().myHome = this;
                    Instantiate(heartEffect, transform.position + 5 * Vector3.up, Quaternion.identity);
                    StartCoroutine(ResourceGainText(1, "Chap")); 
                    spawnedPopulation++;
                }
                else Debug.Log("Could not spawn human");
            }
        }
    }

    public override void activate()
    {
        StartCoroutine(spawnHuman());

        if (highlight != null) highlightDestroy();
        //highlight = null;
        held = false;
        //ResourceGainText(1, "Chap");
    }


    new void release(Vector3 vel)
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
        spawnedFrom.amountSpawned--;
        Destroy(gameObject);
    }

    public override void create_building()
    {
    }

    public override void deactivate()
    {
    }
}
