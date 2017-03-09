using UnityEngine;
using System.Collections;

public class IronMine : ResourceBuilding
{

    public override void create_building()
    {
        buildingName = "IRONMINE";
        resource_node = findNearestResourceNode();
        InvokeRepeating("incrementResource", 10.0f, 5.0f); // after 10 sec call every 5
    }
    
    public override void incrementResource()
    {
        if (resource_node == null)
        {
            return;
        }
        if (Vector3.Distance(transform.position, resource_node.transform.position) < resource_node.GetComponent<ResourceNode>().range)
        {
            StartCoroutine(ResourceGainText(resourceCounter.addIron(),"Iron"));
        }
    }

    public new void die()
    {
        Destroy(gameObject);
    }

}
