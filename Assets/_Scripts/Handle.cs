using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : Grabbable {


    private bool grabbed = false;
    public GameObject godRay;
    private bool grabbedOnce = false;
    Quaternion rotation;

    void Start()
    {

       
    }

    
    void Awake()
    {
        rotation = transform.rotation;
    }
    public override void grab()
    {
        if (!grabbedOnce)
        {
            grabbedOnce = true;
            godRay.SetActive(false);
        }

    }

    public void LateUpdate()
    {
        transform.rotation = rotation;
    }

    public override void release(Vector3 vel)
    {
        if(transform.position.y < 0)
        {
            transform.position = new Vector3(transform.position.x, 5, transform.position.z);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand" && other.gameObject.GetComponent<Hand>().getSpeed() < 95)
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
}
