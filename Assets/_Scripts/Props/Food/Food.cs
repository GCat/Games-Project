using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class Food : Grabbable
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
