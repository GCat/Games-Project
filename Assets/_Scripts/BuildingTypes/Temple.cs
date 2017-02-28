using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Temple : ResourceBuilding
{

    public bool spawnedGarrison = false;
    public WorldStarter world;
    public bool placed = false;
    private int fCost = 0;


    public override int faithCost()
    {
        return fCost;
    }

    public override void create_building()
    {
        health = 500.0f;
        totalHealth = 500.0f;
        buildingName = "TEMPLE";
        Debug.Log(world);
        world.startGame();
        tablet.SetActive(true);
        placed = true;
        spawnHumans();
        InvokeRepeating("incrementResource", 5.0f, 0.1f); // after 10 sec call every 5
        canBeGrabbed = false;
        CancelInvoke("showStartOutline");
        CancelInvoke("removeOutline");
        resourceCounter.gameStart();

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

    public override void incrementResource()
    {
        if (!spawnedGarrison) spawnHumans();
        if (resourceCounter != null) StartCoroutine(ResourceGainText(resourceCounter.addFaith(),"Faith"));
    }

    private void showStartOutline()
    {
        foreach (Renderer renderer in child_materials)
        {
            renderer.material.shader = outlineShader;
            renderer.material.SetColor("_OutlineColor", Color.yellow);
        }   
    }

    void spawnHumans()
    {
        Vector3 myLocation = transform.position;
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
                }
                else
                    Debug.Log("Could not spawn human");
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
}
