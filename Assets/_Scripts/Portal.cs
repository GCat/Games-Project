using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    /*
    * Distribution states probability of  spawingn any of the four clases, it shoud add up to one
    * {Rushers, Defender, Killer, Training} 
    */
    bool active = false;
    private int maxSpawns;
    public int spawns = 0;
    float[] distribution = new float[] { 0f, 0f, 0f, 0f };
    float frequency;
    float timer;
    float startTime;
    float delayStart;
    float delay = 60f;
    GameObject temple;
    // Use this for initialization
    void Start () {
        temple = GameObject.FindGameObjectWithTag("Temple");
    }
	
	// Update is called once per frame
	void Update () {
        if (active && spawns < maxSpawns)
        {
            if (Time.time - delayStart > delay)
            {
                timer = Time.time - startTime;
                if (timer >= frequency)
                {
                    Vector3 pos = transform.GetChild(0).transform.position;
                    pos.y = 0.0f;
                    if (Mathf.Abs(pos.x) < 50 && Mathf.Abs(pos.z) < 100)
                    {
                        GameObject pre = Resources.Load("Characters/Badie") as GameObject;
                        GameObject b = GameObject.Instantiate(pre, pos, Quaternion.identity);
                        float val = Random.Range(0.0f, 1.0f);
                        if (val < distribution[0]) ((BadiesAI)b.GetComponent(typeof(BadiesAI))).spawn(0);
                        else if (val < distribution[0] + distribution[1]) ((BadiesAI)b.GetComponent(typeof(BadiesAI))).spawn(1);
                        else if (val < distribution[0] + distribution[1] + distribution[2]) ((BadiesAI)b.GetComponent(typeof(BadiesAI))).spawn(2);
                        else if (val < distribution[0] + distribution[1] + distribution[2] + distribution[3]) ((BadiesAI)b.GetComponent(typeof(BadiesAI))).spawn(3);
                        startTime = Time.time;
                        spawns++;

                    }
                    else
                    {
                        Debug.Log("Could not spawn");
                    }
                }
            }
        }
        else if (temple != null)
        {
            if (temple.GetComponent<Temple>().isPlaced())
            {
                Debug.Log("temple has been placed");
                delayStart = Time.time;
                setup(10.0f, new float[] { 1f, 0f, 0f, 0f }, 10);
            }
        }
	}

    void setup(float frequency, int type, int maxSpawns)
    {
        active = true;
        startTime = Time.time;
        this.frequency = frequency;
        distribution[type] = 1;
        this.maxSpawns = maxSpawns;

    }

    void setup(float frequency, float[] distribution, int maxSpawns)
    {
        active = true;
        startTime = Time.time;
        this.frequency = frequency;
        this.distribution = distribution;
        this.maxSpawns = maxSpawns;


    }

    void setup()
    {
        active = true;
        startTime = Time.time;
        this.frequency = 10;
        this.distribution = new float[] { 0.25f, 0.25f, 0.25f, 0.25f };
        maxSpawns = 3;

    }

    void deactivate()
    {
        active = false;
    }
}
