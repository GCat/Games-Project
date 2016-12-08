using UnityEngine;
using System.Collections;

public class House  : MonoBehaviour, Building
{  
    private int capacity;      //size of house: bigger house => bigger capacity
    private int humans;        //human counter
    private double happiness;     //overall happiness of the house: the more crowded => less happy // this is a percentage
    public float timer;       //spawning timer
    private float StartTime;
    public Vector3 location;  //position of house 
    private bool full_house;   // flag of some sort
    public ResourceCounter resourceCounter;
    private int foodCost = 10;

    //Constructor of a House
    //capacity = number of humans a house can hold; location = location of a house
    public void Awake()
    {
        capacity = 2;
        location = transform.position;
        full_house = false;
        timer = 0f;
        humans = 0;
        StartTime = Time.time;
    }

    public string getName()
    {
        return "house";
    }

    public Vector3 getLocation()
    {
        return this.gameObject.transform.position;
    }

    // Adding human to the count
    private void add_human()
    {
        humans += 1;
        resourceCounter.addPop();
    }

    private void update_happiness()
    {
        happiness = 100 - (humans * 100 / capacity);
    }

    // Get number of humans the house has 
    public int get_humans()
    {
        return humans;
    }

    // Get how many humans the house can hold 
    public int get_capacity()
    {
        return capacity;
    }

    // Get overall happiness of the house 
    public double get_happiness()
    {
        return happiness;
    }
    
    void Start()
    {
        location = this.transform.position;
        resourceCounter = (ResourceCounter)GameObject.Find("Resource_tablet").GetComponent("ResourceCounter");
    }

    //Update is called once per frame
    void FixedUpdate()
    {
        location = this.transform.position;
        //Calculate time
        timer   = Time.time - StartTime;

        //Spawn human every min 
        if (timer >= 10)
        {
            if (resourceCounter.getFood() > foodCost)
            {
                spawn();
            }
            StartTime = Time.time;
        }
    }

    // Spawning a human 
    private void spawn()
    {
        //should add a check to see if space to put human already taken 
        if (humans <= capacity)
        {

            Vector3 location_human = new Vector3(location.x, 0.5f, (location.z + 4));
            int layerMask = 1 << 8;
            Vector3 target = new Vector3(location_human.x, 0.05f, location_human.z);
            Collider[] obstacles = Physics.OverlapSphere(target, 0.05f, layerMask);
            if (obstacles.Length != 0)
            {
                string check = obstacles[0].gameObject.GetComponent<Cell>().getStatus();
								layerMask = ~layerMask;
								obstacles = Physics.OverlapSphere(location_human, 1.0f, layerMask);
								if (obstacles.Length != 0){
									if (check == "empty") Instantiate(Resources.Load("Human"), location_human, Quaternion.identity);
									else Debug.Log("Oops");
								}
            }
            add_human();
            update_happiness();
            resourceCounter.removeFood(foodCost);
        }
        else full_house = true;
    }

    private int coord2cellID(Vector3 coords)
    {
        int layerMask = 1 << 8;
        Vector3 target = new Vector3(coords.x, 0.05f, coords.z);

        Collider[] obstacles = Physics.OverlapSphere(target, 0.05f, layerMask);
        if (obstacles.Length != 0)
        {
            return obstacles[0].gameObject.GetComponent<Cell>().id;
        }
        return -1;
    }
}
