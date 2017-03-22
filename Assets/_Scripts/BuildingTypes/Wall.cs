using UnityEngine;
using System.Collections;
using System;
using UnityEngine.AI;

public class Wall : Building, Grabbable
{

    // Use this for initialization
    public int cost_per_meter = 10;
    public bool held = false;

    public GameObject turretB = null;
    public GameObject turretA = null;
    public GameObject wallSegment = null;
    private Vector3 originalScale;
    private Quaternion originalRotation;
    public float adjustRange = 15.0f;
    void Start()
    {
        originalScale = wallSegment.transform.localScale;
        originalRotation = wallSegment.transform.rotation;
    }

    // Update is called once per frame
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

    public override string getName()
    {
        return "Wall";
    }


    public override Vector3 getLocation()
    {
        return this.gameObject.transform.position;
    }

    public override bool canBuy()
    {
        if (!bought && (resourceCounter.faith >= faithCost()))
        {
            bought = true;
            resourceCounter.removeFaith(faithCost());
            return true;
        }
        return false;
    }

    private int faithCost()
    {
        return cost_per_meter;
    }

    public override void die()
    {
        Destroy(gameObject);
    }

    public override void create_building()
    {
        // WALL SNAPPING WITH EACH OTHER CODE HERE I FAILED MISERABLY
    }

    //Don't need this 
    public override void activate()
    {
        create_building();
        if (highlight != null) highlightDestroy();
        held = false;
        int buildingLayer = 1 << 18;
        Collider[] turretAPoints = Physics.OverlapSphere(turretA.transform.position, 10f, buildingLayer);
        Collider[] turretBPoints = Physics.OverlapSphere(turretB.transform.position, 10f, buildingLayer);

        foreach (Collider collider in turretAPoints)
        {
            if (collider.gameObject.tag == "Turret" && collider.gameObject != turretA && collider.gameObject != turretB)
            {
                Debug.Log("Joining wall segments");
                turretA.SetActive(false);
                alignWall(turretB.transform.position, collider.transform.position);
                turretA.transform.position = collider.transform.position;
            }
        }
        foreach (Collider collider in turretBPoints)
        {
            if (collider.gameObject.tag == "Turret" && collider.gameObject != turretA && collider.gameObject != turretB)
            {
                Debug.Log("Joining wall segments");
                turretB.SetActive(false);
                alignWall(turretA.transform.position, collider.transform.position);
                turretB.transform.position = collider.transform.position;

            }
        }

    }


    private void alignWall(Vector3 pointA, Vector3 pointB)
    {
        Vector3 midPoint = pointA + (pointB - pointA) / 2f;
        float height = wallSegment.transform.localScale.y;
        wallSegment.transform.position = midPoint + Vector3.up * (height / 2);
        wallSegment.transform.localScale = new Vector3(wallSegment.transform.localScale.x, wallSegment.transform.localScale.y, (pointB - pointA).magnitude);
        wallSegment.transform.LookAt(pointB + Vector3.up * (height / 2));
        BoxCollider wallCollider = GetComponent<BoxCollider>();
        wallCollider.size = new Vector3(wallCollider.size.x, wallCollider.size.y, 10 + (pointB - pointA).magnitude);
        NavMeshObstacle obstacle = GetComponent<NavMeshObstacle>();
        obstacle.size = new Vector3(obstacle.size.x, obstacle.size.y, 10 + (pointB - pointA).magnitude);
    }

    //Don't need this
    public override void deactivate()
    {
    }

    public void grab()
    {
        turretA.SetActive(true);
        turretB.SetActive(true);
        // Deactivate  collider and gravity
        if (highlight != null)
        {
            DestroyImmediate(highlight);
        }
        held = true;
        // highlight where object wiould place if falling straight down
        createHighlight();
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;

    }
}
