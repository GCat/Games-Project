using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using System;

public class Temple : Building
{

    public bool spawnedGarrison = false;
    public WorldStarter world;
    public bool placed = false;

    public override void create_building()
    {
        world.startGame();
        tablet.SetActive(true);
        placed = true;
        spawnHumans();
        InvokeRepeating("incrementResource", 10.0f, 10.0f); // after 10 sec call every 5
        canBeGrabbed = false;
        CancelInvoke("showStartOutline");
        CancelInvoke("removeOutline");
        resourceCounter.gameStart();
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

    private void Start()
    {
        showStartOutline();
        InvokeRepeating("showStartOutline", 1, 1.0f);
        InvokeRepeating("removeOutline", 1.5f, 1.0f); 
    }

    public bool isPlaced()
    {
        return placed;
    }

    public void incrementResource()
    {
        if (resourceCounter != null) StartCoroutine(ResourceGainText(resourceCounter.addFaith(5),"Faith"));
    }


    void spawnHumans()
    {
        Vector3 myLocation = transform.position;
        Debug.Log("Spawning humans");

        // can not spawn on resource node
        Vector3 humanLocation;
        humanLocation = new Vector3(myLocation.x, myLocation.y, myLocation.z + 33);
        for (int i = 0; i < 5; i++)
        {
            if (resourceCounter.aboveBoard(myLocation))
            {
                NavMeshHit hit;
                if (NavMesh.SamplePosition(humanLocation, out hit, 50.0f, NavMesh.AllAreas))
                {
                    Instantiate(Resources.Load("Characters/Human"), hit.position, Quaternion.identity);
                }else
                {
                    Debug.Log("Could not spawn human");
                }
            }else
            {
                Debug.Log("Not above board");
            }
            humanLocation = rotateAroundPivot(humanLocation, myLocation, new Vector3(0, (360 / 5), 0));
        }
        spawnedGarrison = true;
    }
    Vector3 rotateAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        Vector3 dir = point - pivot;
        dir = Quaternion.Euler(angles) * dir;
        point = dir + pivot;
        return point;
    }

    //This stops the game
    public override void die()
    {
        this.enabled = false;
        world.stopGame();
        Destroy(gameObject);
    }

    public override string getName()
    {
        return "Temple";
    }

    public override Vector3 getLocation()
    {
        return transform.position;
    }

    public override void activate()
    {
        create_building();
        held = false;
        highlightDestroy();
    }

    public override void deactivate()
    {

    }
}
