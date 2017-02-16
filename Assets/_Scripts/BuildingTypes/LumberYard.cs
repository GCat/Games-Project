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
        buildingName = "LUMBERYARD";
        resource_node = findNearestResourceNode();
        InvokeRepeating("incrementResource", 10.0f, 2.0f); // after 10 sec call every 4
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
