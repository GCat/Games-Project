using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Food : Edible
{
    private AudioSource audioSource;
    private GameObject crumbs;
    private ParticleSystem crumbEffect;
    public AudioClip squish;
    public AudioClip munch;
    public Color crumbColour;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        crumbs = Instantiate(Resources.Load("Particles/Crumbs") as GameObject, transform.position, Quaternion.identity);
        crumbs.transform.parent = transform;
        crumbs.transform.localScale = new Vector3(1, 1, 1);
        crumbEffect = crumbs.GetComponent<ParticleSystem>();
        crumbEffect.Stop();
        crumbEffect.Clear();
        ParticleSystem.MainModule main = crumbEffect.main;
        main.startColor = crumbColour;
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
        crumbEffect.Clear();
        crumbEffect.Play();
        audioSource.PlayOneShot(munch, 0.8f);
        held = false;
        hide();
        StartCoroutine(WaitToDestroy(1f));
        GetComponent<Collider>().enabled = false;
    }

}

