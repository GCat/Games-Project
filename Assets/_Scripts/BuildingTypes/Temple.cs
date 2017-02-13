using UnityEngine;
using System.Collections;

public class Temple : ResourceBuilding {
    private WorldStarter world;
    public bool placed = false;

    public override void create_building()
    {
        this.timer = 0f;
        this.startTime = Time.time;
        this.health = 5000.0f;
        timeStep = 0.5f;
        buildingName = "TEMPLE";
        GameObject tablet = GameObject.Find("Resource_tablet");
        if (tablet != null) resourceCounter = (ResourceCounter)tablet.GetComponent<ResourceCounter>();
        else Debug.Log("Tablet not found");
        placed = true;

    }

    public bool isPlaced()
    {
        return placed;
    }

    void Update()
    {
        //If destroyed 
        if (this.gameObject == null)
        {
            world.stopGame();
        }

    }
    // Use this for initialization
    void Start()
    {
        //create_building();
    }
    public override void incrementResource()
    {
        if (resourceCounter != null) resourceCounter.addFaith();
    }

    public void OnTriggerEnter(Collider other){
        if(other.tag == "Table"){
            world.startGame();
        }
    }
}
