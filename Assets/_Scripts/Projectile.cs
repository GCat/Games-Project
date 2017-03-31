using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {


    //the thing that shot this
    public GameObject parent = null;

    public float destroyDelay = 0;
	// Use this for initialization
	void Start () {
        StartCoroutine(fadeOut(10));
    }

    IEnumerator fadeOut(float time)
    {
        yield return new WaitForSeconds(time);
        if(gameObject != null)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public virtual void OnCollisionEnter(Collision other)
    {
        if (other.gameObject != parent && other.gameObject.tag == "Badies" || other.gameObject.tag == "Ground")
        {
            GetComponent<Rigidbody>().isKinematic = true;
            Destroy(gameObject, destroyDelay);
        }
    }
}
