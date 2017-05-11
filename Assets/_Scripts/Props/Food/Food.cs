using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Food : Edible
{
    private AudioSource audioSource;
    public AudioClip squish;
    public AudioClip munch;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        mouth = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        if (transform.position.magnitude > 500)
        {
            Destroy(gameObject);

        }

    }
 

    public void OnCollisionEnter(Collision collision)
    {
        float force = collision.impulse.magnitude;
        if (force > 1)
        {
            audioSource.PlayOneShot(squish, 0.6f);
        }
    }
    protected override void eat()
    {

        //crumbEffect.transform.SetParent(null);
        crumbEffect.Clear();
        crumbEffect.Play();
        audioSource.PlayOneShot(munch, 0.8f);
        held = false;
        hide();
        Destroy(gameObject, 0.8f);
        GetComponent<Collider>().enabled = false;
    }

}

