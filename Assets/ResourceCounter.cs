using UnityEngine;
using System.Collections;

public class ResourceCounter : MonoBehaviour
{

    private int faith = 0;
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
}
