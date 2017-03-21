using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : Tower
{

    public AudioClip build;
    public AudioClip destroy;
    public float fireDamagePerSecond = 5;

    public string buildingName;
    public GameObject target;


    public GameObject fireStream;

  


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


    public override void Update()
    {
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
    public override bool acquireTarget()
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

    public override string getName()
    {
        return buildingName;
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
}