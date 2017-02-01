using UnityEngine;
using System.Collections;


public class Cell : MonoBehaviour {

	public string details;
	public int id;
    private PathFinding pathfinding;
    private bool covered = false;

    // Use this for initialization
    private void Awake()
    {
        pathfinding = GameObject.FindGameObjectWithTag("PathFinder").GetComponent<PathFinding>();
        details = "empty";
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public string getStatus(){
		return details;
	}
	public void changeStatus(string status){
		details = status;
	}
	public void setid(int x){
		id = x;
	}

	void OnTriggerEnter(Collider other) {
        if (covered) {
            return;
            }

		if((other.tag != "Human") && (other.tag != "Badies") && (other.tag != "Hand")){
            //string s = string.Format("Cell ({0},{1}) blocked id: {2}!",transform.position.x,transform.position.z,id);
            //Debug.Log(s);
            pathfinding.buildingAdded(id);
			details="blocked";
            if (other.gameObject.layer == 10)
            {
                if (other.GetComponent<Placeable>() != null) {
                    other.GetComponent<Placeable>().activate();
                }
            }
            //if (other.tag != "Tablet" && other.gameObject.layer == 10) other.gameObject.SendMessage("activate");
		}
        covered = true;
    }

	void OnTriggerExit(Collider other) {
		if((other.tag != "Human") && (other.tag != "Badies") && (other.tag != "Hand"))
        {
            //string s = string.Format("Cell ({0},{1}) unblocked id: {2}!",transform.position.x,transform.position.z,id);
            //Debug.Log(s);
            pathfinding.buildingRemoved(id);
            details = "empty";
            if (other.tag != "Tablet" &&  other.gameObject.layer == 10) other.gameObject.SendMessage("deactivate");
        }
        covered = false;
    }
}
