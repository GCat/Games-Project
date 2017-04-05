using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePortalEvent : Event {

    public override void startEvent()
    {
        Portal portal = GameObject.FindGameObjectWithTag("Portal").GetComponent<Portal>();
        portal.movePortal();
    }
}
