using UnityEngine;
using System.Collections;

public abstract class ResourceBuilding : MonoBehaviour {

    float timer;
    float startTime;
    public float timeStep;
    ResourceCounter resourceCounter;

    public abstract void create_building();

	// Use this for initialization
	void Start () {
        create_building();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        timer = Time.time - startTime;
        if (timer > timeStep)
        {
            incrementResource();
            startTime = Time.time;
        }

    }
    public abstract void incrementResource();
}
