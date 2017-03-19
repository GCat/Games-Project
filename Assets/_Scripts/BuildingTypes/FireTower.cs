using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : Building, Grabbable
{

    public AudioClip build;
    public AudioClip destroy;
    public float fireDamagePerSecond = 5;
    GameObject rangeHighlight;
    public string buildingName;
    public GameObject target;
    public float radius = 25.0f;

    bool active = false;
    public bool held = false;

    private bool badplacement = false;
    private float placementTime = 0;

    int attackMask = 1 << 11;
    bool grabbedOnce = false;
    
    private GameObject currentTarget;
    public GameObject fireStream;

    float getHealth()
    {
        return health;
    }


    //never goes in here 
    public override void create_building()
    {

    }
    

    void Start()
    {
        Vector3 pos = transform.position;
        pos.y += 5;
        fireStream.SetActive(false);

        rangeHighlight = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        rangeHighlight.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
        rangeHighlight.transform.localScale = new Vector3(radius, 0.1f, radius);
        rangeHighlight.transform.position = new Vector3(gameObject.transform.position.x, 0.1f, gameObject.transform.position.z);
        rangeHighlight.transform.rotation = Quaternion.LookRotation(Vector3.forward);

        rangeHighlight.GetComponent<Collider>().enabled = false;
        rangeHighlight.GetComponent<Renderer>().enabled = true;
        rangeHighlight.SetActive(false);
    }


    void Update()
    {
        rangeHighlight.transform.position = new Vector3(gameObject.transform.position.x, 0.1f, gameObject.transform.position.z);
        if (held)
        {
            if (highlight != null)
            {
                highlightCheck();
                showRange();
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
        else if (badplacement)
        {
            if (Time.time - placementTime > 5.0f)
            {
                DestroyObject(gameObject);
            }
        }
        else if (active)
        {

            if (resourceCounter.getBaddies() > 0)
            {
                if (currentTarget == null)
                {
                    fireStream.SetActive(false);
                    acquireTarget();
                }else
                {
                    if (Vector3.Distance(currentTarget.transform.position, transform.position) < radius)
                    {
                        fireStream.SetActive(true);
                        fireStream.transform.LookAt(currentTarget.transform.position);
                    }else
                    {
                        fireStream.SetActive(false);
                    }
                }

            }else
            {
                fireStream.SetActive(false);
            }
        }
    }

    //find a new nearby monster to attack
    private bool acquireTarget()
    {
        List<Collider> hitColliders = new List<Collider>(Physics.OverlapSphere(transform.position, radius, attackMask));
        if (hitColliders.Count > 0)
        {
            Debug.Log("Acquired target");
            currentTarget = hitColliders[0].gameObject;
            return true;
        }

        return false;
    }

    private IEnumerator attack()
    {

        while (true)
        {
            if (currentTarget != null && Vector3.Distance(currentTarget.transform.position, transform.position) < radius)
            {
                HealthManager targetHealth = currentTarget.GetComponent<HealthManager>();
                if (targetHealth != null)
                {
                    targetHealth.decrementHealth(fireDamagePerSecond);
                }
            }
            yield return new WaitForSeconds(1);
        }
    }

    void OnDestroy()
    {
        if (rangeHighlight != null)
        {
            DestroyImmediate(rangeHighlight);
        }

    }

    public void grab()
    {
        showRange();
        grabbedOnce = true;
        held = true;
        badplacement = false;

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

    public override string getName()
    {
        return buildingName;
    }

    public override Vector3 getLocation()
    {
        return transform.position;
    }

    public override bool canBuy()
    {
        if (!bought && (resourceCounter.faith >= faithCost))
        {
            bought = true;
            return true;
        }
        return false;
    }

    public override void die()
    {
        Destroy(gameObject, 0.5f);
    }

    public override void activate()
    {
        resourceCounter.removeFaith(faithCost);
        active = true;
        if (highlight != null) Destroy(highlight);
        highlight = null;
        held = false;
        buildingName = "TOWER";
        hideRange();
        StartCoroutine(attack());
    }

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
}