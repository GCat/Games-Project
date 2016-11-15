using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Scaffold : MonoBehaviour {


    public TextMesh[] textMeshes;
    string curType;
    public GameObject res;
    public BuildingType type;
    public Vector3 location;
    private bool placeable = false;
    private int faithCost = 0;
    private Renderer thisRenderer;
    private Color normalColor;
    private ResourceCounter resourceCounter;
    //currently just create the building after a period of time
    private float placeTime = 10.0f;
    public float placeTimeLeft = 10.0f;
	// Use this for initialization
	void Start () {
        thisRenderer = GetComponent<Renderer>();
        normalColor = thisRenderer.material.color;
        location = this.transform.position;
        curType = type.ToString();
        setResourceText();
        resourceCounter = GameObject.Find("Resource_tablet").GetComponent<ResourceCounter>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        location.x = this.transform.position.x;
        location.z = this.transform.position.z;
        placeable = isPlaceable();
        setResourceText();
        if (!(type.ToString().Equals(curType)))
        {
            placeTimeLeft = placeTime;
            curType = type.ToString();
        }
        if (placeable)
        {
            thisRenderer.material.color = normalColor;
            placeTimeLeft -= Time.fixedDeltaTime;
        }else
        {
            thisRenderer.material.color = Color.red;
            placeTimeLeft = placeTime;
        }
        if(placeTimeLeft <= 0)
        {
            build();
        }
    }

    //Tests resource cost and location to determine if scaffold is placeable
    bool isPlaceable()
    {

        if(faithCost > resourceCounter.getFaith())
        {
            return false;
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.0f))
        {
            if (hit.transform.tag == "Ground")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;

        }
    }
    //converts this scaffold into a finished building
    void build()
    {
        GameObject.Instantiate(res, location, Quaternion.identity);
        Destroy(this.gameObject);

    }
    //determines the type and sets the displayed text
    void setResourceText()
    {
        string text = type.ToString();
        switch (type)
        {
            case BuildingType.CASTLE:
                faithCost = 50;
                break;
            case BuildingType.HOUSE:
                faithCost = 20;
                res = Resources.Load("House") as GameObject;
                location.y = 2;
                break;
            case BuildingType.LUMBERYARD:
                faithCost = 30;
                res = Resources.Load("LumberYard") as GameObject;
                location.y = 2;
                break;
            case BuildingType.IRONMINE:
                faithCost = 30;
                res = Resources.Load("IronMine") as GameObject;
                location.y = 1.5f;
                break;
            case BuildingType.FARM:
                faithCost = 10;
                res = Resources.Load("Farm") as GameObject;
                location.y = 1.5f;
                break;
            case BuildingType.QUARRY:
                faithCost = 20;
                res = Resources.Load("StoneQuarry") as GameObject;
                location.y = 4;
                break;
            case BuildingType.WALL:
                faithCost = 20;
                break;
        }
        for(int i=0; i< textMeshes.Length; i++)
        {
            if (i % 2 == 0)
            {
                textMeshes[i].text = "Faith \n" + faithCost;
            }
            else
            {
                textMeshes[i].text = text;
            }
        }
    }

}
