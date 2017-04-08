using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePortalEvent : WaveEvent {

    public override void startEvent()
    {
        Portal portal = GameObject.FindGameObjectWithTag("Portal").GetComponent<Portal>();
        portal.movePortal();
    }
}
