using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchTower : Building, Grabbable
{

    public AudioClip build;
    public AudioClip destroy;

    GameObject rangeHighlight;

    public string buildingName;
    public GameObject target;
    private float radius = 25.0f;

    bool active = false;
    public bool held = false;

    public float timer1;
    private float StartTime1;

    private bool badplacement = false;
    private float placementTime = 0;

    int attackMask = 1 << 11;
    GameObject pre;
    bool grabbedOnce = false;

    private GameObject infoText;

    float getHealth()
    {
        return health;
    }

    //never goes in here 
    public override void create_building()
    {

    }

    public override void changeTextColour(Color colour)
    {
        if (infoText)
        {
            infoText.GetComponent<TextMesh>().GetComponent<Renderer>().material.SetColor("_Color", colour);
        }
    }

    void Start()
    {

        pre = Resources.Load("Arrow_Regular") as GameObject;
        infoText = createInfoText("FaithCost");
        setInfoText(infoText, faithCost);

        rangeHighlight = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        rangeHighlight.GetComponent<Renderer>().material.SetColor("_Color", new Color(0.0f,0.6f,0.0f,0.2f));
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

            if (resourceCounter.baddies > 0)
            {
                if (target != null)
                {
                    attack(target);
                }
                else
                {
                    acquireTarget();
                }

            }
        }
    }

    //find a new nearby monster to attack
    private bool acquireTarget()
    {
        List<Collider> hitColliders = new List<Collider>(Physics.OverlapSphere(transform.position, radius, attackMask));
        if (hitColliders.Count > 0)
        {
            target = hitColliders[0].gameObject;
            return true;
        }

        return false;
    }

    //fire an arrow at a target
    bool attack(GameObject victim)
    {
        if (victim != null)
        {
            timer1 = Time.time - StartTime1;
            if (timer1 >= 3)
            {
                throwArrow(victim);
                StartTime1 = Time.time;
                return true;
            }
        }
        return false;
    }

    void OnDestroy()
    {
        if(rangeHighlight != null)
        {
            DestroyImmediate(rangeHighlight);
        }

    }

    void throwArrow(GameObject victim)
    {
        if (victim != null)
        {
            Vector3 pos = transform.TransformPoint(GetComponent<BoxCollider>().center);
            pos.y = 10f;
            GameObject c = GameObject.Instantiate(pre, pos, Quaternion.LookRotation(victim.transform.position)) as GameObject;
            ((Arrow)(c.GetComponent(typeof(Arrow)))).attack(victim);
        }
    }

    public void grab()
    {
        showRange();
        grabbedOnce = true;
        held = true;
        badplacement = false;
        Destroy(infoText);

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
            resourceCounter.removeFaith(faithCost);
            bought = true;
            return true;
        }
        return false;
    }

    public override void die()
    {
        Destroy(gameObject);
    }

    public override void activate()
    {
        //when do you call create buiding for towers ? -- cost does not work 
        active = true;
        if (highlight != null) Destroy(highlight);
        highlight = null;
        held = false;
        buildingName = "TOWER";
        timer1 = 0f;
        StartTime1 = Time.time;
        hideRange();

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