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
        buildingName = "FARM";
        InvokeRepeating("incrementResource", 10.0f, 10.0f); // after 10 sec call every 4
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
