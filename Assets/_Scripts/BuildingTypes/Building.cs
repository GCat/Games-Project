﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public abstract class Building : Grabbable, HealthManager
{ // this should also be placeable hence the grab and release will be written once
    public AudioClip buildClip;
    public AudioClip destroy;
    public string description = "";
    public abstract string getName();
    public abstract Vector3 getLocation();
    public abstract void create_building();
    public ResourceCounter resourceCounter;
    public GameObject tablet;
    public HealthBar healthBar;
    public int maxAllowed = 5;
    public bool bought = false;
    public int faithCost;
    protected Vector3 boxSize;
    public GameObject highlight_template;
    protected GameObject highlight;
    public bool canBeGrabbed = true;
    public BuildingSpawner spawnedFrom;

    private GameObject ExplosionEffect;
    private GameObject fireEffect;
    public Quaternion initialRotation;
    protected int nobuildmask = (1 << 10 | 1 << 17);
    public bool held = false;
    public GameObject destroyedBuilding;

    public abstract void die();
    public abstract void activate();
    public abstract void deactivate();


    public virtual void decrementHealth(float damage)
    {
        StartCoroutine(lockBuilding(5));
        if (gameObject.tag == "Temple")
        {
            GetComponent<Temple>().warnPlayer();
        }
        healthBar.decrementHealth(damage);
        if (healthBar.health <= 0)
        {
            GameObject explosion = GameObject.Instantiate(ExplosionEffect);
            explosion.transform.position = transform.position;
            if (destroyedBuilding != null)
            {
                //destroyedBuilding.SetActive(true);
                //destroyedBuilding.transform.SetParent(null);
                //Destroy(destroyedBuilding, 5f);
            }
            Destroy(explosion, 3.0f);
            if (fireEffect != null)
            {
                fireEffect.SetActive(false);
            }
            die();
        }
        else if (healthBar.health <= (0.2 * healthBar.getOriginalHealth()))
        {
            setWarning();
        }
        else if (healthBar.health <= (0.5 * healthBar.getOriginalHealth()))
        {
            if (fireEffect == null)
            {
                fireEffect = Instantiate(Resources.Load("Particles/Fire"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.LookRotation(Vector3.forward, Vector3.up)) as GameObject;
                List<ParticleSystem> shapes = new List<ParticleSystem>(fireEffect.GetComponentsInChildren<ParticleSystem>());
                shapes.Add(fireEffect.GetComponent<ParticleSystem>());
                for (int i = 0; i < shapes.Count; i++)
                {
                    ParticleSystem.ShapeModule box = shapes[i].shape;
                    Vector3 bounds = GetComponent<Collider>().bounds.size;
                    if (bounds != null && Vector3.Magnitude(bounds) > 1f)
                    {
                        box.box = bounds;
                    }
                }
                fireEffect.transform.SetParent(transform);
            }
            fireEffect.SetActive(true);
        }
    }

    public void disableShadows()
    {
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        }

    }
    public void enableShadows()
    {
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            if (renderer.gameObject.GetComponent<HealthBar>() == null)
            {
                renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            }
        }

    }


    IEnumerator lockBuilding(float waitTime)
    {
        canBeGrabbed = false;
        yield return new WaitForSeconds(waitTime);
        if (GetComponent<Temple>() == null)
        {
            canBeGrabbed = true;
        }
    }

    protected IEnumerator fixOutline()
    {
        yield return new WaitForSeconds(0.2f);
        removeOutline();
    }

    public virtual void Awake()
    {
        tablet = GameObject.FindGameObjectWithTag("Tablet");
        if (tablet != null)
        {
            resourceCounter = (ResourceCounter)tablet.GetComponent<ResourceCounter>();
        }
        else
        {
            Debug.Log("Tablet not found");
        }
        boxSize = GetComponent<BoxCollider>().bounds.size / 2;
        boxSize.y = 1f;
        ExplosionEffect = Resources.Load("Particles/Explosion") as GameObject;
    }



    //return true if within bounds & not above another building
    public virtual bool canPlace()
    {

        float x = transform.position.x;
        float z = transform.position.z;

        if (resourceCounter.withinBounds(transform.position))
        {
            Quaternion rot;
            float yRot = gameObject.transform.eulerAngles.y;
            if ((yRot > 45 && yRot < 135) || (yRot > -135 && yRot < -45))
            {
                rot = Quaternion.LookRotation(Vector3.right);
            }
            else
            {
                rot = Quaternion.LookRotation(Vector3.forward);
            }
            Collider[] colliders = Physics.OverlapBox(new Vector3(x, 0, z), boxSize, rot, nobuildmask);
            foreach (Collider collider in colliders)
            {
                if (!(GetComponent<WallTurret>() != null && collider.GetComponent<WallTurret>() != null))
                {
                    return false;
                }
            }
            GetComponent<Collider>().enabled = true;
            return true;
        }
        return false;
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand" && other.gameObject.GetComponent<Hand>().getSpeed() < 95)
        {

            if ((resourceCounter.hasGameStarted() && ((faithCost <= resourceCounter.getFaith()) || (bought))) || gameObject.tag == "Temple")
            {
                setOutline();
            }
            else
            {
                setWarning();
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            removeOutline();
        }
    }

    void LateUpdate()
    {
        if (held)
        {
            transform.rotation = initialRotation;
        }
    }


    public GameObject createInfoText(string prefab)
    {
        Bounds dims = gameObject.GetComponent<Collider>().bounds;
        Vector3 actualSize = dims.size;
        GameObject newText = GameObject.Instantiate(Resources.Load(prefab)) as GameObject;
        newText.transform.position = gameObject.transform.position;
        newText.transform.Translate(new Vector3(0, actualSize.y * 1.3f, 0));
        newText.transform.SetParent(gameObject.transform);
        newText.SetActive(false);
        return newText;
    }

    public bool highlightCheck()
    {
        if (resourceCounter.withinBounds(transform.position))
        {
            highlight.SetActive(true);
            highlight.transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
            highlight.transform.rotation = transform.rotation;
            Collider[] colliders = Physics.OverlapBox(new Vector3(transform.position.x, 0, transform.position.z), boxSize, gameObject.transform.rotation, nobuildmask);
            foreach (Collider collider in colliders)
            {
                if (!(GetComponent<WallTurret>() != null && collider.GetComponent<WallTurret>() != null))
                {
                    foreach (Renderer t in highlight.GetComponentsInChildren<Renderer>())
                    {
                        t.material.SetColor("_Color", Color.red);
                    }
                    return false;
                }
            }

            foreach (Renderer t in highlight.GetComponentsInChildren<Renderer>())
            {
                t.material.SetColor("_Color", Color.green);
            }
            return true;
        }
        else
        {
            highlight.SetActive(false);
            return false;
        }
    }

    public virtual void highlightDestroy()
    {
        if (highlight != null) highlight.SetActive(false);
    }



    public void createHighlight()
    {
        if (highlight_template != null)
        {
            highlight = Instantiate(highlight_template) as GameObject;
            foreach (Renderer t in highlight.GetComponentsInChildren<Renderer>())
            {
                t.material.SetColor("_Color", Color.green);
            }
        }
        else
        {
            highlight = GameObject.CreatePrimitive(PrimitiveType.Cube);
            highlight.transform.localScale = new Vector3(boxSize.x * 2.0f, 0.1f, boxSize.z * 2.0f);
            highlight.GetComponentInChildren<Renderer>().material.SetColor("_Color", Color.green);
        }
        highlight.SetActive(true);
        highlight.transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
        highlight.transform.rotation = transform.rotation;

        highlight.GetComponent<Collider>().isTrigger = true;
    }

    public override void grab()
    {
        held = true;
        //Already placed the object once so should not charge you
        if (!bought)
        {
            bought = true;
            spawnedFrom.amountSpawned++;
            spawnedFrom.godRay.SetActive(false);
            resourceCounter.removeFaith(faithCost);
        }

        createHighlight();
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;
    }

    public override void release(Vector3 vel)
    {
        held = false;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Collider>().enabled = true;
        GetComponent<Rigidbody>().AddForce(vel, ForceMode.VelocityChange);
        removeOutline();
        highlightDestroy();
    }

    public bool canBuy()
    {
        if (!bought && (resourceCounter.faith >= faithCost))
        {
            bought = true;
            if (spawnedFrom) spawnedFrom.amountSpawned++;
            resourceCounter.removeFaith(faithCost);
            return true;
        }
        return false;
    }

    public virtual void refund()
    {
        resourceCounter.addFaith(faithCost);
    }

    public virtual void delete()
    {
        highlightDestroy();
        if (spawnedFrom != null) spawnedFrom.amountSpawned--;
        Destroy(gameObject);
    }

}
