using UnityEngine;
using System.Collections;
using System;

public abstract class Building : MonoBehaviour, HealthManager{
    public abstract string getName();
    public abstract Vector3 getLocation();
    public abstract void create_building();
    public float health = 100.0f;
    public ResourceCounter resourceCounter;
    public GameObject tablet;

    public abstract bool canBuy();

    public void decrementHealth(float damage)
    {
        health -= damage;
        if (health == 0)
        {
            die();
        }
    }

    private void Awake()
    {
        tablet = GameObject.FindGameObjectWithTag("Tablet");
        if (tablet != null)
        {
            resourceCounter = (ResourceCounter)tablet.GetComponent<ResourceCounter>();
        }
        else Debug.Log("Tablet not found");
    }

    public abstract void die();
    public abstract void activate();
    public abstract void deactivate();
}
