using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapLocation : MonoBehaviour {

    public PlayerMovement movementManager;
    public bool snap_right = true;
    bool sentinel = false;
    public float last_press_time;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerExit(Collider other)
    {
        sentinel = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Snapping location");
        if (sentinel || (Time.time - last_press_time) < 1)
        {
            return;
        }
        sentinel = true;
        last_press_time = Time.time;
        if (other.tag == "Hand")
        {
            if (snap_right)
            {
                movementManager.snapRight();
            }
            else
            {
                movementManager.snapLeft();
            } 
        }
    }
}
