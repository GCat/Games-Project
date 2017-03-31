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

    private float animLength = 0.833f;
    private float animSpeed = 1f;
    public float delayStart;
    Vector3 pos;
    AudioClip attackClip;
    AudioSource asource;
    Animation anim;
    GameObject playerHead;
    public GameObject godRay;

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
        GameObject newSpawner = Instantiate(spawner, transform.position + Vector3.up*20 - Vector3.left*20, Quaternion.identity);
        newSpawner.GetComponentInChildren<BuildingSpawner>().buildingToSpawn = newBuilding;
        newSpawner.GetComponentInChildren<TextMesh>().text = newBuilding.GetComponent<Building>().description;
        godRay.SetActive(true);
        enableGodRay();
    }

    public void disableGodRay()
    {
        godRay.SetActive(false);
    }

    public void enableGodRay()
    {
        godRay.SetActive(true);
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
            for(int i=0; i < 10; i++) {
                if (allDead(spawnedMonsters))
                {
                    break;
                }
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