using UnityEngine;
using System.Collections;
using System;
using UnityEngine.AI;

public class Wall : Building, Grabbable
{

    // Use this for initialization
    public int cost_per_meter = 10;
    public float turretRadius = 20f;

    public GameObject turretB = null;
    public GameObject turretA = null;
    public GameObject wallSegment = null;

    private GameObject turretHighlightA;
    private GameObject turretHighlightB;
    private Vector3 initialTurretA;
    private Vector3 initialTurretB;

    void Start()
    {
        createTurretHighlight();
        initialTurretA = new Vector3(10000,10000, 10000);
        initialTurretB = new Vector3(10000, 10000, 10000);
    }

    void Update()
    {
        turretHighlightA.transform.position = new Vector3(turretA.transform.position.x, 0.1f, turretA.transform.position.z);
        turretHighlightB.transform.position = new Vector3(turretB.transform.position.x, 0.1f, turretB.transform.position.z);
        if (held)
        {
            if (highlight != null)
            {
                if (highlightCheck())
                {
                    highlight.SetActive(true);
                    showTurretHighlight();
                }
                else
                {
                    highlight.SetActive(false);
                    hideTurretHighlight();
                }
            }
            else
            {
                hideTurretHighlight();
                highlight.SetActive(false);
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

    public override void highlightDestroy()
    {
        if (turretHighlightA != null)
        {
            turretHighlightA.SetActive(false);
            turretHighlightB.SetActive(false);
            highlight.SetActive(false);
        }
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

    private new int faithCost()
    {
        return cost_per_meter;
    }

    public override void die()
    {
        Destroy(turretHighlightA);
        Destroy(turretHighlightB);
        Destroy(gameObject);  
    }

    private void createTurretHighlight()
    {
        turretHighlightA = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        turretHighlightA.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
        turretHighlightA.transform.localScale = new Vector3(turretRadius, 0.1f, turretRadius);
        turretHighlightA.transform.position = new Vector3(turretA.transform.position.x, 0.1f, turretA.transform.position.z);
        turretHighlightA.transform.rotation = Quaternion.LookRotation(Vector3.forward);
        turretHighlightA.GetComponent<Collider>().enabled = false;
        turretHighlightA.GetComponent<Renderer>().enabled = true;
        turretHighlightA.SetActive(false);

        turretHighlightB = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        turretHighlightB.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
        turretHighlightB.transform.localScale = new Vector3(turretRadius, 0.1f, turretRadius);
        turretHighlightB.transform.rotation = Quaternion.LookRotation(Vector3.forward);
        turretHighlightB.GetComponent<Collider>().enabled = false;
        turretHighlightB.GetComponent<Renderer>().enabled = true;
        turretHighlightB.SetActive(false);
    }

    public override void activate()
    {
        if (highlight != null) highlightDestroy();
        held = false;
        int buildingLayer = 1 << 18;
        Collider[] turretAPoints = Physics.OverlapSphere(turretA.transform.position, turretRadius/2, buildingLayer);
        Collider[] turretBPoints = Physics.OverlapSphere(turretB.transform.position, turretRadius/2, buildingLayer);

        foreach (Collider collider in turretAPoints)
        {
            if (collider.gameObject.tag == "Turret" && collider.gameObject != turretA && collider.gameObject != turretB)
            {
                initialTurretB = turretB.transform.position;
                initialTurretA = turretA.transform.position;
                turretA.transform.position = collider.transform.position;
                turretA.transform.rotation = collider.transform.rotation;    
                alignWall(turretB.transform.position, turretA.transform.position);
            }
        }
        foreach (Collider collider in turretBPoints)
        {
            if (collider.gameObject.tag == "Turret" && collider.gameObject != turretA && collider.gameObject != turretB)
            {
                initialTurretA = turretA.transform.position;
                initialTurretB = turretB.transform.position;
                turretB.transform.position = collider.transform.position;
                turretB.transform.rotation = collider.transform.rotation;
                alignWall(turretA.transform.position, collider.transform.position);

            }
        }

    }

    private void alignWall(Vector3 pointA, Vector3 pointB)
    {
        Vector3 midPoint = pointA + (pointB - pointA) /2f; 
        float height = wallSegment.transform.localScale.y;

        wallSegment.transform.position = new Vector3(midPoint.x, height/2, midPoint.z);    
        wallSegment.transform.localScale = new Vector3(wallSegment.transform.localScale.x, wallSegment.transform.localScale.y, (pointB - pointA).magnitude);
        wallSegment.transform.LookAt(pointB + Vector3.up*(height/2));

        BoxCollider wallCollider = this.GetComponent<BoxCollider>();
        NavMeshObstacle obstacle = GetComponent<NavMeshObstacle>();

        obstacle.size = new Vector3(obstacle.size.x, obstacle.size.y, 1+(pointB - pointA).magnitude);
        wallCollider.center = wallSegment.transform.localPosition;
        obstacle.center = wallSegment.transform.localPosition;  
    }


    private void resetWall()
    {
        turretA.transform.position = initialTurretA;
        turretB.transform.position = initialTurretB;

        float height = wallSegment.transform.localScale.y;
        Vector3 midPoint = turretA.transform.position + (turretB.transform.position - turretA.transform.position) / 2f;

        wallSegment.transform.position = new Vector3(midPoint.x, height / 2, midPoint.z);
        wallSegment.transform.localScale = new Vector3(wallSegment.transform.localScale.x, wallSegment.transform.localScale.y, (turretB.transform.position - turretA.transform.position).magnitude);
        wallSegment.transform.LookAt(turretB.transform.position + Vector3.up * (height / 2));
    }

    void Grabbable.grab()
    {
        base.grab();    

        //if I have already placed the wall once 
        if (initialTurretA != new Vector3(10000, 10000, 10000))
        {
            resetWall();
        }
        showTurretHighlight();
    }

   void Grabbable.release(Vector3 vel)
    {
        base.release(vel);
        hideTurretHighlight();
    }

    private void showTurretHighlight()
    {
        turretHighlightA.SetActive(true);
        turretHighlightB.SetActive(true);
    }

    private void hideTurretHighlight()
    {
        turretHighlightA.SetActive(false);
        turretHighlightB.SetActive(false);
    }

    public override void deactivate()
    {
    }

    public override void create_building()
    {
    }
}
