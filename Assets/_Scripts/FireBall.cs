using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Grabbable
{

    //the thing that shot this

    public float destroyDelay = 0;
    public float damage = 8f;
    public Hades hades = null;
    public GameObject explosion;
    Temple temple;
    GameObject destruction;
    bool repelled = false;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(fadeOut(10));
        temple = GameObject.FindGameObjectWithTag("Temple").GetComponent<Temple>();
    }

    IEnumerator fadeOut(float time)
    {
        yield return new WaitForSeconds(time);
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
        if (destruction != null)
        {
            Destroy(destruction);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
    
        if (other.transform.root.tag == "Hades" && repelled)
        {
            if (hades != null)
            {
                hades.decrementHealth(damage);
            }
            explode();
            Physics.IgnoreCollision(GetComponent<Collider>(), other.collider);
        }

    }

    public override void grab()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
        repelled = true;
    }

    public override void release(Vector3 vel)
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().velocity = vel;
        removeOutline();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            setOutline();
        }else if (other.gameObject.tag == "MainCamera")
        {
            if (temple != null)
            {
                temple.decrementHealth(damage*2);
            }
            explode();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("remove the outline please");
        if (other.gameObject.tag == "Hand")
        {
            removeOutline();
        }
    }

    void explode()
    {
        destruction = Instantiate(explosion, transform.position, Quaternion.identity);
        destruction.transform.SetParent(null);
        destruction.GetComponent<ParticleSystem>().Clear();
        destruction.GetComponent<ParticleSystem>().Play();

    }
}
