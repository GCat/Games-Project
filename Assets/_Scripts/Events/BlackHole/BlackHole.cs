using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour {


    public float damage;
    public float lifetime;
	// Use this for initialization
	void Start () {
        StartCoroutine(WaitToDie());
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

    IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}
