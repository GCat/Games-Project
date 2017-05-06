using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using System;

public class Temple : Building
{

    public bool spawnedGarrison = false;
    public WorldStarter world;
    public bool placed = false;
    public int startingHumans = 5;
    public AudioClip warningClip;
    private bool warningDelay = false;

    public override void create_building()
    {
        world.startGame();
        tablet.SetActive(true);
        placed = true;
        StartCoroutine(spawnHumans());
        InvokeRepeating("incrementResource", 10.0f, 10.0f); // after 10 sec call every 5
        canBeGrabbed = false;
        resourceCounter.gameStart();
    }

    void Update()
    {
        if (held)
        {
            if (highlight != null)
            {
                highlightCheck();
            }
        }
    }

    public override void decrementHealth(float damage)
    {
        base.decrementHealth(damage);
        StartCoroutine(warnPlayer());
    }

    IEnumerator warnPlayer()
    {
        if (!warningDelay)
        {
            world.portal.voiceOverSource.PlayOneShot(warningClip, 1.2f);
            warningDelay = true;
            yield return new WaitForSeconds(20f);
        }

    }
    public bool isPlaced()
    {
        return placed;
    }

    public void resetPosition()
    {
        transform.position = GameObject.FindGameObjectWithTag("Portal").transform.position + Vector3.up * 20 + Vector3.right * 40;
    }
    public void incrementResource()
    {
    }


    IEnumerator spawnHumans()
    {
        yield return new WaitForSeconds(0.2f);
        Vector3 myLocation = transform.position;
        Debug.Log("Spawning humans");

        // can not spawn on resource node
        Vector3 humanLocation;
        humanLocation = new Vector3(myLocation.x, myLocation.y, myLocation.z + 33);
        for (int i = 0; i < startingHumans; i++)
        {
            if (resourceCounter.aboveBoard(myLocation))
            {
                NavMeshHit hit;
                if (NavMesh.SamplePosition(humanLocation, out hit, 50.0f, NavMesh.AllAreas))
                {
                    Instantiate(Resources.Load("Characters/Human"), hit.position, Quaternion.identity);
                }else
                {
                    Debug.Log("Could not spawn human");
                }
            }else
            {
                Debug.Log("Not above board");
            }
            humanLocation = rotateAroundPivot(humanLocation, myLocation, new Vector3(0, (360 / 5), 0));
        }
        spawnedGarrison = true;
    }

    Vector3 rotateAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        Vector3 dir = point - pivot;
        dir = Quaternion.Euler(angles) * dir;
        point = dir + pivot;
        return point;
    }

    //This stops the game
    public override void die()
    {
        this.enabled = false;
        world.stopGame();
        Destroy(gameObject);
    }

    public override string getName()
    {
        return "Temple";
    }

    public override Vector3 getLocation()
    {
        return transform.position;
    }

    public override void activate()
    {
        create_building();
        held = false;
        highlightDestroy();
    }

    public override void deactivate()
    {

    }

    public override void OnTriggerEnter(Collider other)
    {
        if (!placed) base.OnTriggerEnter(other);
    }
}
