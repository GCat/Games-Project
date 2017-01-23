using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {

    public Vector3[] fingers = new Vector3[5];
    GameObject heldScaffold;
    Scaffold heldScaffoldScript;
    public GameObject close_hand;
    public GameObject open_hand;
    BuildingType[] buildings = { BuildingType.FARM, BuildingType.HOUSE, BuildingType.IRONMINE, BuildingType.LUMBERYARD, BuildingType.QUARRY, BuildingType.TOWER };
    int buildingType;
    int held = 0; //0 = no building, 1 = scaffold , 2 = any other building
    float rotationTimer;
    float startTime;
    Collider heldCollider;
    
	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update () {
        Vector3 curLocation = transform.position;
        GameObject res = Resources.Load("Scaffold") as GameObject;
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.position = new Vector3(curLocation.x-6*v,curLocation.y-20*scroll,curLocation.z+6*h);
        curLocation.x -= 14;
        curLocation.y -= 28;
        
        if (Input.GetMouseButtonDown(1))
        {
            if (held == 0)
            {
                heldScaffold = GameObject.Instantiate(res, curLocation, Quaternion.identity) as GameObject;
                heldScaffoldScript = heldScaffold.GetComponent("Scaffold") as Scaffold;
                heldCollider = heldScaffold.GetComponent<BoxCollider>();
                heldCollider.enabled = false;
                heldScaffoldScript.type = BuildingType.FARM;
                buildingType = 0;
                held = 1;
                startTime = Time.time;
                rotationTimer = 0f;
            }
            else if (held == 1)
            {
                buildingType = (buildingType + 1) % 6;
                heldScaffoldScript.type = buildings[buildingType];
            }
            else
            {
                heldScaffold.transform.Rotate(new Vector3(0, 90, 0));
            }
        }
        if (held == 1)
        {
            heldScaffold.transform.position = curLocation;
            
            rotationTimer = Time.time - startTime;
            if (rotationTimer > 1)
            {
                heldScaffold.transform.Rotate(new Vector3(0, 90, 0));
                startTime = Time.time;
            }
            
        }
        if (held == 2)
        {
            heldScaffold.transform.position = curLocation;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            if (held == 0)
            {
                float curClosest = 0;
                int closest = -1;
                int layerMask = 1 << 10;
                Collider[] inRange = Physics.OverlapSphere(curLocation, 10, layerMask);
                for (int i = 0; i < inRange.Length; i++)
                {
                    float distance = Vector3.Distance(inRange[i].transform.position, curLocation);
                    if (i == 0)
                    {
                        curClosest = distance;
                        closest = 0;
                    }
                    else
                    {
                        if (distance < curClosest)
                        {
                            closest = i;
                        }
                    }
                }
                if (closest != -1)
                {
                    if (!(inRange[closest].tag == "Temple"))
                    {
                        heldScaffold = inRange[closest].gameObject;
                        heldCollider = heldScaffold.GetComponent<BoxCollider>();
                        heldCollider.enabled = false;
                        if (heldScaffold.GetComponent<Scaffold>() != null)
                        {
                            held = 1;
                            heldScaffoldScript = heldScaffold.GetComponent<Scaffold>();
                            buildingType = UnityEditor.ArrayUtility.IndexOf(buildings, heldScaffoldScript.type);
                        }
                        else
                        {
                            held = 2;
                        }
                    }
                }
            }
            else
            {
                held = 0;
                heldCollider.enabled = true;
            }

        }
        if (held == 1 || held == 2)
        {
            close_hand.SetActive(true);
            open_hand.SetActive(false);
        }
        else if (held == 0)
        {
            open_hand.SetActive(true);
            close_hand.SetActive(false);
        }
    }
}
