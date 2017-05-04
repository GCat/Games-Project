using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ResourceCounter : Grabbable
{

    public Dictionary<string, GameObject[]> resource_nodes;
    private GameBoard ground;
    //The text displayed on the tablet
    public Text faithNumber;
    public Slider healthSlider;
    public Slider waveSlider;
    public Text fpsCounter;

    private Temple temple;
    private Portal portal;

    private int timeToNextWave = 30;
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
    //number of each baddie type
    private int[] baddies = new int[4];
    int frames = 0;
    float totalFPS = 0.0f;

    private bool gameStarted;


    private void Awake()
    {
        resource_nodes = new Dictionary<string, GameObject[]>();
        gameStarted = false;
        baddies = new int[4];
        for (int i = 0; i < baddies.Length; i++)
        {
            baddies[i] = 0;
        }
    }

    // Use this for initialization
    void Start()
    {
        GameObject[] forests = GameObject.FindGameObjectsWithTag("Forest");
        GameObject[] ironNode = GameObject.FindGameObjectsWithTag("Iron");
        ground = GameObject.FindGameObjectWithTag("Ground").GetComponent<GameBoard>();
        resource_nodes.Add("Forest", forests);
        resource_nodes.Add("Iron", ironNode);
        temple = GameObject.FindGameObjectWithTag("Temple").GetComponent<Temple>();
        healthSlider.maxValue = temple.healthBar.getOriginalHealth();
        portal = GameObject.FindGameObjectWithTag("Portal").GetComponent<Portal>();
        StartCoroutine(logFPS());
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
        //setResourceText();
        faithNumber.text = faith.ToString();
        healthSlider.value = temple.healthBar.health;
        frames++;
        totalFPS += (1f / Time.deltaTime);
        fpsCounter.text = "FPS: " + (totalFPS / frames).ToString("F2");
    }

    IEnumerator logFPS() {
        while (true)
        {
            yield return new WaitForSeconds(2);
            Debug.Log("Average FPS:" + (totalFPS / frames).ToString("F2"));

        }

    }

    public void setResourceText()
    {
        string resourceText = "Resources \n";
        resourceText += "Faith: " + faith.ToString() + "\n";
        resourceText += "Food: " + food.ToString() + "\n";
        //resourceText += "Wood: " + wood.ToString() + "\n";
        //resourceText += "Stone: " + stone.ToString() + "\n";
        //resourceText += "Iron: " + iron.ToString() + "\n";
        resourceText += "Population: " + population.ToString() + "\n";
        //resourceText += "Sword Level: " + swords.ToString() + "\n";
        //resourceText += "Armour Level: " + armour.ToString() + "\n";
        //text.text = resourceText;
    }

    //background baseline faith generation
    public void defaultFaithGen()
    {
        addFaith(1);
    }

    public int addFaith(int faith)
    {
        this.faith += faith;
        return faith;
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
    public int getPop()
    {
        return population;
    }
    public int addFood()
    {
        food++;
        return 1;
    }
    public int addWood()
    {
        wood++;
        return 1;
    }
    public int addStone()
    {
        stone++;
        return 1;
    }
    public int addIron()
    {
        iron++;
        return 1;
    }

    public void addSwords()
    {
        swords++;
    }
    public void addPop()
    {
        population++;
    }
    public void addBaddie(Portal.MonsterType type)
    {
        baddies[(int)type]++;
    }
    public void removeBaddie(Portal.MonsterType type)
    {
        baddies[(int)type]--;
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

    //get the number of ground based baddies
    public int getGroundBaddies()
    {
        return baddies[1] + baddies[0];
    }
    public int getBaddies()
    {
        int count = 0;
        foreach(int c in baddies)
        {
            count += c;
        }
        return count;
    }
    public override void grab()
    {
        // Deactivate  collider and gravity
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;
    }
    public override void release(Vector3 vel)
    {
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Collider>().enabled = true;
        GetComponent<Rigidbody>().velocity = vel;
    }
    public void activate()
    {


    }

    public bool aboveBoard(Vector3 p)
    {
        return ground.dynamicAboveBoard(p);
    }

    public bool withinBounds(Vector3 p)
    {
        return ground.dynamicWithinBounds(p);
    }

    public Vector3 getTopRight()
    {
        return ground.getTopRight();
    }
    public Vector3 getBottomLeft()
    {
        return ground.getBottomLeft();
    }

    public void gameStart()
    {
        gameStarted = true;
    }
    public bool hasGameStarted()
    {
        return gameStarted;
    }
}
