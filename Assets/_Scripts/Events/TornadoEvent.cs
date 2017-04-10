using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoEvent : WaveEvent {
    /// <summary>
    /// Tornado event creates a tornado in a random position, tornado damages both enemies and alies
    /// </summary>
    public bool eventFinished = false;
    public GameObject tornadoPrefab;
    private GameObject tornado;

    public override void startEvent()
    {
        Vector3 tornadoPos = Random.insideUnitCircle * 60;
        tornadoPos.y = 0.0f;
        tornado = GameObject.Instantiate(tornadoPrefab, tornadoPos, Quaternion.LookRotation(Vector3.up));
    }



}
