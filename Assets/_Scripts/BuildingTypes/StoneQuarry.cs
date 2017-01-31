using UnityEngine;
using System.Collections;
using System;

public class StoneQuarry : ResourceBuilding
{
    public override void create_building()
    {
        this.timer = 0f;
        this.startTime = Time.time;
        timeStep = 4.0f;
        buildingName = "QUARRY";
        GameObject tablet = GameObject.Find("Resource_tablet");
        if (tablet != null) resourceCounter = (ResourceCounter)tablet.GetComponent<ResourceCounter>();
    }

    // Use this for initialization
    void Start()
    {
        create_building();
    }
    public override void incrementResource()
    {
        //resourceCounter.addStone();
    }
}
