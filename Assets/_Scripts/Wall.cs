using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	// Use this for initialization
	public float health;
	void Start () {
		health = 400;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void decrementHealth(float damage){
		health -= damage;
		if (health <= 0){
			Destroy(gameObject);
		}
	}
	void onCollisionEnter(Collision collision){
		Debug.Log("Sup");	
	}

}
