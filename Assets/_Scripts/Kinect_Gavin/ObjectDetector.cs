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

    private Vector3 maxRealCoord = new Vector3(-2000, -2000, -2000);
    private Vector3 minRealCoord = new Vector3(2000, 2000, 2000);
    private Vector3 worldSize = new Vector3(200, 100, 100);
    public GameObject bottomLeftCorner;
    private Vector3 bottomLeftCoord;
    void Start () {
        if (useTracking)
        {
            KinectTrackingLib.KinectTrackingLib.init();
            //InvokeRepeating("showColor",2.0f, 0.05f);
        }
        bottomLeftCoord = bottomLeftCorner.transform.position;
    }

    void FixedUpdate()
    {
       
    }

    void showColor()
    {
        KinectTrackingLib.KinectTrackingLib.show_color_stream();
    }

    void updateBounds(Vector3 realCoords)
    {
        if (realCoords.x > maxRealCoord.x)
        {
            maxRealCoord.x = realCoords.x;
        }
        if (realCoords.y > maxRealCoord.y)
        {
            maxRealCoord.y = realCoords.y;
        }
        if (realCoords.y > maxRealCoord.y)
        {
            maxRealCoord.y = realCoords.y;
        }

        if (realCoords.x < minRealCoord.x)
        {
            minRealCoord.x = realCoords.x;
        }
        if (realCoords.y < minRealCoord.y)
        {
            minRealCoord.y = realCoords.y;
        }
        if (realCoords.y < minRealCoord.y)
        {
            minRealCoord.y = realCoords.y;
        }

    }

    Vector3 convertRealToVirtual(Vector3 realCoord)
    {
        //make the scaled coord positive 0 to max
        Vector3 scaledCoord = realCoord + minRealCoord;

        scaledCoord.x /= maxRealCoord.x;
        scaledCoord.y /= maxRealCoord.y;
        scaledCoord.z /= maxRealCoord.z;
        scaledCoord.Scale(worldSize);
        return scaledCoord;
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
                break;
            case 3:
                //color data
                x = 0;
                y = 0;
                z = 0;
                KinectTrackingLib.KinectTrackingLib.track_hands();
                KinectTrackingLib.KinectTrackingLib.get_hand_location(ref x, ref y, ref z);
                Vector3 handLoc = new Vector3(z, y, x);
                updateBounds(handLoc);
                handLoc = convertRealToVirtual(handLoc);
                hand.transform.position = bottomLeftCoord + handLoc;
                
                //KinectTrackingLib.KinectTrackingLib.show_color_stream();
                break;
            default:
                break;
        }


    }
}
