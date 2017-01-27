using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GameObject[] snap_locations;
    public GameObject kinect;
    public GameObject head;
    private int current_location_index = 0;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //move Kinect to next position clockwise
    public void snapRight()
    {
        int new_index = (current_location_index + 1) % (snap_locations.Length);
        Debug.Log("index: " + new_index);
        GameObject snap_location = snap_locations[new_index];
        current_location_index = new_index;
        kinect.transform.position = snap_location.transform.position;
        kinect.transform.rotation = snap_location.transform.rotation;
        head.transform.Rotate(Vector3.up, 90);
    }
    public void snapLeft()
    {
        int new_index = (current_location_index + (snap_locations.Length-1)) % (snap_locations.Length);
        Debug.Log("index: " + new_index);
        GameObject snap_location = snap_locations[new_index];
        current_location_index = new_index;
        kinect.transform.position = snap_location.transform.position;
        kinect.transform.rotation = snap_location.transform.rotation;
        head.transform.Rotate(Vector3.up, -90);


    }
}
