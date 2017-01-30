using UnityEngine;
using System.Collections;

public abstract class ResourceBuilding : MonoBehaviour, Building
{
    public string buildingName;
    public float timer;
    public float startTime;
    public float timeStep;
    public ResourceCounter resourceCounter;
    public float health = 100.0f;
    public bool on_game_board = false;
    public bool held = false;
    GameObject highlight = null; 

    public abstract void create_building();
    public abstract void incrementResource();
    string Building.getName()
    {
        return buildingName;
    }
    Vector3 Building.getLocation()
    {
        return this.gameObject.transform.position;
    }
    float getHealth()
    {
        return health;
    }
    public void decrementHealth(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        if (on_game_board)
        {
            timer = Time.time - startTime;
            if (timer > timeStep)
            {
                incrementResource();
                startTime = Time.time;
            }
        }
        if (held)
        {
            if (highlight != null)
            {
                if (transform.position.y > 0.0 && Mathf.Abs(transform.position.x) <= 50 && Mathf.Abs(transform.position.z) <= 100)
                {
                    highlight.GetComponent<Renderer>().enabled = true;
                    highlight.transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
                }
                else
                {
                    highlight.GetComponent<Renderer>().enabled = false;
                }
            }
        }
    }


    void activate()
    {
        startTime = Time.time;
        on_game_board = true;
        held = false;
        if (highlight != null) Destroy(highlight);
        highlight = null;
        Debug.Log("Building placed");
    }
    void deactivate()
    {
        on_game_board = false;   
    }

    void grabbed()
    {
        held = true;

        highlight = GameObject.CreatePrimitive(PrimitiveType.Cube);
        highlight.transform.localScale = new Vector3(GetComponent<BoxCollider>().bounds.size.x, 0.1f, GetComponent<BoxCollider>().bounds.size.z); 
        highlight.transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
        highlight.GetComponent<Collider>().enabled = false;
        highlight.GetComponent<Renderer>().enabled = false;

    }
}
