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

    public GameObject spawnerLocationsParent;
    private List<Transform> spawnerLocations;
    public HashSet<GameObject> clouds;
    public WorldStarter worldstarter;
    private float animLength = 0.833f;
    private float animSpeed = 1f;
    public float delayStart;
    Vector3 pos;
    AudioClip attackClip;
    AudioSource asource;
    public AudioClip teleport;
    Animation anim;
    GameObject playerHead;

    Vector3 originalPos;

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
        originalPos = transform.position;
        spawnerLocations = new List<Transform>();
        foreach (Transform child in spawnerLocationsParent.transform)
        {
            spawnerLocations.Add(child);
        }
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


    private bool cloudPositionFilled(Transform c)
    {
        foreach (GameObject cloud in clouds)
        {
            if (Vector3.Distance(cloud.transform.position, c.position) < 10f)
            {
                return true;
            }
        }
        return false;
    }

    //creates a new spawner with a new tool/ building for the player
    void spawnNewBuilding(GameObject newBuilding)
    {
        Vector3 spPos = spawnerLocations[0].position;
        if (clouds.Count > 0)
        {
            foreach (Transform pos in spawnerLocations)
            {
                if (!cloudPositionFilled(pos))
                {
                    spPos = pos.position;
                    break;
                }
            }
        }

        GameObject newSpawner = Instantiate(spawner, spPos, Quaternion.identity);
        newSpawner.GetComponentInChildren<BuildingSpawner>().buildingToSpawn = newBuilding;
        newSpawner.GetComponentInChildren<BuildingSpawner>().newBuilding();
        newSpawner.GetComponentInChildren<BuildingSpawner>().rayDisappear(30f);
        if (newBuilding.GetComponent<Building>() != null && newBuilding.GetComponent<Building>().description != null)
        {
            newSpawner.GetComponentInChildren<TextMesh>().text = newBuilding.GetComponent<Building>().description;
        }
        clouds.Add(newSpawner);
    }

    bool allDead(List<GameObject> monsters)
    {
        for (int i = 0; i < monsters.Count; i++)
        {
            if (monsters[i] != null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator spawnWaves()
    {
        //coundown animation
        animSpeed = animLength / delayStart;
        anim["Countdown"].speed = animSpeed;
        anim.Play("Countdown");
        yield return new WaitForSeconds(delayStart);
        foreach (Wave wave in Waves)
        {
            List<GameObject> spawnedMonsters = new List<GameObject>();
            asource.Play();

            if (wave.waveEvent != null)
            {
                wave.waveEvent.startEvent();
            }

            //spawn each monster with a 1 second delay
            foreach (MonsterType monsterType in wave.monsters)
            {
                Vector3 validSpawnLoc = spawnPos.transform.position;
                NavMeshHit hit;
                if (NavMesh.SamplePosition(spawnPos.transform.position, out hit, 40.0f, NavMesh.AllAreas))
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


            while (!allDead(spawnedMonsters)) {
                yield return new WaitForSeconds(1);
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
        worldstarter.stopGame();
    }

    public void movePortal()
    {
        GameObject[] movepoints = GameObject.FindGameObjectsWithTag("PortalMove");
        if (movepoints.Length > 0)
        {
            GameObject p = Resources.Load("Particles/teleport1") as GameObject;
            int index = Random.Range(0, movepoints.Length - 1);
            NavMeshHit hit;
            if (NavMesh.SamplePosition(movepoints[index].transform.position, out hit, 80f, NavMesh.AllAreas))
            {
                asource.PlayOneShot(teleport);
                GameObject teleportParticles = Instantiate(p, transform.position, Quaternion.LookRotation(Vector3.up));
                StartCoroutine(moveP(hit.position, teleportParticles));


            }
        }
    }

    IEnumerator moveP(Vector3 pos, GameObject particles)
    {
        yield return new WaitForSeconds(3f);
        transform.position = pos;
        if (temple != null) transform.LookAt(Vector3.forward);
        DestroyImmediate(particles);


    }

}