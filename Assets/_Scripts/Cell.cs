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
        if(other.tag == "Temple")
        {
            Debug.Log("Temple placed");
        }
		if((other.tag != "Human") && (other.tag != "Badies") && (other.tag != "Hand")){
            //string s = string.Format("Cell ({0},{1}) blocked id: {2}!",transform.position.x,transform.position.z,id);
            //Debug.Log(s);
            
            pathfinding.buildingAdded(id);
			details="blocked";
            if (other.gameObject.layer == 10) {
                if (other.GetComponent<Building>() != null) {
                    other.GetComponent<Building>().activate();
                }
                else
                {
                    Debug.Log("Trying to activate an object in the building layer, which is not a building", other.gameObject);
                }
            }
		}
        covered = true;
    }

	void OnTriggerExit(Collider other) {


        if (other.gameObject.layer == 10)
        {
            if (other.GetComponent<Building>() != null)
            {
                pathfinding.buildingRemoved(id);
                details = "empty";
                other.GetComponent<Building>().deactivate();
            }
            else
            {
                Debug.Log("Trying to deactivate an object in the building layer, which is not a building", other.gameObject);
            }
        }
        covered = false;
    }
}
