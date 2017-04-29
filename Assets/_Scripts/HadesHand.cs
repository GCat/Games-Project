using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HadesHand : MonoBehaviour {

    Temple temple;
    AudioSource aSource;
	// Use this for initialization
	void Start () {
        temple = GameObject.FindGameObjectWithTag("Temple").GetComponent<Temple>();
        aSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            temple.decrementHealth(10);
            aSource.Play();
        }
        else if (other.gameObject.tag == "PlayerBody")
        {
            temple.decrementHealth(5);
            aSource.Play();
            Debug.Log("Hit body");
        }

    }
}
