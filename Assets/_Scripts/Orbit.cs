using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

    private Vector3 vOffset;
    private float timestamp;

    // Use this for initialization
    void Start () {
        vOffset = transform.position;
        timestamp = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        float angle = (Time.time - timestamp) / 480.0f * 360.0f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.left);
        transform.position = q * vOffset;
        transform.rotation = q;
        transform.LookAt(transform.parent);

    }
}
