using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    bool active = false;

    public GameObject spawnPos;
    Vector3 pos;
    AudioClip attackClip;
    AudioSource asource;

    // delay befire first spawn
    float delayStart;
    float delay = 30f;

    GameObject temple;
    GameObject pre;
    ResourceCounter resourceCounter;

    int nWaves = 5;
    int baddieTypes = 3;
    int currentType = 0;
    float betweenWaveDelay = 40f;
    float wavetimer;
    float delayBetweenBadies = 2f;
    float baddietimer;
    int spawns = 0;
    bool waveSpawnning = true;
    bool allDead = true;
    int waveNumber = 0;
    bool waveFinished = false;
    /*
     * Array of ints describes number of baddies to be spawn per wave
     * len(waves) = nWaves * baddieTypes
     * Current array contains number of rushers 
     */
    int[] waves = new int[] {4, 2, 5, 3, 7, 8, 4, 10, 12, 15, 20, 30, 50, 42, 36};
    void Start () {
        temple = GameObject.FindGameObjectWithTag("Temple");
        pre = Resources.Load("Characters/Badie") as GameObject;
        resourceCounter = GameObject.FindGameObjectWithTag("Tablet").GetComponent<ResourceCounter>();
        pos = spawnPos.transform.position;
        asource = GetComponent<AudioSource>();
    }
	
	void Update () {
        if (waveFinished) return;
        if(temple == null)
        {
            return;
        }
        if (active)
        {
            if (Time.time - delayStart > delay)
            {
                if (waveSpawnning)
                {
                    spawnWave();
                }
                else
                {
                    if (resourceCounter.baddies == 0)
                    {
                        if(Time.time - wavetimer > betweenWaveDelay)
                        {
                            waveSpawnning = true;
                            waveNumber++;
                        }
                    }
                }
            }
        }
        else if (temple != null)
        {
            if (temple.GetComponent<Temple>().isPlaced())
            {
                delayStart = Time.time;
                active = true;
                wavetimer = Time.time;
            }
        }
	}

    void spawnWave()
    {
        pos.y = 0.0f;
        if (resourceCounter.withinBounds(pos))
        {
            if (spawns == 0)
            {
                if (waves[waveNumber * baddieTypes + currentType] > 0)
                {
                    asource.Play();
                    GameObject b = GameObject.Instantiate(pre, pos, Quaternion.identity);
                    b.GetComponent<BadiesAI>().spawn(currentType);
                    spawns++;
                    baddietimer = Time.time;
                }
                else if (currentType < baddieTypes - 1) currentType++;
                else
                {
                    waveNumber++;
                    currentType = 0;
                }
            }
            else if (Time.time - baddietimer > delayBetweenBadies)
            {
                if (waveNumber * baddieTypes +currentType> waves.Length)
                {
                    waveFinished = true;
                }
                else if (spawns < waves[waveNumber * baddieTypes + currentType])
                {
                    asource.Play();
                    GameObject b = GameObject.Instantiate(pre, pos, Quaternion.identity);
                    b.GetComponent<BadiesAI>().spawn(currentType);
                    spawns++;
                    baddietimer = Time.time;
                }
                else if (currentType < baddieTypes - 1)
                {
                    spawns = 0;
                    currentType++;
                    baddietimer = Time.time;
                }
                else
                {
                    waveSpawnning = false;
                    spawns = 0;
                    currentType=0;
                    wavetimer = Time.time;
                }
                
            }
            
        }
        else
        {
            Debug.Log("Could not spawn");
        }
    }

    void spawn()
    {
        pos.y = 0.0f;
        if (resourceCounter.withinBounds(pos))
        {
            asource.Play();
            GameObject b = GameObject.Instantiate(pre, pos, Quaternion.identity);
            b.GetComponent<BadiesAI>().spawn(0);
        }
        else
        {
            Debug.Log("Could not spawn");
        }
    }

    void deactivate()
    {
        active = false;
    }

}
