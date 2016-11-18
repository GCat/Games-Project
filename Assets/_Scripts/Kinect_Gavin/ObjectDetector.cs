using UnityEngine;
using System;
using System.Runtime.InteropServices;
using UnityEngine.UI;


public class ObjectDetector : MonoBehaviour {


    public bool useTracking = true;
    // Use this for initialization
    void Start () {
        if (useTracking)
        {
            KinectTrackingLib.KinectTrackingLib.init();
        }
    }

    void FixedUpdate()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    }
}
