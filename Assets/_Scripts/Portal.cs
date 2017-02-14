using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    /*
    * Distribution states probability of  spawingn any of the four clases, it shoud add up to one
    * {Rushers, Defender, Killer, Training} 
    */

    bool active = false;

    // behaviour 0  uses maxSpawns and spawns at constant rate behaviour 1 spawns exponentialy
    private int behaviour;
    private int maxSpawns;
    public int spawns = 0;

    public float coef = 10f;

    float[] distribution = new float[] { 0f, 0f, 0f, 0f };

    // frequency of spawning
    float frequency;
    float timer;
    float startTime;

    // delay befire first spawn
    float delayStart;
    float delay = 20f;
    GameObject temple;

    void Start () {
        temple = GameObject.FindGameObjectWithTag("Temple");
    }
	
	void Update () {
        if (active )
        {
            if (Time.time - delayStart > delay)
            {
                if (behaviour == 0 && spawns < maxSpawns)
                {
                    timer = Time.time - startTime;
                    if (timer >= frequency)
                    {
                        spawn();
                    }
                }
                else if(behaviour == 1)
                {
                    if(frequency > 1)
                    {
                        frequency = 21 - Mathf.Pow(2.71f, spawns/coef);
                    }
                    timer = Time.time - startTime;
                    if (timer >= frequency)
                    {
                        spawn();
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
                setup(1, new float[] { 1f, 0f, 0f, 0f }, 21.0f);
            }
        }
	}

    void spawn()
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

    void setup(float frequency, int type, int maxSpawns)
    {
        active = true;
        startTime = Time.time;
        this.frequency = frequency;
        distribution[type] = 1;
        this.maxSpawns = maxSpawns;
        behaviour = 0;

    }

    void setup(float frequency, float[] distribution, int maxSpawns)
    {
        active = true;
        startTime = Time.time;
        this.frequency = frequency;
        this.distribution = distribution;
        this.maxSpawns = maxSpawns;
        behaviour = 0;


    }

    void setup()
    {
        active = true;
        startTime = Time.time;
        this.frequency = 10;
        this.distribution = new float[] { 0.25f, 0.25f, 0.25f, 0.25f };
        maxSpawns = 3;
        behaviour = 0;

    }

    void setup(int behaviour, float[] distribution, float f)
    {
        active = true;
        startTime = Time.time;
        maxSpawns = -1;
        this.frequency = f;
        this.behaviour = behaviour;
        this.distribution = distribution;

    }
    void deactivate()
    {
        active = false;
    }
}
