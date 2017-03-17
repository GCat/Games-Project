using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : MonoBehaviour, Grabbable
{

    private Quaternion rotation;

    // Use this for initialization
    void Start()
    {
        rotation = transform.rotation;
    }

    public bool canBuy()
    {
        return true;
    }
    public abstract void grab();

    //function to be called when released from hand
    public abstract void release(Vector3 vel);
}
