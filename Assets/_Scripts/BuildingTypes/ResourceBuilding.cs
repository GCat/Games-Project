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
    }

    void OnDrawGizmos()
    {
        if (held)
        {
            Debug.Log("HERE");
            Gizmos.color = new Color(1, 0, 0, 0.5F);
            Vector3 p = new Vector3(transform.position.x, 0.0f, transform.position.z);
            Vector3 objectSize = new Vector3(10f,2f,10f);
            Gizmos.DrawCube(p, objectSize);

        }
        
    }
    void activate()
    {
        startTime = Time.time;
        on_game_board = true;
        held = false;
        Debug.Log("Building placed");
    }
    void deactivate()
    {
        on_game_board = false;   
    }

    void grabbed()
    {
        held = true;
    }
}
