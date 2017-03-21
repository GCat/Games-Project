﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour, Grabbable {

    protected Shader outlineShader;
    public bool rotationHandle = false;
    public bool frontHandle = false;
    private Renderer renderer;
    private GameObject parent;
    private bool grabbed = false;
    private LineRenderer lineRenderer;
    protected Renderer[] child_materials;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        outlineShader = Shader.Find("Toon/Basic Outline");
        child_materials = GetComponentsInChildren<Renderer>();
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

    public void grab()
    {
        if (rotationHandle)
        {
            transform.parent = null;
            grabbed = true;
        }
       
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
            Vector3 pos2d = transform.position;
            pos2d.y = parent.transform.position.y;
            Vector3 fromCloud = pos2d - parent.transform.position;
            transform.position = parent.transform.position + Vector3.Normalize(fromCloud) * 15;
            transform.parent = parent.transform;
            grabbed = false;
            transform.LookAt (parent.transform.position, Vector3.up);

        }
    }

    public void removeOutline()
    {

        foreach (Renderer renderer in child_materials)
        {
            renderer.material.shader = Shader.Find("Diffuse");
            //renderer.material.SetColor("_OutlineColor", Color.green);
        }
    }

    private void setOutline()
    {

        foreach (Renderer renderer in child_materials)
        {
            renderer.material.shader = outlineShader;
            renderer.material.SetColor("_OutlineColor", Color.green);
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
}
