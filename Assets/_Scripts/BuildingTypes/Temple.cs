using UnityEngine;
using System.Collections;

public class Temple : ResourceBuilding {
    public WorldStarter world;
    public GameObject tablet;
    public bool placed = false;

    public override void create_building()
    {
        this.timer = 0f;
        this.startTime = Time.time;
        this.health = 500.0f;
        timeStep = 0.5f;
        buildingName = "TEMPLE";
        tablet = GameObject.Find("Resource_tablet");
        if (tablet != null) resourceCounter = (ResourceCounter)tablet.GetComponent<ResourceCounter>();
        else Debug.Log("Tablet not found");
    }

    public bool isPlaced()
    {
        return placed;
    }

    private void Update()
    {
        if (this.health <= 10 && placed)
        {
            this.enabled = false;
            world.stopGame();
        }
    }
    // Use this for initialization
    void Start()
    {
    }

    public override void incrementResource()
    {
        if (resourceCounter != null) resourceCounter.addFaith();
    }

    public void OnTriggerEnter(Collider other){
        if(other.tag == "Hand" && !placed){
            create_building();
            world.startGame(tablet);
            placed = true;
        }
    }
}
