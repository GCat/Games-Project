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
    private int stoneCost = 0;
    private int woodCost = 0;
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
        //location.y += 1;
        if (!(type.ToString().Equals(curType)))
        {
            placeTimeLeft = placeTime;
            curType = type.ToString();
        }
        if (placeable)
        {
            thisRenderer.material.color = normalColor;
            placeTimeLeft -= Time.fixedDeltaTime;
        }
        else
        {
            thisRenderer.material.color = Color.red;
            placeTimeLeft = placeTime;
        }
        if(placeTimeLeft <= 0)
        {
            location.y += 0.2f;
            resourceCounter.removeFaith(faithCost);
            resourceCounter.removeWood(woodCost);
            resourceCounter.removeStone(stoneCost);
            build();
        }
    }

    //Tests resource cost and location to determine if scaffold is placeable
    public void setTypeFromColour(Vector3 color)
    {
        //green = farm
        //yellow = temple
        //l.blue = house
        //red = lumbermill
        float H = color[0];
        float S = color[1];
        float V = color[2];
        if ((H > 120.0f && H < 130.0f) && (S > 55.0f) && (V > 50.0f && V < 80.0f)) type = BuildingType.FARM;
        else if ((H > 50.0f && H < 60.0f) && (S > 65.0f) && (V > 70.0f)) type = BuildingType.TEMPLE;
        else if ((H > 0.0f && H < 5.0f) && (S > 75.0f) && (V > 75.0f)) type = BuildingType.LUMBERYARD;
        else if ((H > 180.0f && H < 190.0f) && (S > 65.0f) && (V > 70.0f)) type = BuildingType.HOUSE;
    }

    bool isPlaceable()
    {
        if (type == BuildingType.HOUSE)
        {
            if (woodCost > resourceCounter.getWood() || stoneCost > resourceCounter.getStone())
            {
                return false;
            }
        }
        else if (faithCost > resourceCounter.getFaith()) return false;

        RaycastHit hit;
        Vector3 curLocation = transform.position;
        curLocation.y -= 4.95f;
        if (Physics.Raycast(curLocation, Vector3.down, out hit, 1.0f))
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
        Destroy(this.gameObject);
        GameObject.Instantiate(res, location, Quaternion.identity);
        

    }
    //determines the type and sets the displayed text
    void setResourceText()
    {
        string text = type.ToString();
        switch (type)
        {
            case BuildingType.TEMPLE:
                faithCost = 0;
                woodCost = 0;
                stoneCost = 0;
                res = Resources.Load("Temple") as GameObject;
                location.y = 5;
                break;
            case BuildingType.HOUSE:
                faithCost = 0;
                woodCost = 50;
                stoneCost = 50;
                res = Resources.Load("House") as GameObject;
                location.y = 2;
                break;
            case BuildingType.LUMBERYARD:
                faithCost = 30;
                woodCost = 0;
                stoneCost = 0;
                res = Resources.Load("LumberYard") as GameObject;
                location.y = 2;
                text = "LUMBER\nYARD";
                break;
            case BuildingType.IRONMINE:
                faithCost = 30;
                woodCost = 0;
                stoneCost = 0;
                res = Resources.Load("IronMine") as GameObject;
                location.y = 2.5f;
                text = "IRON\nMINE";
                break;
            case BuildingType.FARM:
                faithCost = 10;
                woodCost = 0;
                stoneCost = 0;
                res = Resources.Load("Farm") as GameObject;
                location.y = 1.5f;
                break;
            case BuildingType.QUARRY:
                faithCost = 20;
                woodCost = 0;
                stoneCost = 0;
                res = Resources.Load("StoneQuarry") as GameObject;
                location.y = 4;
                text = "STONE\nQUARRY";
                break;
            case BuildingType.WALL:
                faithCost = 20;
                break;
            case BuildingType.TOWER:
                faithCost = 100;
                woodCost = 0;
                stoneCost = 0;
                res = Resources.Load("Tower") as GameObject;
                location.y = 6;
                text = "TOWER";
                break;
        }
        for(int i=0; i< textMeshes.Length; i++)
        {
            if (i % 2 == 0)
            {
                if (type != BuildingType.HOUSE)
                {
                    textMeshes[i].text = "Faith\n" + faithCost;
                }
                else
                {
                    if (i == 0) textMeshes[i].text = "STONE\n" + stoneCost;
                    else textMeshes[i].text = "WOOD\n" + woodCost;
                }
            }
            else
            {
                textMeshes[i].text = text;
            }
        }
    }

}
