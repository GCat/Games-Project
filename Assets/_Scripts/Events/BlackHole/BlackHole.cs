using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour {

    private GameObject portal;
    public BlackHolePull pullArea; 
    public float damage;
    public float lifetime;
	// Use this for initialization
	void Start () {
        StartCoroutine(WaitToMove());
        StartCoroutine(WaitToDie());
        portal = GameObject.FindGameObjectWithTag("Portal");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {

        HealthManager thing = other.gameObject.GetComponent<HealthManager>();
        if (other.tag == "Temple")
        {
            if (thing != null) thing.decrementHealth(damage * Time.deltaTime);
        }
        else
        {
            
            if (thing != null) thing.decrementHealth(1000000f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Temple")
        {
            HealthManager thing = other.gameObject.GetComponent<HealthManager>();
            if (thing != null) thing.decrementHealth(damage * Time.deltaTime);
        }
    }

    IEnumerator WaitToMove()
    {
        yield return new WaitForSeconds(lifetime);
        pullArea.pullForce = 0.0f;
        GetComponent<Rigidbody>().velocity = Vector3.up * 1000f;
    }

    IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(lifetime +2f);
        Destroy(gameObject);
    }
}
