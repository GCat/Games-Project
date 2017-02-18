using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ResourceCounter : MonoBehaviour, Grabbable
{

    public Dictionary<string, GameObject[]> resource_nodes;
    //The text displayed on the tablet
    public Text text;
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
    public int baddies = 0;


    private void Awake()
    {
        resource_nodes = new Dictionary<string, GameObject[]>();
    }

    // Use this for initialization
    void Start()
    {
        GameObject[] forests = GameObject.FindGameObjectsWithTag("Forest");
        GameObject[] ironNode = GameObject.FindGameObjectsWithTag("Iron");
        resource_nodes.Add("Forest", forests);
        resource_nodes.Add("Iron", ironNode);

    }

    // Update is called once per frame : 
    void Update()
    {
        if (iron > 10 * swordMult)
        {
            swords++;
            iron -= 10 * swordMult;
            swordMult *= 2;
        }
        if (iron > 20 * armourMult)
        {
            armour++;
            iron -= 20 * armourMult;
            armourMult *= 2;
        }
        setResourceText();
    }

    public void setResourceText()
    {
        string resourceText = "RESOURCES \n";
        resourceText += "Faith: " + faith.ToString() + "\n";
        resourceText += "Food: " + food.ToString() + "\n";
        resourceText += "Wood: " + wood.ToString() + "\n";
        resourceText += "Stone: " + stone.ToString() + "\n";
        resourceText += "Iron: " + iron.ToString() + "\n";
        resourceText += "Monsters: " + baddies.ToString() + "\n";
        resourceText += "Population: " + population.ToString() + "\n";
        resourceText += "Sword Level: " + swords.ToString() + "\n";
        resourceText += "Armour Level: " + armour.ToString() + "\n";
        text.text = resourceText;
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
        faith += (population * 1) + 1;
    }
    public void addSwords()
    {
        swords++;
    }
    public void addPop()
    {
        population++;
    }
    public void addBaddie()
    {
        baddies++;
    }
    public void removeBaddie()
    {
        baddies--;
    }
    public void removePop()
    {
        population--;
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

    public void grab()
    {
      
        // Deactivate  collider and gravity
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;
    }
    public void release(Vector3 vel)
    {
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Collider>().enabled = true;
        GetComponent<Rigidbody>().velocity = vel;
    }
    public void activate()
    {


    }
}
