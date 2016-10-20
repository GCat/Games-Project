using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScaffoldScript : MonoBehaviour {

    private Renderer thisRenderer;
    private Color normalColor;
    public TextMesh[] textMeshes;
    public BuildingType type;
	// Use this for initialization
	void Start () {
        thisRenderer = GetComponent<Renderer>();
        normalColor = thisRenderer.material.color;
        setResourceText();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, 1.0f))
        {
            if (hit.transform.tag == "Ground")
            {
                thisRenderer.material.color = normalColor;
            }else
            {
                thisRenderer.material.color = Color.red;
            }
        }else
        {
            thisRenderer.material.color = Color.red;

        }
    }

    void setResourceText()
    {
        int faith = 0;
        string text = type.ToString();
        switch (type)
        {
            case BuildingType.CASTLE:
                faith = 50;
                break;
            case BuildingType.HOUSE:
                faith = 20;
                break;
            case BuildingType.LUMBERYARD:
                faith = 30;
                break;
            case BuildingType.MINE:
                faith = 30;
                break;
            case BuildingType.WALL:
                faith = 20;
                break;
        }
        for(int i=0; i< textMeshes.Length; i++)
        {
            if (i % 2 == 0)
            {
                textMeshes[i].text = "Faith \n" + faith;
            }
            else
            {
                textMeshes[i].text = text;
            }
        }
    }

}
