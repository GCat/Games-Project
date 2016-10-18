using UnityEngine;
using System.Collections;


public class AgentScript : MonoBehaviour {

	public float radius; 
	private Vector3 initialPosition;
	private NavMeshAgent agent;

	void Start () {

		initialPosition = transform.position;
		agent = GetComponent<NavMeshAgent>();
		Vector3 target = checkPosition(calculateNewTarget());
		agent.SetDestination(target);
		Debug.Log(target);
	}
	
	// Update is called once per frame
	void Update () {
		float remainingDistance = agent.remainingDistance;
		NavMeshPathStatus pathstatus = agent.pathStatus;

		// Check if we've reached the destination
		if (!agent.pathPending){
			if (agent.remainingDistance <= agent.stoppingDistance){
				if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f){
					Vector3 target = checkPosition(calculateNewTarget());
					agent.SetDestination(target);
					 
				}
			}
		}
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
			   Vector3 newTarget = new Vector3 (coords.x + obstacles[0].bounds.size.x, 0.5f, coords.z);
			   return checkPosition(newTarget);
		   }
		   return coords;
	}

}