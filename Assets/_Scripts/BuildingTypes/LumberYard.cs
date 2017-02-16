using UnityEngine;
using System.Collections;

public class LumberYard : ResourceBuilding
{
    public int fCost = 30;

    public override int faithCost()
    {
        return fCost;
    }

    public override void create_building()
    {
        this.timer = 0f;
        this.startTime = Time.time;
        timeStep = 2.0f;
        buildingName = "LUMBERYARD";
        resourceCounter = (ResourceCounter)GameObject.Find("Resource_tablet").GetComponent("ResourceCounter");
        resource_node = findNearestResourceNode();
    }

    // Use this for initialization
    void Start()
    {

    }
    public override void incrementResource()
    {
        if (resource_node == null)
        {
            return;
        }
        if (Vector3.Distance(transform.position, resource_node.transform.position) < resource_node.GetComponent<ResourceNode>().range)
        {
            resourceCounter.addWood();
        }
        else
        {
            Debug.Log("Out of range: " + resource_node.GetComponent<ResourceNode>().range + "<" + Vector3.Distance(transform.position, resource_node.transform.position));
        }
    }
}
