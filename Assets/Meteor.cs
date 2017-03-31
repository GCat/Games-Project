using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Projectile {
    public GameObject FireEffect;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void DestroyObject()
    {
        FireEffect.SetActive(true);
        Destroy(gameObject);
    }

    public  override void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Hand")
        {
            //do some maths to add the physics to it so you can bash them out 
        }
        else 
        {
            DestroyObject();
            //damage on builinds in a certain radius, death animation
        }
    }
}
