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

                if (x > -400 && x < 600 & z > 1000 && z < 2000)
                {
                    x = x + 400;
                    x = (x / 1000) * 200;
                    x -= 100;
                    z = z - 1000;
                    z = (z / 1000) * 100;
                    z -= 50;
                    y += 300;
                    y /= 100;
                    Vector3 handLoc = new Vector3(z, y, x);

                    hand.transform.position = handLoc;
                }



                KinectTrackingLib.KinectTrackingLib.show_color_stream();
                break;
            default:
                break;
        }


    }
}
