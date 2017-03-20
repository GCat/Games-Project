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


    void Start()
    {
        renderer = GetComponent<Renderer>();
        outlineShader = Shader.Find("Toon/Basic Outline");
        if (transform.parent != null)
        {
            parent = transform.parent.gameObject;
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
            parent.transform.rotation = Quaternion.LookRotation(transform.position - parent.transform.position, Vector3.up);
            transform.LookAt(parent.transform.position, Vector3.up);
        }

        if(!rotationHandle)
        {
            transform.rotation = rotation;
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
            Vector3 fromCloud = transform.position - parent.transform.position;
            transform.position = parent.transform.position + Vector3.Normalize(fromCloud) * 10;
            transform.parent = parent.transform;
            grabbed = false;
        }
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
