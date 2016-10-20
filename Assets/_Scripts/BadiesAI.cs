using UnityEngine;
using System.Collections;

public class BadiesAI : MonoBehaviour {
	private bool templeAttack;
	public bool attackMode;
	public float health;
	public float strength;
	private NavMeshAgent agent;
	private float temple_or_human;
	private GameObject closestHuman;

	// Use this for initialization
	void Start () {
		closestHuman = null;
		health = 100;
		strength = 10;
		templeAttack = true;
		temple_or_human = Random.value;
		if (temple_or_human > 0.7) templeAttack = false;
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if (attackMode){
			if (templeAttack) {
				Vector3 temple_position = GameObject.FindWithTag("Temple").transform.position;
				Vector3 temple_pos = new Vector3 (temple_position.x, 0.5f, temple_position.z);
				agent.SetDestination(temple_pos);	
			}
			else{
				closestHuman = findClosestEnemy();
				if (closestHuman == null){
					//do something
				}
				else{
					agent.SetDestination(closestHuman.transform.position);
					if (Vector3.Distance(closestHuman.transform.position,transform.position) <
						GetComponent<Renderer>().bounds.size.x*1.5){
						Agent damage = (Agent) closestHuman.GetComponent(typeof(Agent));
						damage.decrementHealth(strength * Time.deltaTime);
					}
				}
			
		
			}
		}
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
