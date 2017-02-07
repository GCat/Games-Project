using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceCounter : MonoBehaviour
{

    public GameObject textDisplay;
    public Dictionary<string, GameObject[]> resource_nodes;
    //The text displayed on the tablet
    private TextMesh textMesh; 
    public int faith = 0;
    private int population = 0;
    private int iron = 0;
    private int stone = 0;
    private int food = 50;
    private int wood = 0;
    private int swords = 0;
    private int armour = 0;
    private int swordMult = 1;
    private int armourMult = 1;


    private void Awake()
    {
        resource_nodes = new Dictionary<string, GameObject[]>();
    }

    // Use this for initialization
    void Start()
    {
        GameObject[] forests = GameObject.FindGameObjectsWithTag("Forest");
        GameObject[] iron = GameObject.FindGameObjectsWithTag("Iron");
        resource_nodes.Add("Forest", forests);
        resource_nodes.Add("Iron", iron);

    }

    // Update is called once per frame
    void Update()
    {
        if (iron > 10*swordMult)
        {
            swords++;
            iron -= 10*swordMult;
            swordMult *= 2;
        }
        if (iron > 20*armourMult)
        {
            armour++;
            iron -= 20*armourMult;
            armourMult *= 2;
        }
        population = FindObjectsOfType<Agent>().Length;
        textMesh = textDisplay.GetComponent(typeof(TextMesh)) as TextMesh;
        setResourceText();
    }

    public void setResourceText()
    {
        string resourceText = "RESOURCES \n";
        resourceText += "Faith: " + faith + "\n";
        resourceText += "Food: " + food + "\n";
        resourceText += "Wood: " + wood + "\n";
        resourceText += "Stone: " + stone + "\n";
        resourceText += "Iron: " + iron + "\n";
        resourceText += "Population: " + population + "\n";
        resourceText += "Sword Level: " + swords + "\n";
        resourceText += "Armour Level: " + armour + "\n";
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
    public int getSwords()
    {
        return swords;
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
        faith += (population*1)+1;
    }
    public void addSwords()
    {
        swords++;
    }
    public void addPop()
    {
        population++;
    }
    public void removeFaith(int amount)
    {
        if (faith > amount) faith -= amount;
        else
        {
            faith = 0;
        }
    }
    public void removeWood(int amount)
    {
        if (wood > amount) wood -= amount;
        else
        {
            wood = 0;
        }
    }
    public void removeStone(int amount)
    {
        if (stone > amount) stone -= amount;
        else
        {
            stone = 0;
        }
    }
    public void removeFood(int amount)
    {
        if (food > amount) food -= amount;
        else
        {
            food = 0;
        }
    }
    public void removeIron(int amount)
    {
        if (iron > amount) iron -= amount;
        else
        {
            iron = 0;
        }
    }

    void grabbed()
    {
      
        // Deactivate  collider and gravity
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;
    }
    void release(Vector3 vel)
    {
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Collider>().enabled = true;
        GetComponent<Rigidbody>().velocity = vel;
    }
}
