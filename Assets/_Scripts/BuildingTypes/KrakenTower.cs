using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenTower : Building, Grabbable
{

    public AudioClip build;
    public AudioClip destroy;
    public LineRenderer linerenderer;
    public GameObject mirror;
    public float damage_per_second = 10;
    GameObject rangeHighlight;
    private Animation anim;

    public string buildingName;
    public GameObject target;
    private float radius = 15.0f;

    bool active = false;
    public bool held = false;

    public float timer1;
    private float StartTime1;

    private bool badplacement = false;
    private float placementTime = 0;

    int attackMask = 1 << 11;
    bool grabbedOnce = false;
    

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

        rangeHighlight = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        rangeHighlight.GetComponent<Renderer>().material.SetColor("_Color", new Color(0.0f, 0.6f, 0.0f, 0.2f));
        rangeHighlight.transform.localScale = new Vector3(radius, 0.1f, radius);
        rangeHighlight.transform.position = new Vector3(gameObject.transform.position.x, 0.1f, gameObject.transform.position.z);
        rangeHighlight.transform.rotation = Quaternion.LookRotation(Vector3.forward);

        rangeHighlight.GetComponent<Collider>().enabled = false;
        rangeHighlight.GetComponent<Renderer>().enabled = true;
        rangeHighlight.SetActive(false);

        //Kraken animation
        anim = GetComponent<Animation>();
    }


    void Update()
    {
        rangeHighlight.transform.position = new Vector3(gameObject.transform.position.x, 0.1f, gameObject.transform.position.z);

        if (held)
        {
            if (highlight != null)
            {
                highlightCheck();
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
        else
        {
            linerenderer.SetPositions(new Vector3[0]);
        }

        return false;
    }

    private void playForwards()
    {
        anim["Attack"].speed = 1.0f;
        anim.Play("Attack");
    }

    private void playBackwards()
    {
        anim["Attack"].speed = -1.0f;
        anim["Attack"].time = anim["Attack"].length;
        anim.Play("Attack");
    }

    //Activate animator
    bool attack(GameObject victim)
    {
        if (victim != null)
        {
            playForwards();
            playBackwards();
        }
        else
        {

        }
        return false;
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

    new void release(Vector3 vel)
    {
        base.release(vel);
        hideRange();
    }

    void OnDestroy()
    {
        if (rangeHighlight != null) DestroyImmediate(rangeHighlight);
    }
}
