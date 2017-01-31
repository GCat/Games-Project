using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    bool active = false;
    private int maxSpawns = 1;
    public int spawns = 0;
    float[] distribution = new float[] { 0f, 0f, 0f, 0f };
    float frequency;
    float timer;
    float startTime;
    // Use this for initialization
    void Start () {

        setup(10.0f, new float[] { 0f, 0f, 0f, 1f },1);
		
	}
	
	// Update is called once per frame
	void Update () {
        if (active && spawns < maxSpawns)
        {
            timer = Time.time - startTime;
            if(timer >= frequency)
            {
                Vector3 pos = transform.GetChild(0).transform.position;
                pos.y = 0.0f;
                if(Mathf.Abs(pos.x) < 50 && Mathf.Abs(pos.z) < 100 )
                {
                    GameObject pre = Resources.Load("Badie") as GameObject;
                    GameObject b = GameObject.Instantiate(pre, pos ,Quaternion.identity);
                    float val = Random.Range(0.0f, 1.0f);
                    if(val < distribution[0]) ((BadiesAI)b.GetComponent(typeof(BadiesAI))).spawn(0);
                    else if (val < distribution[0]+ distribution[1]) ((BadiesAI)b.GetComponent(typeof(BadiesAI))).spawn(1);
                    else if (val < distribution[0] + distribution[1] + distribution[2]) ((BadiesAI)b.GetComponent(typeof(BadiesAI))).spawn(2);
                    else if (val < distribution[0] + distribution[1] + distribution[2] +distribution[3]) ((BadiesAI)b.GetComponent(typeof(BadiesAI))).spawn(3);
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
