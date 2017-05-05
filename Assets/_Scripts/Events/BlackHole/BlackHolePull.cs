using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHolePull : MonoBehaviour {

    public float damage;
    public float pullForce;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        HealthManager thing = other.gameObject.GetComponent<HealthManager>();
        GameObject gameO = other.gameObject;
        if (gameO.GetComponent<Rigidbody>() != null){ 
            if (other.tag == "Temple")
            {
                if (thing != null) thing.decrementHealth(damage * Time.deltaTime);
            }
            else if (gameO.GetComponent<Building>() != null)
            {
                Vector3 vel = transform.position - gameO.transform.position;
                vel = vel.normalized;
                vel = vel * (pullForce / gameO.GetComponent<Rigidbody>().mass);
                vel.y = 0.0f;
                gameO.GetComponent<Rigidbody>().isKinematic = false;
                gameO.GetComponent<Rigidbody>().velocity = vel;
                if (thing != null) thing.decrementHealth(damage * Time.deltaTime);
            }
            else if (gameO.GetComponent<Agent>() != null)
            {
                gameO.GetComponent<Agent>().active = false;
                gameO.GetComponent<Character>().agent.enabled = false;
                Vector3 vel = transform.position - gameO.transform.position;
                vel = vel.normalized;
                vel = vel * (pullForce / gameO.GetComponent<Rigidbody>().mass);
                gameO.GetComponent<Rigidbody>().isKinematic = false;
                gameO.GetComponent<Rigidbody>().useGravity = false;
                gameO.GetComponent<Rigidbody>().velocity = vel;
                if (thing != null) thing.decrementHealth(damage * Time.deltaTime);
                gameO.GetComponent<Agent>().debugBlackhole(vel);

            }
            else if (gameO.GetComponent<Monster>() != null)
            {
                gameO.GetComponent<Monster>().active = false;
                gameO.GetComponent<Character>().agent.enabled = false;
                Vector3 vel = transform.position - gameO.transform.position;
                vel = vel.normalized;
                vel = vel * (pullForce / gameO.GetComponent<Rigidbody>().mass);
                gameO.GetComponent<Rigidbody>().isKinematic = false;
                gameO.GetComponent<Rigidbody>().useGravity = false;
                gameO.GetComponent<Rigidbody>().velocity = vel;
                if (thing != null) thing.decrementHealth(damage * Time.deltaTime);
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        HealthManager thing = other.gameObject.GetComponent<HealthManager>();
        GameObject gameO = other.gameObject;
        if (thing != null) thing.decrementHealth(damage * Time.deltaTime);
        if (gameO.GetComponent<Rigidbody>() != null)
        {
            if (gameO.GetComponent<Building>() != null || gameO.GetComponent<Agent>() != null || gameO.GetComponent<Monster>() != null)
            {
                Vector3 vel = transform.position - gameO.transform.position;
                vel = vel.normalized;
                vel = vel * (pullForce / gameO.GetComponent<Rigidbody>().mass);
                gameO.GetComponent<Rigidbody>().velocity = vel;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject gameO = other.gameObject;
        if (gameO.GetComponent<Rigidbody>() != null)
        {
            if (gameO.GetComponent<Building>() != null)
            {
                gameO.GetComponent<Rigidbody>().isKinematic = true;
                gameO.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            else if (gameO.GetComponent<Agent>() != null)
            {
                gameO.GetComponent<Agent>().active = true;
                gameO.GetComponent<Character>().agent.enabled = true;
                gameO.GetComponent<Rigidbody>().isKinematic = true;
                gameO.GetComponent<Rigidbody>().velocity = Vector3.zero;

            }
            else if (gameO.GetComponent<Monster>() != null)
            {
                gameO.GetComponent<Monster>().active = true;
                gameO.GetComponent<Character>().agent.enabled = true;
                gameO.GetComponent<Rigidbody>().isKinematic = true;
                gameO.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
    }
}
