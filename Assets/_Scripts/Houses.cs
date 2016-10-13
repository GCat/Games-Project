using UnityEngine;
using System.Collections;

public class Houses : MonoBehaviour
{
   
    public class House {
        private int capacity;      //size of house: bigger house => bigger capacity
        private int humans;        //human counter
        private float timer;       //spawning timer
        private Vector3 position;  //positioning of house    

        public GameObject human = GameObject.CreatePrimitive(PrimitiveType.Cube);   //obj human

        public House(int capacity, Vector3 position)
        {
            this.capacity = capacity;
            this.position = position;
            timer = 0f;
            humans = 0;
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

    }

    //public House house;

    //// Use this for initialization
    //void Start()
    //{
    //    house = House()

    //    //create a house when dropped
    //    Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), new Vector3(0, 0, 5), Quaternion.identity);
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    timer += Time.deltaTime;

    //    //Spawn human 
    //    if (timer >= 2)
    //    {
    //        Instantiate(human, position, Quaternion.identity);

    //    } 
    //}
}
