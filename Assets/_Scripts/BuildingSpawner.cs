using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour {

    public GameObject buildingToSpawn;
    public ResourceCounter resources;
    public GameObject imgCanvas;
    private int buildingCost;
    private int buildingMask = (1 << 10) | (1 << 14);
	// Use this for initialization
	void Start () {
        InvokeRepeating("spawnBuilding", .1f, 5);
        if (buildingCost == 0) buildingCost = 20;
        resources = GameObject.FindGameObjectWithTag("Tablet").GetComponent<ResourceCounter>();
        imgCanvas = transform.GetChild(0).gameObject;
        imgCanvas.SetActive(false);
        GameObject building = Instantiate(buildingToSpawn, transform.position, Quaternion.identity);
        Building bScript = building.GetComponent<Building>();
        if(bScript != null)
        {
            buildingCost = bScript.faithCost;
        }
        else
        {
            LightningBolt light = building.GetComponent<LightningBolt>();
            if(light != null)
            {
                buildingCost = light.fCost;
            }
            else
            {
                Debug.LogError("OBJECT THAT IS NOT BUILDING OR LIGHTNING BOLT PLACED ON SPAWNER");
            }
        }
        DestroyImmediate(building);
    }

    private void spawnBuilding()
    {
        if (resources.faith < buildingCost)
        {
            imgCanvas.SetActive(true);
        }
        else
        {
            imgCanvas.SetActive(false);
            if (Physics.OverlapSphere(transform.position, 8.0f, buildingMask).Length == 0)
            {
                GameObject building = Instantiate(buildingToSpawn, transform.position, Quaternion.identity);
                building.transform.parent = transform;
            }
        }

    }

}
