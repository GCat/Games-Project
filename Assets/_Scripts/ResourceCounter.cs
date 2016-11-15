using UnityEngine;
using System.Collections;

public class ResourceCounter : MonoBehaviour
{

    public GameObject textDisplay;
    //The text displayed on the tablet
    private TextMesh textMesh; 
    public int faith = 0;
    private int iron = 0;
    private int stone = 0;
    private int food = 0;
    private int wood = 0;
    private int swords = 0;
    private int bows = 0;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        textMesh = textDisplay.GetComponent(typeof(TextMesh)) as TextMesh;
        setResourceText();
    }

    public void setResourceText()
    {
        string resourceText = "Resources \n";
        resourceText += "Faith: " + faith + "\n";
        resourceText += "Food: " + food + "\n";
        resourceText += "Wood: " + wood + "\n";
        resourceText += "Stone: " + stone + "\n";
        resourceText += "Iron: " + iron + "\n";
        textMesh.text = resourceText;
    }


    //background baseline faith generation
    public void defaultFaithGen()
    {
        addFaith(1);
    }

    public void addFaith(int faith)
    {
        this.faith += faith;
    }

    public int getFaith()
    {
        return faith;
    }

    public int getFood()
    {
        return food;
    }

    public int getIron()
    {
        return iron;
    }

    public int getStone()
    {
        return stone;
    }

    public int getWood()
    {
        return wood;
    }
    public void addFood()
    {
        food++;
    }
    public void addWood()
    {
        wood++;
    }
    public void addStone()
    {
        stone++;
    }
    public void addIron()
    {
        iron++;
    }
    public void addFaith()
    {
        faith++;
    }
}
