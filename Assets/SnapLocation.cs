using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapLocation : MonoBehaviour {

    public PlayerMovement movementManager;
    public bool snap_right = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            Debug.Log("Snapping location");
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
