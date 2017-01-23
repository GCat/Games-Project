using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {

    public Vector3[] fingers = new Vector3[5];
    GameObject heldScaffold;
    GameObject closed_hand;
    GameObject right_hand;
    Scaffold heldScaffoldScript;
    int held = 0;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 curLocation = transform.position;
        curLocation.x -= 14;
        curLocation.y -= 22;
        GameObject res = Resources.Load("Scaffold") as GameObject;
        if (Input.GetKeyDown(KeyCode.C) && held == 0)
        {
            heldScaffold = GameObject.Instantiate(res,curLocation, Quaternion.identity) as GameObject;
            heldScaffoldScript = heldScaffold.GetComponent("Scaffold") as Scaffold;
            held = 1;
        }
        if (Input.GetKeyDown(KeyCode.D) && held == 1)
        {
            held = 0;
        }
        if (held == 1)
        {
            heldScaffold.transform.position = curLocation;
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                heldScaffoldScript.type = BuildingType.FARM;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                heldScaffoldScript.type = BuildingType.HOUSE;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                heldScaffoldScript.type = BuildingType.IRONMINE;
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                heldScaffoldScript.type = BuildingType.LUMBERYARD;
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                heldScaffoldScript.type = BuildingType.QUARRY;
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                heldScaffoldScript.type = BuildingType.TOWER;
            }
        }
        if(held == 1)
        {
            closed_hand.GetComponent<Renderer>().enabled = true;
            right_hand.GetComponent<Renderer>().enabled = false;

        }
        else
        {
            closed_hand.GetComponent<Renderer>().enabled = false;
            right_hand.GetComponent<Renderer>().enabled = true;

        }
    }
}
