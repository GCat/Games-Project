using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Threading;

public class Agent : MonoBehaviour {
 
	public bool fightMode;
	public float radius;

	private Thread t1;
	private bool threadRunning = false;

	List<int> waypoints;

	public float health;
	public float strenght;
	public float speed = 1;
	public float gravity = 9.81F;
	public float weapon_strength;
	
	private Vector3 [] previousLocations = new Vector3[3];
	private float noMovement = 0.01f;

	private Vector3 initialPosition;
	private PathFinding pathFinder;

	private Vector3 nextNode;
	private int targetCell;

	private CharacterController controller;
	private Vector3 cracyVector = new Vector3 (0.0f,-50.0f,0.0f);


	private bool isMoving = false;
	private GameObject closestBadie;
	private bool noMoreEnemies;
	private int maxCell;

	private Rigidbody rb;

	void Start () {
		radius = 50;
		strenght = 10;
		health = 100;
		nextNode =  new Vector3 (0.0f,-50.0f,0.0f);
		waypoints = new List<int>();
		noMoreEnemies = false;
		initialPosition = transform.position;
		previousLocations[0] = initialPosition;
		controller = GetComponent<CharacterController>();
		rb = GetComponent<Rigidbody>();
		pathFinder =(PathFinding) GameObject.FindGameObjectWithTag("PathFinder").GetComponent(typeof(PathFinding));
		maxCell =pathFinder.getMaxCell();
		closestBadie = null;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		wanderNav();
		
	    for(int i = 0; i < previousLocations.Length - 1; i++)
		{
		    previousLocations[i] = previousLocations[i+1];
		}
		previousLocations[previousLocations.Length - 1] = transform.position;

		for(int i = 0; i < previousLocations.Length - 1; i++)
		{
			if(Vector3.Distance(previousLocations[i], previousLocations[i + 1]) >= 0.001f)
			{
				//The minimum movement has been detected between frames
				isMoving = true;
				break;
			}
			else
			{
				isMoving = false;
			}
		}

	}

	void  astar(int srcCell, int targetCell){
		//Debug.Log("Entered");
		waypoints = new List<int>(pathFinder.Astar(srcCell,targetCell));
		//Debug.Log("Done");
		threadRunning = false;
	}

	private void wanderNav(){

		if(nextNode.y  == -50f){
			getNextNode();
		}
		else{
			if(pathFinder.checkCell(targetCell) == "empty"){
				if (!isMoving){
					nextNode.y = -50.0f;
					waypoints = new List<int>();
				}
				Vector3 moveDirection = nextNode -transform.position;
				if(moveDirection.magnitude < 0.001f){
					transform.position = nextNode;
					nextNode.y = -50.0f;
				}
				else{
					transform.LookAt(nextNode);
					controller.Move(moveDirection.normalized *speed *Time.deltaTime);
				}
			}
			else{
				nextNode.y =- 50.0f;
				waypoints = new List<int>();
			}
	
		}
	}
	private void getNextNode(){
		if (waypoints.Count > 0){
			targetCell = waypoints[0];
			waypoints.Remove(targetCell);
			Vector3 p = pathFinder.getCellPosition(targetCell);
			p.y = 0.5f;
			nextNode = p;

		}
		else{
			int srcCell = coord2cellID(transform.position);
			targetCell = calculateNewTarget();
			if(!threadRunning){
				threadRunning = true;
				t1 = new Thread(()=>astar(srcCell,targetCell));
				t1.Start();
			}
		}
	}

	// lazy function cuz i can not be bothered to find the correct mathematical approach tonight
	private int coord2cellID(Vector3 coords){
		int layerMask = 1 << 8;
		Vector3 target = new Vector3(coords.x,0.05f,coords.z);
		
		Collider[] obstacles = Physics.OverlapSphere(target, 0.05f, layerMask);
		if (obstacles.Length != 0){
			return obstacles[0].gameObject.GetComponent<Cell>().id;
		}
		return -1;
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
	
	public void decrementHealth(float damage){
		health -= damage;
		if (health <= 0){
			Destroy(gameObject);
		}
	}

	int calculateNewTarget(){
		int target = (int) Random.Range(0.0f,pathFinder.getMaxCell());
		string status = pathFinder.checkCell(target);
		while (status != "empty"){
			target = (int) Random.Range(0.0f,maxCell);
			status= pathFinder.checkCell(target);
			Debug.Log("Hit");
		}
		return target;
	}
}