using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Wine : Edible
{
    private AudioSource audioSource;
    public AudioClip glug;
    public AudioClip clink;
    public AudioClip smash;
    private GameObject Explosion;
    private bool canGlug = true;
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        mouth = GameObject.FindGameObjectWithTag("MainCamera");

    }
    IEnumerator glugDelay(float delay)
    {
        canGlug = false;
        yield return new WaitForSeconds(delay);
        canGlug = true;
    }

    protected override void eat()
    {
        if (canGlug)
        {
            crumbEffect.Clear();
            crumbEffect.Play();
            audioSource.PlayOneShot(glug, 0.8f);
            StartCoroutine(glugDelay(0.5f));
        }
    }

    void FixedUpdate()
    {
        if (held && mouth != null)
        {
            transform.LookAt(mouth.transform);
            transform.Rotate(90, 0, 0);
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        float force = collision.impulse.magnitude;
        if (force > 80)
        {
            smashBottle();
        }
        else if (force > 1)
        {
            audioSource.PlayOneShot(clink, 0.6f);
        }
    }
    private void smashBottle()
    {
        audioSource.PlayOneShot(smash, 0.8f);
        GameObject explosion = GameObject.Instantiate(Resources.Load("Particles/Explosion") as GameObject, transform.position, Quaternion.identity);
        explosion.transform.position = transform.position;
        explosion.transform.parent = null;
        Destroy(explosion, 3.0f);
        hide();
        GetComponent<Collider>().enabled = false;
        Destroy(gameObject, 0.2f);
    }
}

