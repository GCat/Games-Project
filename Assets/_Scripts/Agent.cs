using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
using System;
using UnityEngine.EventSystems;

public class Agent : MonoBehaviour {
 
	public bool fightMode;
    public AudioClip sacrificeClip;
	public float priority =  0;

    private Thread t1;
	private bool threadRunning = false;
	bool beingMoved = false;

	List<int> waypoints;

	public float health = 100.0f;
	public float strenght = 10.0f;
	public float speed = 2.0f;
	public float rotationspeed = 1.0f;
	public float gravity = 9.81F;
	public float weapon_strength;
	
	private Vector3 [] previousLocations = new Vector3[3];
	private float noMovement = 0.01f;

	private Vector3 initialPosition;
	private PathFinding pathFinder;

	public Vector3 nextNode;
	public int targetCell;

	private Rigidbody rb;
	public Animation anim;


	public bool isMoving = false;
	private GameObject closestBadie;
	private bool noMoreEnemies;
	private int maxCell;

    private bool stopMoving;
    private Vector3 screenPoint;
    private Vector3 Mouse_offset;
    private bool sacrificeEntered = false;

    void Start () {
		strenght = 10;
		health = 100;
		speed = 2.0f;
        stopMoving = false;
		nextNode =  new Vector3 (0.0f,-50.0f,0.0f);
		waypoints = new List<int>();
		noMoreEnemies = false;
		initialPosition = transform.position;
		priority = UnityEngine.Random.Range (0.0f, 20.0f);

		anim = GetComponent<Animation> ();
		rb = GetComponent<Rigidbody>();
		rb.interpolation = RigidbodyInterpolation.Extrapolate;

		pathFinder =(PathFinding) GameObject.FindGameObjectWithTag("PathFinder").GetComponent(typeof(PathFinding));
		maxCell = 5000;
		closestBadie = null;

	}
	
	// Update is called once per frame
	void Update () {
		if (fightMode && !stopMoving)
			fightNav ();
		else if(!stopMoving)
			wanderNav();
	}

	void avoidHuman (GameObject other){
		/* First check that the humans could intersect
		*  do this by  checking if the next node are equal 
		*  this assures they are at least 2 appart hence they can not collide as radius is 1*/

		/* Not safe as not cheking that there is a next node will do in next version*/

		Agent otherScript = (Agent)other.GetComponent (typeof(Agent));
		int  othernextNode = coord2cellID(otherScript.nextNode );
		int myNextNode = coord2cellID (nextNode);


		if (myNextNode == othernextNode) {
			/*They could intersect so the one with the lowwest priority will try and avoid collision
			* Whilst the one with highest priority will continue its path*/
			float otherp = otherScript.priority;
			/* not safe as  no procedures for equality in place yet */
			if( otherp > priority){
				int myNode =coord2cellID (transform.position);
				HashSet<Edge> neighbours = pathFinder.getEdgesFrom (myNode);
				int otherposition = coord2cellID (other.transform.position);
				List<int> moves = new List<int> ();
				foreach (Edge e in neighbours){
					int dst = e.otherEdge (myNode);
					if (dst != myNode && dst != otherposition) {
						moves.Add (dst);
					}
				}

			}
		}
		
	}

	private int getGridMovement(int next, int current){
		int diff = next - current;

		switch (diff)
		{
		case 50:
			return 1;
		case 51:
			return 2 ;
		case 1:
			return 3;
		case -49:
			return 4;
		case -50:
			return 5;
		case -51:
			return 6;
		case -1:
			return 7;
		case 49:
			return 8;
		default:
			Debug.Log ("Error avoiding collision");
			return 0;
		}
	}

    void sacrifice()
    {
        sacrificeEntered = true;
        GameObject resourceTab = GameObject.Find("Resource_tablet");
        resourceTab.SendMessage("addFaith",100);
        AudioSource source = GetComponent<AudioSource>();
        source.PlayOneShot(sacrificeClip, 0.5f);
        StartCoroutine(WaitToDestroy(3.0f));
        
    }

    IEnumerator WaitToDestroy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GameObject.Destroy(gameObject);
    }


    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Mouse_offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
		beingMoved = true;
        stopMoving = true;
		nextNode.y = -50f;
		waypoints = new List<int> ();
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + Mouse_offset;
        transform.position = curPosition;
        if (Mathf.Abs(transform.position.x) > 50f || Mathf.Abs(transform.position.z) > 100f) {
            if(!sacrificeEntered)sacrifice();
        }
    }

	void OnMouseUp(){
		if (beingMoved) {
			beingMoved = false;
			if (!(Mathf.Abs (transform.position.x) > 50f || Mathf.Abs (transform.position.z) > 100f)) {
				stopMoving = false;
			}
		}
	}

    void astar(int srcCell, int targetCell){
		waypoints = new List<int>(pathFinder.Astar(srcCell,targetCell));
		threadRunning = false;
	}

	private void wanderNav(){
		// for this to work 2*tolerance >= speed/framerate  so tolerance is 0.1f therefore speed/frame < 0.2f
		if(nextNode.y  == -50f) getNextNode();
		else{
			if (pathFinder.checkCell (targetCell) == "empty") {
				Vector3 offset = nextNode - transform.position;
				if (offset.magnitude > 0.1f) {
					Vector3 finalVal = offset.normalized * speed;
					rb.MovePosition (transform.position + finalVal * Time.deltaTime);
					/*transform.rotation = Quaternion.Slerp(
						transform.rotation,
						Quaternion.LookRotation(offset),
						Time.deltaTime * rotationspeed);*/
					anim.Play ("walk");
				} else
					getNextNode ();
			} else {
				waypoints = new List<int> ();
				nextNode.y = -50f;
				getNextNode ();
			}
		}
	}


	private void fightNav(){
		if (closestBadie == null){
			closestBadie = findClosestEnemy ();
			if (closestBadie == null) {
				waypoints = new List<int> ();
				nextNode.y = -50f;
				fightMode = false;
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
		int target = (int) UnityEngine.Random.Range(0.0f,maxCell);
		string status = pathFinder.checkCell(target);
		while (status != "empty"){
			target = (int) UnityEngine.Random.Range(0.0f,maxCell);
			status= pathFinder.checkCell(target);
			Debug.Log("Hit");
		}
		return target;
	}
		
}