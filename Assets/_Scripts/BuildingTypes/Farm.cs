using UnityEngine;
using System.Collections;

public class Farm : ResourceBuilding
{
    public override void create_building()
    {
        this.timer = 0f;
        this.startTime = Time.time;
        timeStep = 1.0f;
        buildingName = "FARM";
        resourceCounter = (ResourceCounter)GameObject.Find("Resource_tablet").GetComponent("ResourceCounter");
    }

    // Use this for initialization
    void Start()
    {
        create_building();
    }
    public override void incrementResource()
    {
        resourceCounter.addFood();
    }
}
