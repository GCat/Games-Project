using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour, HealthManager {


    public float damage;
    public float health;
    private GameObject target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Spawn(GameObject target, float timeout)
    {
        this.target = target;
        StartCoroutine(waitToDie(timeout));
    }

    public void decrementHealth(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator waitToDie (float timeout)
    {
        yield return new WaitForSeconds(timeout);
        if (gameObject != null) Destroy(gameObject);
    }
}
