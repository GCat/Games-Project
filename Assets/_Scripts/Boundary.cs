using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour {

    private Renderer renderer;
	// Use this for initialization
	void Start () {
        renderer = gameObject.GetComponent<Renderer>();
        renderer.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            renderer.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hand")
        {
            renderer.enabled = false;
        }

    }
}
