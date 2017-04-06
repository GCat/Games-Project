using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : Tower {
    public GameObject pivot;
    private Quaternion pivotRotation;
    private Rigidbody pivotRB;
    // Use this for initialization
    void Start () {
        pivotRB = pivot.GetComponent<Rigidbody>();
        pivotRotation = pivotRB.rotation;
        InvokeRepeating("fire", 2f, 4f);

    }

    // Update is called once per frame
    void LateUpdate () {
        //pivotRB.MoveRotation(pivotRotation);
    }

    void fire()
    {
        Debug.Log("Fire");
        //pivotRB.MoveRotation(pivotRB.rotation*Quaternion.Euler(0,0,60));
        pivotRB.AddTorque(new Vector3(0, 0, -500), ForceMode.Impulse);
    }
}
