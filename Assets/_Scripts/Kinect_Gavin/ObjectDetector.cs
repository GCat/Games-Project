using UnityEngine;
using System;
using System.Runtime.InteropServices;
using UnityEngine.UI;


public class ObjectDetector : MonoBehaviour {


    public GameObject testObject;
    public bool useTracking = true;
    public int trackedObjects = 0;
    private Vector3 velocity = Vector3.zero;
    public GameObject hand;
    public Vector3 playArea;
    // Use this for initialization
    bool calibrated = false;
    private Vector3 calib;
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
        float x = 0;
        float y = 0;
        float z = 0;
        int hr = KinectTrackingLib.KinectTrackingLib.poll_tracker();
        switch (hr)
        {
            case 1:
                //no data from kinect
                break;
            case 2:
                //depth data

                int count = KinectTrackingLib.KinectTrackingLib.get_tracked_objects_count();
                //Console.WriteLine("Tracked objects:" + count);
                if (count > 0)
                {
                    KinectTrackingLib.KinectTrackingLib.get_tracked_object_location(0, ref x, ref y, ref z);
                    //Console.WriteLine(x + "," + y + "," + z);
                }

                //Console.WriteLine(x + "," + y + "," + z);
                break;
            case 3:
                //color data
                x = 0;
                y = 0;
                z = 0;
                KinectTrackingLib.KinectTrackingLib.track_hands();
                KinectTrackingLib.KinectTrackingLib.get_hand_location(ref x, ref y, ref z);

                Vector3 handLoc = new Vector3(x, y, z);
                
                if(handLoc != Vector3.zero && !calibrated)
                {
                    Vector3 inv = new Vector3(1 / x, 1 / y, 1 / z);
                    calib =Vector3.Scale(playArea, inv);
                    calibrated = true;
                    Debug.Log("calibrated to" + handLoc);
                }
                handLoc = Vector3.Scale(handLoc, calib);
                hand.transform.position = Vector3.SmoothDamp(hand.transform.position,handLoc,ref velocity, 0.3f);
                KinectTrackingLib.KinectTrackingLib.show_color_stream();
                break;
            default:
                break;
        }


    }
}
