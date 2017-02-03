using UnityEngine;
using System.Collections;

public class LumberYard : ResourceBuilding
{
    private GameObject forest;

    public override void create_building()
    {
        this.timer = 0f;
        this.startTime = Time.time;
        timeStep = 2.0f;
        buildingName = "LUMBERYARD";
        resourceCounter = (ResourceCounter)GameObject.Find("Resource_tablet").GetComponent("ResourceCounter");
        forest = findNearestForest();
    }

    // Use this for initialization
    void Start()
    {

    }
    public override void incrementResource()
    {
        if (forest == null)
        {
            return;
        }
        if (Vector3.Distance(transform.position, forest.transform.position) < 50)
        {
            resourceCounter.addWood();
        }
    }

    GameObject findNearestForest()
    {
        float distance = float.MaxValue;
        GameObject chosenForest = null;
        foreach (GameObject f in resourceCounter.forests) {
            if (Vector3.Distance(gameObject.transform.position, f.transform.position) < distance){
                chosenForest = f;
            }
        }
        if (chosenForest == null)
        {
            Debug.Log("No forest found");
        }
        else
        {
            Debug.Log("Found a forest");
        }
        return chosenForest;
    }
}
