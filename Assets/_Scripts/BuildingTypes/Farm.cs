using UnityEngine;
using System.Collections;

public class Farm : ResourceBuilding
{
    private int fCost = 50;

    public new void die()
    {
        Destroy(gameObject);
    }

    public override int faithCost()
    {
        return fCost;
    }

    public override void create_building()
    {
        buildingName = "FARM";
        InvokeRepeating("incrementResource", 10.0f, 10.0f); // after 10 sec call every 10
    }

    public override void incrementResource()
    {
        resourceCounter.addFood();
    }
}
