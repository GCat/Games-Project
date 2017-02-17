using UnityEngine;
using System.Collections;
using System;

public abstract class Building : MonoBehaviour, HealthManager{
    public abstract string getName();
    public abstract Vector3 getLocation();
    public abstract void create_building();
    public float totalHealth = 100.0f;
    public float health = 100.0f;
    public ResourceCounter resourceCounter;
    public GameObject tablet;
    GameObject healthBar;

    public abstract bool canBuy();

    public void decrementHealth(float damage)
    {
        health -= damage;
        float scale = (health / totalHealth) * 10f;
        healthBar.transform.localScale = Vector3.Lerp(healthBar.transform.localScale, new Vector3(1.0f,scale,1.0f), 2.0f * Time.deltaTime);
        if (health <= 0)
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
        createHealthBar();
    }

    public void createHealthBar()
    {
        Bounds dims = gameObject.GetComponent<Collider>().bounds;
        Vector3 actualSize = dims.size;
        healthBar = GameObject.Instantiate(Resources.Load("HealthBar")) as GameObject;
        healthBar.transform.position = gameObject.GetComponent<Collider>().transform.position;
        healthBar.transform.Translate(new Vector3(0, dims.size.y*1.5f, 0));
        healthBar.transform.localRotation = gameObject.transform.localRotation;
        healthBar.transform.Rotate(new Vector3(90, 0, 0));
        healthBar.transform.SetParent(gameObject.transform);
    }

    public abstract void die();
    public abstract void activate();
    public abstract void deactivate();
}
