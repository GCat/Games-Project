using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour, Grabbable {

    protected Shader outlineShader;
    public bool rotationHandle = false;
    private Renderer renderer;
    private GameObject parent;


    void Start()
    {
        renderer = GetComponent<Renderer>();
        outlineShader = Shader.Find("Toon/Basic Outline");
        parent = transform.parent.gameObject;
    }

    Quaternion rotation;
    void Awake()
    {
        rotation = transform.rotation;
    }
    void LateUpdate()
    {
        transform.rotation = rotation;
    }

    public void grab()
    {
        if (rotationHandle)
        {
            transform.parent = null;
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
            transform.parent = parent.transform;
            parent.transform.rotation = Quaternion.LookRotation(transform.position - parent.transform.position, Vector3.up);
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
