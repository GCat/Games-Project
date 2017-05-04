using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

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

    public WorldStarter worldstarter;
    private float animLength = 0.833f;
    private float animSpeed = 1f;
    public float delayStart;
    Vector3 pos;

    Animation anim;
    GameObject playerHead;

    Vector3 originalPos;

    GameObject temple;
    ResourceCounter resourceCounter;

    private float startTime;
    bool started = false;
    MonsterType currentType = 0;
    GameObject spawner;


    public AudioMixerSnapshot outOfCombat;
    public AudioMixerSnapshot inCombat;
    public AudioClip battleMusic;
    public AudioClip peaceMusic;
    public AudioClip transition;
    public AudioClip teleport;
    public AudioClip party;
    AudioSource asource;

    void Start()
    {
        spawner = Resources.Load("cloud_spawner") as GameObject;
        temple = GameObject.FindGameObjectWithTag("Temple");
        resourceCounter = GameObject.FindGameObjectWithTag("Tablet").GetComponent<ResourceCounter>();
        pos = spawnPos.transform.position;
        asource = GetComponent<AudioSource>();
        asource.clip = peaceMusic;
        startTime = Time.time;
        anim = GetComponentInChildren<Animation>();
        playerHead = GameObject.FindGameObjectWithTag("MainCamera");
        originalPos = transform.position;
        spawnerLocations = new List<Transform>();
        foreach (Transform child in spawnerLocationsParent.transform)
        {
            spawnerLocations.Add(child);
        }
        asource.Play();
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
            try
            {
                StartCoroutine(spawnWaves());
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }
        }

    }


    //creates a new spawner with a new tool/ building for the player
    void spawnNewBuilding(GameObject newBuilding)
    {
        Vector3 spPos = Vector3.zero;

        foreach (Transform pos in spawnerLocations)
        {
            if (!Physics.CheckSphere(pos.position, 15f))
            {
                spPos = pos.position;
                GameObject newSpawner = Instantiate(spawner, spPos, Quaternion.identity);
                newSpawner.GetComponentInChildren<BuildingSpawner>().buildingToSpawn = newBuilding;
                newSpawner.GetComponentInChildren<BuildingSpawner>().newBuilding();
                newSpawner.GetComponentInChildren<BuildingSpawner>().rayDisappear(30f);
                return;
            }

        }
        Debug.Log("Fuck sake");


        //if (newBuilding.GetComponent<Building>() != null && newBuilding.GetComponent<Building>().description != null)
        //{
        //    newSpawner.GetComponentInChildren<TextMesh>().text = newBuilding.GetComponent<Building>().description;
        //}
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


    public void gameOver(bool success)
    {
        asource.clip = party;
        asource.Play();

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
            if (wave.waveEvent != null)
            {
                wave.waveEvent.startEvent();
            }
            transitionMusic(true);
            //spawn each monster with a 1 second delay
            foreach (MonsterType monsterType in wave.monsters)
            {
                Vector3 validSpawnLoc = spawnPos.transform.position;
                NavMeshHit hit;
                if (NavMesh.SamplePosition(spawnPos.transform.position, out hit, 20.0f, NavMesh.AllAreas))
                {
                    validSpawnLoc = hit.position;
                    GameObject monster = Instantiate(monsterTypes[(int)monsterType], validSpawnLoc, Quaternion.LookRotation(Vector3.forward, Vector3.up));
                    spawnedMonsters.Add(monster);
                }
                else
                {
                    Debug.LogError("Could not spawn monster");
                }


                yield return new WaitForSeconds(2);
            }


            while (!allDead(spawnedMonsters))
            {
                yield return new WaitForSeconds(1);
            }
            transitionMusic(false);
            if (wave.newBuilding != null)
            {
                spawnNewBuilding(wave.newBuilding);
            }
            resourceCounter.faith += wave.faithReward;
            //coundown animation
            animSpeed = animLength / wave.waveTime;
            anim["Countdown"].speed = animSpeed;
            anim.Play("Countdown");
            yield return new WaitForSeconds(wave.waveTime);
        }
        //worldstarter.stopGame();
    }

    void transitionMusic(bool toBattle)
    {
        if (toBattle)
        {
            StartCoroutine(playBattleMusic());

        }
        else
        {
            inCombat.TransitionTo(6f);
            asource.clip = peaceMusic;
            asource.Play();
        }

    }

    IEnumerator playBattleMusic()
    {
        asource.PlayOneShot(transition);
        yield return new WaitForSeconds(4f);
        outOfCombat.TransitionTo(1f);
        asource.clip = battleMusic;
        asource.Play();
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