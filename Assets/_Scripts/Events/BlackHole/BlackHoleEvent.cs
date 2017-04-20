using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleEvent : WaveEvent {

    public GameObject blackholePrefab;
    public GameObject blackhole;
    // Use this for initialization
    public override void startEvent()
    {
        Vector3 bhpos = Random.insideUnitCircle * 60;
        bhpos.y = 8.0f;
        GameObject.Instantiate(blackholePrefab, bhpos, Quaternion.identity);
    }
}
