using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour, Grabbable {

    protected Shader outlineShader;
    public bool rotationHandle = false;
    private Renderer renderer;
    private GameObject parent;
    private bool grabbed = false;
    private LineRenderer lineRenderer;
    private Collider myCol;
    public GameObject bSpawner;

    void Start()
    {
        myCol = GetComponent<Collider>();
        renderer = GetComponent<Renderer>();
        outlineShader = Shader.Find("Toon/Basic Outline");
        if (transform.parent != null)
        {
            parent = transform.parent.gameObject;
        }
        if (rotationHandle)
        {
            //always be 5m from cloud
            Vector3 fromCloud = transform.position - parent.transform.position;
            transform.position = parent.transform.position + Vector3.Normalize(fromCloud) * 15;
            transform.parent = parent.transform;
            grabbed = false;
            lineRenderer = GetComponent<LineRenderer>();
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
            parent.transform.rotation = Quaternion.LookRotation(pos2d - parent.transform.position, Vector3.up);
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

    public void grab()
    {
        if (rotationHandle)
        {
            transform.parent = null;
            grabbed = true;
        }
        Collider[] cols = bSpawner.GetComponentsInChildren<Collider>();
        spawnChange(false);
        if (cols.Length > 0)
        {
            foreach (Collider c in cols)
            {
                if (c != myCol) c.enabled = false;
            }
        }

    }

    private void spawnChange(bool spawn)
    {
        bSpawner.GetComponent<BuildingSpawner>().spawn = spawn;
    }

    public void release(Vector3 vel)
    {
        if(transform.position.y < 0)
        {
            transform.position = new Vector3(transform.position.x, 5, transform.position.z);

        }
        if (rotationHandle)
        {
            //always be 5m from cloud
            Vector3 fromCloud = transform.position - parent.transform.position;
            transform.position = parent.transform.position + Vector3.Normalize(fromCloud) * 15;
            transform.parent = parent.transform;
            grabbed = false;
        }

        Collider[] cols = bSpawner.GetComponentsInChildren<Collider>();
        if (cols.Length > 0)
        {
            foreach (Collider c in cols)
            {
                if (c != myCol) c.enabled = true;
            }
        }
        spawnChange(true);
    }

    public void removeOutline()
    {

        renderer.material.shader = Shader.Find("Diffuse");
    }

    private void setOutline()
    {

        renderer.material.shader = outlineShader;
        renderer.material.SetColor("_OutlineColor", Color.green);
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
