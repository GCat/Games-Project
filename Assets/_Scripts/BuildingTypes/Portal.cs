using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Portal : MonoBehaviour
{

    bool active = false;
    [System.Serializable]
    public enum MonsterType { Monster, Minataur, Harpy, BossMinataur, BossGolem };

    [SerializeField]
    public Wave[] Waves;
    public GameObject spawnPos;
    public GameObject[] monsterTypes;

    public HashSet<GameObject> clouds;

    private float animLength = 0.833f;
    private float animSpeed = 1f;
    public float delayStart;
    Vector3 pos;
    AudioClip attackClip;
    AudioSource asource;
    Animation anim;
    GameObject playerHead;

    GameObject temple;
    ResourceCounter resourceCounter;

    private float startTime;
    bool started = false;
    MonsterType currentType = 0;
    GameObject spawner;

    void Start()
    {
        spawner = Resources.Load("cloud_spawner") as GameObject;
        temple = GameObject.FindGameObjectWithTag("Temple");
        resourceCounter = GameObject.FindGameObjectWithTag("Tablet").GetComponent<ResourceCounter>();
        pos = spawnPos.transform.position;
        asource = GetComponent<AudioSource>();
        startTime = Time.time;
        anim = GetComponentInChildren<Animation>();
        playerHead = GameObject.FindGameObjectWithTag("MainCamera");
        clouds = new HashSet<GameObject>();
    }

    void Update()
    {
        if (temple == null)
        {
            return;
        }
        if (!started && temple.GetComponent<Temple>().isPlaced())
        {
            started = true;
            StartCoroutine(spawnWaves());
        }

    }

    //creates a new spawner with a new tool/ building for the player
    void spawnNewBuilding(GameObject newBuilding)
    {
        Vector3 spPos = transform.position;
        spPos.y += 20f;
        spPos.x += 10f;

        if(clouds.Count > 0)
        {
            float dis = 100000f;
            int iterations = 0;
            do
            {
                if (iterations > 20) {
                    Debug.Log("shit");
                    break;
                }
                foreach (GameObject c in clouds)
                {
                    if (Vector3.Distance(spPos,c.transform.position) < dis)
                    {
                        dis = Vector3.Distance(spPos, c.transform.position);
                    }
                }
                if (dis < 10f)
                {
                    float z = Random.Range(-30f, 30f);
                    float x = Random.Range(-15f, -70f);
                    spPos = new Vector3(x, spPos.y, z);
                }
                iterations++;
            } while (dis < 10f);

            GameObject newSpawner = Instantiate(spawner, spPos, Quaternion.identity);
            newSpawner.GetComponentInChildren<BuildingSpawner>().buildingToSpawn = newBuilding;
            newSpawner.GetComponentInChildren<BuildingSpawner>().newBuilding();
            newSpawner.GetComponentInChildren<TextMesh>().text = newBuilding.GetComponent<Building>().description;
            clouds.Add(newSpawner);
        }
        else
        {
            GameObject newSpawner = Instantiate(spawner, spPos, Quaternion.identity);
            newSpawner.GetComponentInChildren<BuildingSpawner>().buildingToSpawn = newBuilding;
            newSpawner.GetComponentInChildren<BuildingSpawner>().newBuilding();
            newSpawner.GetComponentInChildren<TextMesh>().text = newBuilding.GetComponent<Building>().description;
            clouds.Add(newSpawner);
        }

 
         
        

    }


    bool allDead(List<GameObject> monsters)
    {
        for(int i=0; i < monsters.Count; i++)
        {
            if(monsters[i] != null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator spawnWaves()
    {     
        //coundown animation
        animSpeed= animLength / delayStart;
        anim["Countdown"].speed = animSpeed;
        anim.Play("Countdown");
        yield return new WaitForSeconds(delayStart);
        foreach (Wave wave in Waves)    
        {
            List<GameObject> spawnedMonsters = new List<GameObject>();
            asource.Play();

            if(wave.waveEvent != null)
            {
                wave.waveEvent.startEvent();
            }

            //spawn each monster with a 1 second delay
            foreach (MonsterType monsterType in wave.monsters)
            {
                Vector3 validSpawnLoc = pos;
                NavMeshHit hit;
                if (NavMesh.SamplePosition(pos, out hit, 40.0f, NavMesh.AllAreas))
                {
                    validSpawnLoc = hit.position;
                }
                else
                {
                    Debug.LogError("Could not spawn monster");
                }             
                GameObject monster = GameObject.Instantiate(monsterTypes[(int)monsterType], validSpawnLoc, Quaternion.identity);
                spawnedMonsters.Add(monster);
                //monster.GetComponent<Character>().agent.Warp(validSpawnLoc);
                yield return new WaitForSeconds(2);
            }
            while (!allDead(spawnedMonsters))
            {
                yield return new WaitForSeconds(2);
            }
            if (wave.newBuilding != null)
            {
                spawnNewBuilding(wave.newBuilding);
            }
            //coundown animation
            animSpeed = animLength / wave.waveTime;
            anim["Countdown"].speed = animSpeed;
            anim.Play("Countdown");
            yield return new WaitForSeconds(wave.waveTime);
        }
    }

}