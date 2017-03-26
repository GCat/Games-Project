﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : MonoBehaviour, Grabbable
{
    public bool held = false;
    public int faithCost = 10;
    public float damage = 50f;
    public float damageRadius = 30f;

    public AudioSource audioSource;
    public AudioClip powerClip;

    public ResourceCounter resourceCounter;
    protected new Renderer renderer;
    protected Shader outlineShader;

 
    // Use this for initialization
    void Awake()
    {
        resourceCounter = GameObject.FindGameObjectWithTag("Tablet").GetComponent<ResourceCounter>();
        audioSource = GetComponent<AudioSource>();
    }

    public bool canBuy()
    {
        if ((resourceCounter.faith >= faithCost))
        {
            resourceCounter.removeFaith(faithCost);
            return true;
        }
        return false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            setOutline();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            removeOutline();
        }
    }

    public void removeOutline()
    {

        renderer.material.shader = Shader.Find("Diffuse");
    }

    private void setOutline()
    {
        renderer.material.shader = outlineShader;
        renderer.material.SetColor("_OutlineColor", Color.blue);
    }

    public virtual void grab()
    {
        held = true;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;
    }
    public virtual void release(Vector3 vel)
    {
        //
    }
}
