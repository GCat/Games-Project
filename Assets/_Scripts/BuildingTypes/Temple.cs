using UnityEngine;
using System.Collections;

public class Temple : ResourceBuilding {

    public bool spawnedGarrison = false;

    public override void create_building()
    {
        this.timer = 0f;
        this.startTime = Time.time;
        this.health = 5000.0f;
        timeStep = 0.5f;
        buildingName = "TEMPLE";
        GameObject tablet = GameObject.Find("Resource_tablet");
        if (tablet != null) resourceCounter = (ResourceCounter)tablet.GetComponent<ResourceCounter>();
        else Debug.Log("Tablet not found");
    }

    // Use this for initialization
    void Start()
    {
        //spawnHumans();
        //create_building();
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
            humanLocation = rotateAroundPivot(humanLocation, myLocation, new Vector3(0, (360/5), 0));
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


}
