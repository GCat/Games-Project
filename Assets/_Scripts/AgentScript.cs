using UnityEngine;
using System.Collections;

public class AgentScript : MonoBehaviour {
	
	public GameObject[] targets;
	private NavMeshAgent agent;
	private int targetnum;
	private int numTargets;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		targets = GameObject.FindGameObjectsWithTag("Human Waypoint");
		targetnum = 0;
		numTargets = targets.Length;
	}
	
	// Update is called once per frame
	void Update () {
		if(numTargets != 0){
			float tx = targets[targetnum].transform.position.x;
			float tz = targets[targetnum].transform.position.z;
			if((transform.position.x == tx) && (transform.position.z ==tz)){
				targetnum = (1 + targetnum) % numTargets;
			}
			Vector3 target = targets[targetnum].transform.position;
			target.y = 0;
			agent.SetDestination(target);
		} 
	}
}