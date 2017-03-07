using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour, Grabbable {

    protected Shader outlineShader;
    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        outlineShader = Shader.Find("Toon/Basic Outline");
   
    }

    public void grab()
    {

    }

    public void release(Vector3 vel)
    {
        if(transform.position.y < 0)
        {
            transform.position = new Vector3(transform.position.x, 5, transform.position.z);

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
