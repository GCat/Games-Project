using UnityEngine;
using System.Collections;
using System;

public abstract class Building : MonoBehaviour, HealthManager{ // this should also be placeable hence the grab and release will be written once
    public abstract string getName();
    public abstract Vector3 getLocation();
    public abstract void create_building();
    public float totalHealth = 100.0f;
    public float health = 100.0f;
    public ResourceCounter resourceCounter;
    public GameObject tablet;
    GameObject healthBar;
    private Vector3 boxSize;
    public GameObject highlight;
    public Material matEmpty;
    public Material matInval;
    public bool canBeGrabbed = true;

    public abstract bool canBuy();

    public void decrementHealth(float damage)
    {
        health -= damage;
        float scale = (health / totalHealth);
        healthBar.transform.localScale = new Vector3(1.0f, scale * 10f, 1.0f);
        if (scale != 0) healthBar.GetComponent<Renderer>().material.SetColor("_Color", new Color(1.0f-scale, scale, 0));

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
        boxSize = GetComponent<BoxCollider>().bounds.size / 2;
        boxSize.y = 0.01f;
    }

    //return true if within bounds & not above another building
    public bool canPlace()
    {
        float y = transform.position.y;
        float x = transform.position.x;
        float z = transform.position.z;

        int layerMask = 1 << 10;
        if (GameBoard.withinBounds(transform.position))
        {
            GetComponent<Collider>().enabled = true;
            if (Physics.CheckBox(new Vector3(Mathf.Floor(x), 0, Mathf.Floor(z)), boxSize, Quaternion.LookRotation(Vector3.forward), layerMask))
            {
                return false;
            }
            return true;
        }
        return false;
    }

    public void release(Vector3 vel)
    {
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Collider>().enabled = true;
        Debug.Log("Resource Building vel:" + vel);
        GetComponent<Rigidbody>().AddForce(vel, ForceMode.VelocityChange);
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

    public void highlightCheck()
    {
        if (transform.position.y > 0.0 && Mathf.Abs(transform.position.x) <= 50 && Mathf.Abs(transform.position.z) <= 100)
        {
            highlight.GetComponent<Renderer>().enabled = true;
            highlight.transform.position = new Vector3(Mathf.Floor(transform.position.x), 0.1f, Mathf.Floor(transform.position.z));
            highlight.transform.rotation = Quaternion.LookRotation(Vector3.forward);
            int layerMask = 1 << 10;
            if (Physics.CheckBox(new Vector3(Mathf.Floor(transform.position.x), 0, Mathf.Floor(transform.position.z)), boxSize, Quaternion.LookRotation(Vector3.forward), layerMask))
                highlight.GetComponent<Renderer>().material = matInval;
            else
                highlight.GetComponent<Renderer>().material = matEmpty;
        }
        else
        {
            highlight.GetComponent<Renderer>().enabled = false;
        }
    }

    public void highlightDestroy()
    {
        if (highlight != null) Destroy(highlight);
    }



    public void createHighlight()
    {
        highlight = GameObject.CreatePrimitive(PrimitiveType.Cube);
        highlight.GetComponent<Renderer>().material = matEmpty;
        highlight.transform.localScale = new Vector3(GetComponent<BoxCollider>().bounds.size.x, 0.1f, GetComponent<BoxCollider>().bounds.size.z);
        highlight.transform.position = new Vector3(Mathf.Floor(transform.position.x), 0.1f, Mathf.Floor(transform.position.z));
        highlight.transform.rotation = Quaternion.LookRotation(Vector3.forward);

        highlight.GetComponent<Collider>().isTrigger = true;
        highlight.GetComponent<Renderer>().enabled = false;
    }

    public abstract void die();

    //do we still need these functions
    public abstract void activate();  
    public abstract void deactivate();
}
