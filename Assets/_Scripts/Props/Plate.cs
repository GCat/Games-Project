using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;

class Plate : Grabbable
{
    private AudioSource audioSource;
    public AudioClip clink;
    public AudioClip smash;


    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }
    public override void grab()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
    }

    public override void release(Vector3 vel)
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().velocity = vel;
        removeOutline();
    }

    IEnumerator WaitToDestroy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
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
        Debug.Log("remove the outline please");
        if (other.gameObject.tag == "Hand")
        {
            removeOutline();
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        float force = collision.impulse.magnitude;
        if (force > 100)
        {
            smashPlate();
        }
        else if (force > 1)
        {
            audioSource.PlayOneShot(clink, 0.6f);
        }
    }
    private void smashPlate()
    {
        audioSource.PlayOneShot(smash, 0.8f);
        GameObject explosion = GameObject.Instantiate(Resources.Load("Particles/Explosion") as GameObject, transform.position, Quaternion.identity);
        explosion.transform.position = transform.position;
        explosion.transform.parent = null;
        Destroy(explosion, 3.0f);
        hide();
        GetComponent<Collider>().enabled = false;
        StartCoroutine(WaitToDestroy(2f));
    }

    void hide()
    {
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.enabled = false;
        }
    }


}

