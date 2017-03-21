using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Building, Grabbable {

    public GameObject rangeHighlight;
    public float radius;
    public bool active = false;
    public bool held = false;
    public bool grabbedOnce = false;
    public GameObject currentTarget;
    public int attackMask = 1 << 11;


    float getHealth()
    {
        return health;
    }

    public override void Awake()
    {

        base.Awake();
        rangeHighlight = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        rangeHighlight.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
        rangeHighlight.transform.localScale = new Vector3(radius, 0.1f, radius);
        rangeHighlight.transform.position = new Vector3(gameObject.transform.position.x, 0.1f, gameObject.transform.position.z);
        rangeHighlight.transform.rotation = Quaternion.LookRotation(Vector3.forward);

        rangeHighlight.GetComponent<Collider>().enabled = false;
        rangeHighlight.GetComponent<Renderer>().enabled = true;
        rangeHighlight.SetActive(false);

    }

    // Update is called once per frame
    virtual public void Update () {
        rangeHighlight.transform.position = new Vector3(gameObject.transform.position.x, 0.1f, gameObject.transform.position.z);
        if (held)
        {
            if (highlight != null)
            {
                if (highlightCheck()) showRange();
                else hideRange();
            }
            else if (transform.position.y > 0f)
            {
                createHighlight();
                showRange();
            }
            else
            {
                hideRange();
            }
        }
        else if (active)
        {

            if (resourceCounter.getBaddies() > 0)
            {
                if (currentTarget == null)
                {
                    acquireTarget();
                }
            }
        }
    }

    // different towers can aquire targets differently
    public virtual bool acquireTarget()
    {
        return true;
    }
    public override bool canBuy()
    {
        return true;
    }

    public void grab()
    {
        showRange();
        grabbedOnce = true;
        held = true;

        // Deactivate  collider and gravity
        if (highlight != null)
        {
            DestroyImmediate(highlight);
        }

        // highlight where object wiould place if falling straight down
        createHighlight();

        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;

    }

    //function should be overriden by child
    public override string getName()
    {
        return "";
    }

    public override Vector3 getLocation()
    {
        return transform.position;
    }

    public override void activate() {} //function should be overriden by child

    public override void deactivate()
    {
        active = false;
    }

    public void showRange()
    {
        rangeHighlight.SetActive(true);

    }

    public void hideRange()
    {
        rangeHighlight.SetActive(false);

    }

    //never goes in here 
    public override void create_building()
    {

    }

    public override void die()
    {
        Destroy(gameObject);
    }

    new void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.gameObject.tag == "Hand" && grabbedOnce)
        {
            showRange();
        }
    }
    new void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        if (other.gameObject.tag == "Hand")
        {
            hideRange();
        }
    }

    new void release(Vector3 vel)
    {
        base.release(vel);
        hideRange();
    }

    void OnDestroy()
    {
        if (rangeHighlight != null)
        {
            DestroyImmediate(rangeHighlight);
        }

    }
}
