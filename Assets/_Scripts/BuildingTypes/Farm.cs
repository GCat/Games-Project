using UnityEngine;
using System.Collections;

public class Farm : ResourceBuilding
{
    public int fCost = 10;

    public override int faithCost()
    {
        return fCost;
    }

    public override void create_building()
    {
        Debug.Log("CREATING FARM");
        this.timer = 0f;
        this.startTime = Time.time;
        timeStep = 1.0f;
        buildingName = "FARM";
        resourceCounter = (ResourceCounter)GameObject.Find("Resource_tablet").GetComponent("ResourceCounter");
    }

    // Use this for initialization
    void Start()
    {
    }

    public override void incrementResource()
    {
        resourceCounter.addFood();
    }
}
