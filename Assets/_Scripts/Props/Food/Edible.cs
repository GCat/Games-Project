using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class Edible : Grabbable
{

    protected GameObject mouth;
    protected bool held = false;

    public override void grab()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
        held = true;
    }

    public override void release(Vector3 vel)
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().velocity = vel;
        removeOutline();
        held = false;
    }

    protected abstract void eat();

    protected void hide()
    {
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.enabled = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            setOutline();
        }else if(other.gameObject.tag == "MainCamera")
        {
            eat();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            removeOutline();
        }
    }
    protected IEnumerator WaitToDestroy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }

    void Update()
    {
        //get around double trigger for noms
        if (held)
        {
            if (Vector3.Distance(transform.position, mouth.transform.position) < 15f)
            {
                eat();
            }
        }
    }



}
