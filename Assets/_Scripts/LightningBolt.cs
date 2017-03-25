using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBolt : Tool {

    public bool held = false;
    public int fCost;
    public float damage = 50f;
    public float damageRadius = 30f;
    GameObject highlight = null;
    GameObject flash;
    protected Renderer rend;
    protected Shader outlineShader;
    public ResourceCounter res;
    public AudioClip zap;
    private AudioSource source;
    private bool exploded = false;

    // Use this for initialization
    void Start () {
        outlineShader = Shader.Find("Toon/Basic Outline");
        rend = GetComponent<Renderer>();
        res = GameObject.FindGameObjectWithTag("Tablet").GetComponent<ResourceCounter>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
		
	}
    public new bool canBuy()
    {
        if (res.faith > fCost) return true;
        else return false;
    }
    public void removeOutline()
    {

        rend.material.shader = Shader.Find("Diffuse");
    }

    private void setOutline()
    {
        rend.material.shader = outlineShader;
        rend.material.SetColor("_OutlineColor", Color.blue);
    }

    public override void grab()
    {
        held = true;
        // Deactivate collider and gravity


        // highlight where object wiould place if falling straight down
        /*Material mat = Resources.Load("Materials/highlight.mat") as Material;
        highlight = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        highlight.GetComponent<Renderer>().material = mat;
        highlight.transform.localScale = new Vector3(GetComponent<Collider>().bounds.size.x, 0.1f, GetComponent<Collider>().bounds.size.z);
        highlight.transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
        highlight.GetComponent<Collider>().enabled = false;
        highlight.GetComponent<Renderer>().enabled = false;*/

        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;

    }
    public override void release(Vector3 vel)
    {
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Collider>().enabled = true;
        GetComponent<Rigidbody>().velocity = vel;

        Vector3 releasedPoint = transform.position;
        Vector3 predictedPoint = releasedPoint + vel * Time.deltaTime;
        Vector3 straightLinePath = predictedPoint - releasedPoint;
        Quaternion rotation = Quaternion.LookRotation(straightLinePath);
        transform.rotation = rotation;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground" && !exploded) {
            exploded = true;
            res.removeFaith(fCost);
            source.Play();
            int layerMask = 1 << 11;
            ContactPoint hit = col.contacts[0];
            rend.enabled = false;
            GetComponent<Collider>().enabled = false;
            Collider[] damageZone = Physics.OverlapSphere(hit.point, damageRadius, layerMask);
          
            GameObject resource = Resources.Load("Bolt flash") as GameObject;
            flash = GameObject.Instantiate(resource, hit.point, Quaternion.identity);
            Destroy(flash.gameObject, 2f);
            source.PlayOneShot(zap, 0.8f);
            for (int i=0; i < damageZone.Length; i++)
            {
                HealthManager victimHealth = damageZone[i].gameObject.GetComponent<HealthManager>();
                //we can probably do something cleaner than comparing name - maybe some enums for different character types
                if (victimHealth != null)
                {
                    victimHealth.decrementHealth(damage);
                }

            }
            Physics.IgnoreCollision(GetComponent<Collider>(), col.collider);
            Destroy(gameObject, 0.3f);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            setOutline();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            removeOutline();
        }
    }

    public void activate()
    {
        throw new NotImplementedException();
    }

}
