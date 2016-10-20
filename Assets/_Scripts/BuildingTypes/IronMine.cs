using UnityEngine;
using System.Collections;

public class IronMine : ResourceBuilding
{

    float timer;
    float startTime;
    ResourceCounter resourceCounter;

    public override void create_building()
    {
        this.timer = 0f;
        this.startTime = Time.time;
        timeStep = 5.0f;
        resourceCounter = (ResourceCounter)GameObject.Find("Resource_tablet").GetComponent("ResourceCounter");
    }

    // Use this for initialization
    void Start()
    {
        create_building();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer = Time.time - startTime;
        if (timer > timeStep)
        {
            incrementResource();
            startTime = Time.time;
        }

    }
    public override void incrementResource()
    {
        resourceCounter.addIron();
    }
}
