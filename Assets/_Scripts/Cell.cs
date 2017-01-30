using UnityEngine;
using System.Collections;


public class Cell : MonoBehaviour {

	string details;
	public int id;
	private GameObject pathfinding;

    // Use this for initialization
    private void Awake()
    {
        pathfinding = GameObject.FindGameObjectWithTag("PathFinder");
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
		if((other.tag != "Human") && (other.tag != "Badies") && (other.tag != "Hand")){
			//string s = string.Format("Cell ({0},{1}) blocked id: {2}!",transform.position.x,transform.position.z,id);
			//Debug.Log(s);
			pathfinding.SendMessage("buildingAdded",id);
			details="blocked";
            if (other.tag != "Tablet" && other.gameObject.layer == 10) other.gameObject.SendMessage("activate");
		}
    }

	void OnTriggerExit(Collider other) {
		if((other.tag != "Human") && (other.tag != "Badies") && (other.tag != "Hand"))
        {
			//string s = string.Format("Cell ({0},{1}) unblocked id: {2}!",transform.position.x,transform.position.z,id);
			//Debug.Log(s);
			pathfinding.SendMessage("buildingRemoved",id);
			details = "empty";
            if (other.tag != "Tablet" &&  other.gameObject.layer == 10) other.gameObject.SendMessage("deactivate");
        }
		
    }
}
