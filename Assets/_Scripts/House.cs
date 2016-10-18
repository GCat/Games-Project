using UnityEngine;
using System.Collections;

public class House : MonoBehaviour
{  
    private int capacity;      //size of house: bigger house => bigger capacity
    private int humans;        //human counter
    private double happiness;     //overall happiness of the house: the more crowded => less happy // this is a percentage
    private float timer;       //spawning timer
    private float StartTime;
    private Vector3 location;  //position of house    
    public GameObject human;   //obj human
    private bool full_house;   // flag of some sort 

    //Constructor of a House
    //capacity = number of humans a house can hold; location = location of a house
    public House(int capacity, Vector3 location)
    {
        placeHouse(capacity, location);
        this.capacity = capacity;
        this.location = location;
        full_house = false;
        timer = 0f;
        humans = 0;
        StartTime = Time.time;
    }

    // Generate house
    private void placeHouse(int capacity, Vector3 location)
    {
        Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), location, Quaternion.identity);
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

    // Use this function for initialisation
    void Start()
    {
        House house = new House(2, new Vector3(0, 0, 0));
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
            Vector3 location_human = new Vector3(location.x, location.y, (location.z + 5));
            Debug.Log("location of house:" +  location);
            Debug.Log(location_human.ToString("F4"));
            Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), location_human, Quaternion.identity); // createPrimitive will be replaced by a human
            add_human();
            update_happiness();
        }
        else full_house = true;
    }
}
