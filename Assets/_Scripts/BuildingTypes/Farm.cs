using UnityEngine;
using System.Collections;

public class Farm : ResourceBuilding
{
    public new void die()
    {
        Destroy(gameObject);
    }

    public override void create_building()
    {
        buildingName = "FARM";
        InvokeRepeating("incrementResource", 10.0f, 5.0f); // after 10 sec call every 10
    }

    public override void incrementResource()
    {
        StartCoroutine(ResourceGainText(resourceCounter.addFood(),"Food"));
    }
}
