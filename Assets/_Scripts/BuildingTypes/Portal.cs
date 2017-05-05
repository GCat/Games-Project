using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class Portal : MonoBehaviour
{


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

    Animation anim;


    GameObject temple;
    ResourceCounter resourceCounter;

    bool started = false;

    GameObject spawner;

    enum AudioTransition { Battle, Peace, VoiceOver };

    public AudioSource voiceOverSource;
    public AudioMixerSnapshot outOfCombat;
    public AudioMixerSnapshot inCombat;
    public AudioMixerSnapshot voiceOver;
    public AudioClip battleMusic;
    public AudioClip peaceMusic;
    public AudioClip teleport;
    public AudioClip party;
    AudioSource asource;

    void Start()
    {
        spawner = Resources.Load("cloud_spawner") as GameObject;
        temple = GameObject.FindGameObjectWithTag("Temple");
        resourceCounter = GameObject.FindGameObjectWithTag("Tablet").GetComponent<ResourceCounter>();
        asource = GetComponent<AudioSource>();
        asource.clip = peaceMusic;
        anim = GetComponentInChildren<Animation>();
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
                StartCoroutine(tutorial());
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }
        }

    }


    IEnumerator tutorial()
    {
        yield return new WaitForSeconds(10f);

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
            transitionMusic(AudioTransition.Battle, 2f);
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
            //transitionMusic(AudioTransition.VoiceOver, 10f);
            if (wave.newBuilding != null)
            {
                spawnNewBuilding(wave.newBuilding);
                Building b = wave.newBuilding.GetComponent<Building>();
                if (b != null && b.buildClip != null)
                {
                    voiceOverSource.clip = b.buildClip;
                    voiceOverSource.Play();
                }
                else if (wave.newBuilding.GetComponent<LightningBolt>())
                {
                    voiceOverSource.clip = wave.newBuilding.GetComponent<LightningBolt>().buildClip;
                    voiceOverSource.Play();
                }
            }
            transitionMusic(AudioTransition.Peace, 10f);
            resourceCounter.faith += wave.faithReward;
            //coundown animation
            animSpeed = animLength / wave.waveTime;
            anim["Countdown"].speed = animSpeed;
            anim.Play("Countdown");
            yield return new WaitForSeconds(wave.waveTime);
        }
        worldstarter.stopGame();
    }

    void transitionMusic(AudioTransition transition, float transitionTime)
    {

        switch (transition)
        {
            case AudioTransition.Battle:
                inCombat.TransitionTo(5f);
                asource.clip = battleMusic;
                asource.Play();
                break;
            case AudioTransition.Peace:
                outOfCombat.TransitionTo(transitionTime);
                asource.clip = peaceMusic;
                asource.Play();
                break;
            case AudioTransition.VoiceOver:
                
                break;

        }


    }

    IEnumerator playMusicClip(float waitTime, AudioClip clip)
    {
        yield return new WaitForSeconds(waitTime);
        asource.clip = clip;
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