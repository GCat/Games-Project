using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Eatable : Food
{
    private AudioSource audioSource;
    private GameObject crumbs;
    private ParticleSystem crumbEffect;
    public AudioClip squish;
    public AudioClip munch;
    public Color crumbColour;
    private Renderer[] eaten_bits;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        eaten_bits = GetComponentsInChildren<Renderer>();
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

    void hide()
    {
        foreach(Renderer r in eaten_bits)
        {
            r.enabled = false;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        float force = collision.impulse.magnitude;
        if (force > 1)
        {
            audioSource.PlayOneShot(squish, 0.4f);
        }
    }
    protected override void eat()
    {
        crumbEffect.Clear();
        crumbEffect.Play();
        audioSource.PlayOneShot(munch, 0.6f);
        held = false;
        hide();
        StartCoroutine(WaitToDestroy(1f));

    }
    IEnumerator WaitToDestroy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}

