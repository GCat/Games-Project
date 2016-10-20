using UnityEngine;
using System.Collections;


public class AgentScript : MonoBehaviour {

	public float radius; 
	public bool fightMode;
	public float health;
	public float strenght;
	public float weapon_strength;
	private Vector3 initialPosition;
	private NavMeshAgent agent;
	private GameObject closestBadie;
	private bool noMoreEnemies;

	void Start () {

		initialPosition = transform.position;
		agent = GetComponent<NavMeshAgent>();
		Vector3 target = checkPosition(calculateNewTarget());
		agent.SetDestination(target);
		closestBadie = null;
		strenght = 10;
		health = 100;
		noMoreEnemies = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (fightMode && (!noMoreEnemies)){
			attackNav();
		}
		else{
			wanderNav();
		}
	}

	private void wanderNav(){
		// Check if we've reached the destination
		if( Vector3.Distance(agent.destination,transform.position) < 0.5){
			Vector3 target = checkPosition(calculateNewTarget());
			agent.SetDestination(target);
		}
		else if (!agent.pathPending){
			if (agent.remainingDistance <= agent.stoppingDistance){
				if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f){
					Vector3 target = checkPosition(calculateNewTarget());
					agent.SetDestination(target); 
				}
			}
		}
		else if (agent.pathStatus == NavMeshPathStatus.PathPartial){
			Vector3 target = checkPosition(calculateNewTarget());
			agent.SetDestination(target);
		}

	}

	private void attackNav(){
		Debug.Log(noMoreEnemies);
		if ((closestBadie == null) || (closestBadie.Equals(null))){
			closestBadie = findClosestEnemy();
			if((closestBadie == null) || (closestBadie.Equals(null))){
				noMoreEnemies = true;
			}
			// what to do if all badies are dead?

		}
		else{
			agent.SetDestination(closestBadie.transform.position);
			if (Vector3.Distance(closestBadie.transform.position,transform.position) <
				GetComponent<Renderer>().bounds.size.x *2){
				BadiesAI damage = (BadiesAI) closestBadie.GetComponent(typeof(BadiesAI));
				damage.decrementHealth(strenght * Time.deltaTime);
			}
		}
	}

	private GameObject findClosestEnemy(){
		GameObject[] badies;
		GameObject closest = null;
		badies = GameObject.FindGameObjectsWithTag("Badies");
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
		// if you win and all badies are dead what you do?
		return closest;
	}


	Vector3 calculateNewTarget(){
		/// x ^2 * y^2 <+ r^2
		/// get random x in range +- radius ^2
		/// then find y in range 
		float sqrRadius = radius * radius;
		float x = Random.Range(-radius, radius);
		float maxz = Mathf.Sqrt(sqrRadius - x*x);
		float z = Random.Range(-maxz, maxz);
		return new Vector3(x + initialPosition.x, 0.5f, z + initialPosition.z);
	}

	Vector3 checkPosition(Vector3 coords){
		   Collider[] obstacles = Physics.OverlapSphere(coords, 0.0f);
		   if (obstacles.Length != 0){
				Debug.Log("HIT");
				float xcoord= coords.x +(float)(obstacles[0].bounds.size.x) *1.2f;
				Vector3 newTarget = new Vector3 (xcoord, 0.5f, coords.z);
				return checkPosition(newTarget);
		   }
		   return coords;
	}

	public void decrementHealth(float damage){
		health -= damage;
		if (health <= 0){
			Destroy(gameObject);
		}
	}

}