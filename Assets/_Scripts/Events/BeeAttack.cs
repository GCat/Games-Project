using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeAttack : Event {

    /// <summary>
    /// BEES will attack for a limited amount of time after that all die to symbolize imminent extintion of all bees
    /// also to avoid events completly recking you.
    /// BEES will attack temple or humans, yet to be decided
    /// If target dies bee dies because if a bee strings you you die.
    /// It will be a simplified version of the badie AI but flying and with no need of the agent hopefully.
    /// </summary>
    /// 
    public int swarmSize;
    public GameObject beePrefab;
    public override void startEvent(){
        GameObject temple = GameObject.FindGameObjectWithTag("Temple");
        Vector3 tPost = temple.transform.position;
        Vector3 spawnLocation = GameObject.FindGameObjectWithTag("Portal").transform.position;
        spawnLocation.y = 30f;
        spawnLocation.x += Random.Range(-20, 20);
        spawnLocation.z += Random.Range(-20, 20);
        if (temple != null)
        {
            for (int s= 0; s< swarmSize; s++ )
            {
                GameObject bee = GameObject.Instantiate(beePrefab, spawnLocation, Quaternion.identity);
                Vector3 attackPoint = temple.GetComponent<Collider>().ClosestPointOnBounds(spawnLocation);
                bee.GetComponent<Bee>().Spawn(temple, 2f, attackPoint);
                spawnLocation.x += Random.Range(-10, 10);
                spawnLocation.z += Random.Range(-10, 10);
            }
        }
    }
}
