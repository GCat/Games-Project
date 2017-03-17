using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchTower : Building, Grabbable
{

    public AudioClip arrowClip;
    private AudioSource arrowSource;
    public float arrowDamage = 5;
    float arrowSpeed = 30;
    GameObject rangeHighlight;

    public string buildingName;
    public GameObject target;
    private float radius = 25.0f;

    bool active = false;
    public bool held = false;

    private bool badplacement = false;
    private float placementTime = 0;

    int attackMask = 1 << 11;
    GameObject pre;
    bool grabbedOnce = false;

    private GameObject currentTarget;

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
        pre = Resources.Load("Arrow_Regular") as GameObject;

        rangeHighlight = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        rangeHighlight.GetComponent<Renderer>().material.SetColor("_Color", new Color(0.0f,0.6f,0.0f,0.2f));
        rangeHighlight.transform.localScale = new Vector3(radius, 0.1f, radius);
        rangeHighlight.transform.position = new Vector3(gameObject.transform.position.x, 0.1f, gameObject.transform.position.z);
        rangeHighlight.transform.rotation = Quaternion.LookRotation(Vector3.forward);

        rangeHighlight.GetComponent<Collider>().enabled = false;
        rangeHighlight.GetComponent<Renderer>().enabled = true;
        rangeHighlight.SetActive(false);

        arrowSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        arrowSource.rolloffMode = AudioRolloffMode.Linear;
        arrowSource.volume = 0.7f;
        arrowSource.spatialBlend = 0.5f;
        arrowSource.clip = arrowClip;
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
                if(currentTarget == null)
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
            if (currentTarget != null && Vector3.Distance(transform.position, currentTarget.transform.position) < radius)
            {
                throwArrow(currentTarget);
            }
            yield return new WaitForSeconds(2);
        }
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
            pos.y += 10f;
            Vector3 direction = Vector3.Normalize(victim.transform.position - pos) * arrowSpeed;
            GameObject arrow = GameObject.Instantiate(pre, pos, Quaternion.LookRotation(direction)) as GameObject;
            arrow.GetComponent<Projectile>().parent = gameObject;
            arrow.GetComponent<Rigidbody>().velocity = direction;
            Physics.IgnoreCollision(GetComponent<Collider>(), arrow.GetComponent<Collider>());
            float travelTime = Vector3.Distance(victim.transform.position, pos) / arrowSpeed;
            StartCoroutine(WaitToDamage(travelTime, arrowDamage, currentTarget));
            arrowSource.Play();
        }
    }


    IEnumerator WaitToDamage(float waitTime,float damage, GameObject victim)
    {
        yield return new WaitForSeconds(waitTime);
        if (victim != null)
        {
            HealthManager victimHealth = victim.GetComponent<HealthManager>();
            if (victimHealth != null)
            {
                victimHealth.decrementHealth(damage);
            }
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