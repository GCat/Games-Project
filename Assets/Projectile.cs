using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    //the thing that shot this
    public GameObject parent = null;

    public float destroyDelay = 0;
	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject != parent)
        {
            Destroy(gameObject, destroyDelay);
        }
    }
}
