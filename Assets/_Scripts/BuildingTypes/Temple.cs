using UnityEngine;
using System.Collections;

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
        world.startGame(tablet);
        placed = true;
        spawnHumans();
        InvokeRepeating("incrementResource", 10.0f, 5.0f); // after 10 sec call every 5
        canBeGrabbed = false;
    }

    public bool isPlaced()
    {
        return placed;
    }

    public override void incrementResource()
    {
        if (!spawnedGarrison) spawnHumans();
        if (resourceCounter != null) resourceCounter.addFaith();
    }

    void spawnHumans()
    {
        Debug.Log("Spawning");
        Vector3 myLocation = gameObject.transform.position;
        Vector3 humanLocation;
        humanLocation = new Vector3(myLocation.x, myLocation.y, myLocation.z + 33);
        for (int i = 0; i < 5; i++)
        {
            Instantiate(Resources.Load("Characters/Human"), humanLocation, Quaternion.identity);
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
    public new void die()
    {
        this.enabled = false;
        world.stopGame();
    }


}
