using UnityEngine;
using System.Collections;

public class Farm : MonoBehaviour
{

    float timer;
    float startTime;
    public float timeStep;
    ResourceCounter resourceCounter;

    public void create_building()
    {
        this.timer = 0f;
        this.startTime = Time.time;
        timeStep = 1.0f;
        resourceCounter = (ResourceCounter)GameObject.Find("Resource_tablet").GetComponent("ResourceCounter");
    }

    // Use this for initialization
    void Start()
    {
        create_building();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer = Time.time - startTime;
        if (timer > timeStep)
        {
            incrementResource();
            startTime = Time.time;
        }

    }
    void incrementResource()
    {
        resourceCounter.addFood();
    }
}
