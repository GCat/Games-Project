using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : WaveEvent
{

    /// <summary>
    /// BEES will attack for a limited amount of time after that all die to symbolize imminent extintion of all bees
    /// also to avoid events completly recking you.
    /// BEES will attack temple or humans, yet to be decided
    /// If target dies bee dies because if a bee strings you you die.
    /// It will be a simplified version of the badie AI but flying and with no need of the agent hopefully.
    /// </summary>
    /// 
    public Hades hades;
    public override void startEvent()
    {
        hades = GameObject.FindGameObjectWithTag("Hades").GetComponent<Hades>();
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        hades.comeAlive();
    }
}
