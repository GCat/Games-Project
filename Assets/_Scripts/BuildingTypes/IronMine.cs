using UnityEngine;
using System.Collections;

public class IronMine : ResourceBuilding
{
    public override void create_building()
    {
        this.timer = 0f;
        this.startTime = Time.time;
        timeStep = 5.0f;
        buildingName = "IRONMINE";
        GameObject tablet = GameObject.Find("Resource_tablet");
        if (tablet != null) resourceCounter = (ResourceCounter)tablet.GetComponent<ResourceCounter>();
        else Debug.Log("Tablet not found");
        resource_node = findNearestResourceNode();
    }

    // Use this for initialization
    void Start()
    {
        //create_building();
    }
    public override void incrementResource()
    {
        if (resource_node == null)
        {
            return;
        }
        if (Vector3.Distance(transform.position, resource_node.transform.position) < resource_node.GetComponent<ResourceNode>().range)
        {
            resourceCounter.addIron();
        }
    }

}
