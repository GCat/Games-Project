using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : Grabbable {

    public bool rotationHandle = false;
    public bool frontHandle = false;
    private GameObject parent;
    private bool grabbed = false;
    private LineRenderer lineRenderer;
    private Collider myCol;
    public GameObject bSpawner;
    public GameObject godRay = null;
    private bool grabbedOnce = false;

    void Start()
    {
        myCol = GetComponent<Collider>();
        if (transform.parent != null)
        {
            parent = transform.parent.gameObject;
        }
        if (rotationHandle)
        {
            Vector3 pos2d = transform.position;
            pos2d.y = parent.transform.position.y;
            //always be 5m from cloud
            Vector3 fromCloud = pos2d - parent.transform.position;
            transform.position = parent.transform.position + Vector3.Normalize(fromCloud) * 15;
            transform.parent = parent.transform;
            grabbed = false;
            lineRenderer = GetComponent<LineRenderer>();
            transform.LookAt(parent.transform.position, Vector3.up);
        }
    }

    Quaternion rotation;
    void Awake()
    {
        rotation = transform.rotation;
    }
    void LateUpdate()
    {
        if (rotationHandle && grabbed)
        {
            Vector3 pos2d = transform.position;
            pos2d.y = parent.transform.position.y;
            if (frontHandle)
            {
                parent.transform.rotation = Quaternion.LookRotation(pos2d - parent.transform.position, Vector3.up);
            }else
            {
                parent.transform.rotation = Quaternion.LookRotation(parent.transform.position - pos2d, Vector3.up);
            }
            transform.LookAt(parent.transform.position, Vector3.up);
        }

        if(!rotationHandle)
        {
            transform.rotation = rotation;
        }else if (parent != null)
        {
            Vector3[] positions = { transform.position, parent.transform.position };
            lineRenderer.SetPositions(positions);
        }
    }

    public override void grab()
    {
        if (rotationHandle)
        {
            transform.parent = null;
            grabbed = true;

        }
        if (!grabbedOnce)
        {
            grabbedOnce = true;
            GameObject.FindGameObjectWithTag("Portal").GetComponent<Portal>().disableGodRay();
            Debug.Log("remove god ray please!");
        }

    }

    private void spawnChange(bool spawn)
    {
        bSpawner.GetComponent<BuildingSpawner>().spawn = spawn;
    }

    public override void release(Vector3 vel)
    {
        if(transform.position.y < 0)
        {
            transform.position = new Vector3(transform.position.x, 5, transform.position.z);

        }
        if (rotationHandle)
        {
            //always be 5m from cloud
            Vector3 pos2d = transform.position;
            pos2d.y = parent.transform.position.y;
            Vector3 fromCloud = pos2d - parent.transform.position;
            transform.position = parent.transform.position + Vector3.Normalize(fromCloud) * 15;
            transform.parent = parent.transform;
            grabbed = false;
            transform.LookAt (parent.transform.position, Vector3.up);

        }

        //Collider[] cols = bSpawner.GetComponentsInChildren<Collider>();
        //if (cols.Length > 0)
        //{
        //    foreach (Collider c in cols)
        //    {
        //        if (c != myCol) c.enabled = true;
        //    }
        //}
        //spawnChange(true);
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
}
