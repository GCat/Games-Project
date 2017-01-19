using UnityEngine;
using System.Collections;

public class BadiesAI : MonoBehaviour {

	/* 0 -> Temple
	** 1 -> closest Human
	*/
	private int humanOrTemple;

	// for testing purposes only
	public bool attackMode;


	// badies propeties
	public float health;
	public float strength;

	// Navigation 
	private UnityEngine.AI.NavMeshAgent agent;
	private GameObject targetObject;
	private GameObject obstacleObject;

	// Use this for initialization
	void Start () {
		targetObject = null;
		health = 100;
		strength = 20;
		humanOrTemple = 0;
		if (Random.value > 0.7) humanOrTemple = 1;
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private GameObject findClosestEnemy(){
		// what to do whn no more humasn left?
		GameObject[] badies;
		GameObject closest = null;
		badies = GameObject.FindGameObjectsWithTag("Human");
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject badie in badies){
			Vector3 diff = badie.transform.position - position;
			float current_distance = diff.sqrMagnitude;
			if (current_distance < distance){
				distance = current_distance;
				closest = badie;
			}
		}
		return closest;
	}

	public void decrementHealth(float damage){
		health -= damage;
		if (health <= 0){
			Destroy(gameObject);
		}
	}	
}