using UnityEngine;
using System;
using System.Runtime.InteropServices;
using UnityEngine.UI;


public class ObjectDetector : MonoBehaviour {


    public GameObject testObject;
    public bool useTracking = true;
    public int trackedObjects = 0;
    private Vector3 velocity = Vector3.zero;
    // Use this for initialization
    void Start () {
        if (useTracking)
        {
            KinectTrackingLib.KinectTrackingLib.init();
            //InvokeRepeating("showColor",2.0f, 0.05f);
        }
    }

    void FixedUpdate()
    {
       
    }

    void showColor()
    {
        KinectTrackingLib.KinectTrackingLib.show_color_stream();
    }
    // Update is called once per frame
    void Update()
    {
        if (KinectTrackingLib.KinectTrackingLib.poll_tracker() == 0)
        {
            showColor();
            trackedObjects = KinectTrackingLib.KinectTrackingLib.get_tracked_objects_count();
            Vector3 testPoint = new Vector3(0, 0, 0);
            if (trackedObjects > 0)
            {
                KinectTrackingLib.KinectTrackingLib.get_tracked_object_location(0, ref testPoint.x, ref testPoint.y, ref testPoint.z);
                if (testPoint.magnitude > 1)
                {
                    testObject.transform.position = Vector3.SmoothDamp(testObject.transform.position, transform.position + testPoint / 50, ref velocity, 0.3f);
                }
            }

        }
    }
}
