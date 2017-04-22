using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BeeAttack : WaveEvent
{

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
    public override void startEvent()
    {

        Vector3 spawnPos = GameObject.FindGameObjectWithTag("Portal").GetComponent<Portal>().spawnPos.transform.position;

        for (int s = 0; s < swarmSize; s++)
        {
            NavMeshHit hit;
            if (NavMesh.SamplePosition(spawnPos, out hit, 40.0f, NavMesh.AllAreas))
            {
                Instantiate(beePrefab, hit.position, Quaternion.LookRotation(Vector3.forward, Vector3.up));
            }
            else
            {
                Debug.LogError("Could not spawn monster");
            }

        }

    }
}
