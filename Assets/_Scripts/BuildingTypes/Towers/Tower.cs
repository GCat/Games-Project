using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : Building {
    public AudioClip[] attackClip;
    public GameObject rangeHighlight;
    public GameObject currentTarget;
    protected Vector3 floor;
    public AudioSource audioSource;
    private Material rangeMat;
    public float radius;
    public bool active = false;

    public int attackMask = 1 << 11;
    protected bool activated = false;

    public override void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 0.5f;
        base.Awake();
        //audioSource.PlayOneShot(attackClip);
        createRangeHighlight();
        //rangeMat = Resources.Load("Materials/range") as Material;
    }

    protected void createRangeHighlight()
    {
        rangeHighlight = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        rangeHighlight.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
        //rangeHighlight.GetComponent<Renderer>().material = rangeMat;
        rangeHighlight.transform.localScale = new Vector3(radius, 0.1f, radius);
        rangeHighlight.transform.position = new Vector3(gameObject.transform.position.x, 0.1f, gameObject.transform.position.z);
        rangeHighlight.transform.rotation = Quaternion.LookRotation(Vector3.forward);

        rangeHighlight.GetComponent<Collider>().enabled = false;
        rangeHighlight.GetComponent<Renderer>().enabled = true;
        rangeHighlight.SetActive(false);
    }

    virtual public void updateHighlight()
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

    //override this to have the correct tower sequence
    virtual public void activeTower()
    {
    }

    // Update is called once per frame
    virtual public void Update () {
        rangeHighlight.transform.position = new Vector3(gameObject.transform.position.x, 0.1f, gameObject.transform.position.z);
        if (held) updateHighlight();
        else if (active) activeTower();         
    }

    // different towers can aquire targets differently
    public virtual bool acquireTarget()
    {
        List<Collider> hitColliders = new List<Collider>(Physics.OverlapSphere(floor, transform.InverseTransformVector(radius, 0, 0).magnitude, attackMask));
        if (hitColliders.Count > 0)
        {
            Debug.Log("Acquired target");
            currentTarget = hitColliders[0].gameObject;
            return true;
        }
        return false;
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

    protected abstract IEnumerator attack();

    public override void activate() {
        Debug.Log("Position: " + transform.position);
        floor = transform.position;
        floor.y = 0;
        if (!bought) resourceCounter.removeFaith(faithCost);
        active = true;
        if (highlight != null) Destroy(highlight);
        highlight = null;
        held = false;

        hideRange();
        if (!activated)
        {
            StartCoroutine(attack());
            activated = true;
        }
        StartCoroutine(getNearestTarget());
    } //function should be overriden by child

    public override void deactivate()
    {
        active = false;
    }

    public void showRange()
    {
        rangeHighlight.SetActive(true);
    }

    protected IEnumerator getNearestTarget()
    {
        while (active)
        {
            yield return new WaitForSeconds(1);
            if (resourceCounter.getBaddies() > 0)
            {
                if (currentTarget == null || Vector3.Distance(floor, currentTarget.transform.position) >= transform.InverseTransformVector(radius, 0, 0).magnitude)
                {
                    acquireTarget();
                }
            }
        }
    }

    public void hideRange()
    {
        rangeHighlight.SetActive(false);

    }

    public override void create_building()
    {

    }

    public override void die()
    {
        spawnedFrom.amountSpawned--;
        Destroy(gameObject);
    }

    new void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.gameObject.tag == "Hand" && bought  && other.gameObject.GetComponent<Hand>().getSpeed() < 95)
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

    public override void grab() 
    {
        base.grab();
        showRange();
    }

    public override void release(Vector3 vel)
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
