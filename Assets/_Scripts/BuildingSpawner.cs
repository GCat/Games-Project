using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour {

    public GameObject buildingToSpawn;
    private int buildingMask = (1 << 10) | (1 << 14);
	// Use this for initialization
	void Start () {
        InvokeRepeating("spawnBuilding", .1f, 5);
    }

    private void spawnBuilding()
    {

        if(Physics.OverlapSphere(transform.position, 8.0f, buildingMask).Length == 0)
        {
            GameObject building = Instantiate(buildingToSpawn, transform.position, Quaternion.identity);
            building.transform.parent = transform;
        }

    }

}
