using UnityEngine;
using System.Collections;

public class House : MonoBehaviour
{
   
    private int capacity;      //size of house: bigger house => bigger capacity
    private int humans;        //human counter
    private float timer;       //spawning timer
    private float StartTime;
    private Vector3 position;  //positioning of house    
    public GameObject human;   //obj human

    public void new_House(int capacity, Vector3 position)
    {
        this.capacity = capacity;
        this.position = position;
        timer = 0f;
        humans = 0;
        StartTime = Time.time;
    }

    private void add_human()
    {
        if (humans <= capacity)
        {
            this.humans += 1;
        }
    }

    public int get_humans()
    {
        return humans;
    }

    public int get_capacity()
    {
        return capacity;
    }

    // Use this function for initialisation
    void Start()
    {
        Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), new Vector3(0, 0, 5), Quaternion.identity);
        new_House(2, new Vector3(0, 0, 0));
    }

    //Update is called once per frame
    void Update()
    {
        timer   = Time.time - StartTime;

        //Spawn human every min 
        if (timer >= 60)
        {
            spawn();
            StartTime = Time.time;
        }
    }

    void spawn()
    {
        Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), position, Quaternion.identity); // createPrimitive will be replaced by a human
    }
}
