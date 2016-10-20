using UnityEngine;
using System.Collections;

public class House  : MonoBehaviour, Building
{  
    private int capacity;      //size of house: bigger house => bigger capacity
    private int humans;        //human counter
    private double happiness;     //overall happiness of the house: the more crowded => less happy // this is a percentage
    private float timer;       //spawning timer
    private float StartTime;
    private Vector3 location;  //position of house 
    private bool full_house;   // flag of some sort 

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
        
    }

    //Update is called once per frame
    void FixedUpdate()
    {
        //Calculate time
        timer   = Time.time - StartTime;

        //Spawn human every min 
        if (timer >= 60)
        {
            spawn();
            StartTime = Time.time;
        }
    }

    // Spawning a human 
    private void spawn()
    {
        //should add a check to see if space to put human already taken 
        if (humans <= capacity)
        {
            Vector3 location_human = new Vector3(location.x, location.y, (location.z + 1));
            Instantiate(Resources.Load("Human"), location_human, Quaternion.identity);
            add_human();
            update_happiness();
        }
        else full_house = true;
    }
}
