using UnityEngine;
using System.Collections;

public class Houses : MonoBehaviour
{
    private int size;                                                           //size of house: bigger house => bigger capacity
    private int humans;                                                         //human counter
    private float timer = 0f;                                                   //spawning timer
    public GameObject human = GameObject.CreatePrimitive(PrimitiveType.Cube);   //obj human
    private Vector3 position = Vector3.zero;                                    //positioning of house    

    // Use this for initialization
    void Start()
    {
        //create a house when dropped
        Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), new Vector3(5,5,5), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //Spawn human 
        if (timer >= 2)
        {
            Instantiate(human, position, Quaternion.identity);

        } 
    }

    public int get_humans()
    {
        return humans;
    }

    public int get_size()
    {
        return size;
    }
}
