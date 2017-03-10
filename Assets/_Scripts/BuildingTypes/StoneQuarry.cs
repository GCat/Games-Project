﻿using UnityEngine;
using System.Collections;
using System;

public class StoneQuarry : ResourceBuilding
{
    public override void create_building()
    {
        buildingName = "QUARRY";
        InvokeRepeating("incrementResource", 10.0f, 5.0f); // after 10 sec call every 4 
    }

 
    public override void incrementResource()
    {
        StartCoroutine(ResourceGainText(resourceCounter.addStone(),"Stone"));
    }

    public new void die()
    {
        Destroy(gameObject);
    }
}
