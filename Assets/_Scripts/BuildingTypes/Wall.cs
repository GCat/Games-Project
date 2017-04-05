using UnityEngine;
using System.Collections;
using System;
using UnityEngine.AI;

public class Wall : Building
{

    // Use this for initialization
    public int cost_per_meter = 10;
    public float turretRadius = 20f;

    public WallTurret turretB = null;
    public WallTurret turretA = null;
    public GameObject wallSegment = null;

    private GameObject turretHighlightB;
    private Vector3 initialTurretA;
    private Vector3 initialTurretB;

    void Start()
    {
        createTurretHighlight();
        initialTurretA = new Vector3(10000, 10000, 10000);
        initialTurretB = new Vector3(10000, 10000, 10000);
        turretA.canBeGrabbed = false;
        turretB.canBeGrabbed = true;
        turretA.GetComponent<Collider>().enabled = false;
        turretB.GetComponent<Collider>().enabled = false;

    }

    void Update()
    {

        if (held)
        {
            turretA.adjustHighlight();
            turretB.adjustHighlight();
            if (highlight != null)
            {
                if (highlightCheck()) showTurretHighlight();
                else hideTurretHighlight();
            }
            else
            {
                hideTurretHighlight();
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
        highlight.SetActive(false);
        turretA.highlightDestroy();
        turretB.highlightDestroy();
    }

    private new int faithCost()
    {
        return cost_per_meter;
    }

    public override void die()
    {
        turretA.die();
        turretB.die();
        Destroy(gameObject);
    }

    private void createTurretHighlight()
    {
        turretA.createHighlight(turretRadius);
        turretB.createHighlight(turretRadius);
    }

    public override void activate()
    {
        if (highlight != null) highlightDestroy();
        held = false;
        int buildingLayer = 1 << 10;
        Collider[] turretAPoints = Physics.OverlapSphere(turretA.transform.position, turretRadius / 2, buildingLayer);
        Collider[] turretBPoints = Physics.OverlapSphere(turretB.transform.position, turretRadius / 2, buildingLayer);
        initialTurretA = turretA.transform.position;
        initialTurretB = turretB.transform.position;


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
                alignWall(turretA.transform.position, turretB.transform.position);

            }
        }
        turretA.activate();
        turretB.activate();
        deactivate();
        canBeGrabbed = false;
        gameObject.layer = 0;
        setGrabbable(false);
    }

    public void updateWall()
    {
        alignWall(turretA.transform.position, turretB.transform.position);
    }
    public void updateWallSegment()
    {

    }
    private void alignWall(Vector3 pointA, Vector3 pointB)
    {
        Vector3 midPoint = pointA + (pointB - pointA) / 2f;
        float height = wallSegment.transform.localScale.y;

        wallSegment.transform.position = new Vector3(midPoint.x, height / 2, midPoint.z);
        wallSegment.transform.localScale = new Vector3(wallSegment.transform.localScale.x, wallSegment.transform.localScale.y, (pointB - pointA).magnitude);
        wallSegment.transform.LookAt(pointB + Vector3.up * (height / 2));

        BoxCollider wallCollider = this.GetComponent<BoxCollider>();
        NavMeshObstacle obstacle = GetComponent<NavMeshObstacle>();

        obstacle.size = new Vector3(obstacle.size.x, obstacle.size.y, 1 + (pointB - pointA).magnitude);
        wallCollider.center = wallSegment.transform.localPosition;
        obstacle.center = wallSegment.transform.localPosition;
    }


    private void resetWall()
    {
        turretA.transform.position = initialTurretA;
        turretB.transform.position = initialTurretB;

        alignWall(initialTurretA, initialTurretB);

        //float height = wallSegment.transform.localScale.y;
        //Vector3 midPoint = turretA.transform.position + (turretB.transform.position - turretA.transform.position) / 2f;
        //wallSegment.transform.position = new Vector3(midPoint.x, height / 2, midPoint.z);
        //wallSegment.transform.localScale = new Vector3(wallSegment.transform.localScale.x, wallSegment.transform.localScale.y, (turretB.transform.position - turretA.transform.position).magnitude);
        //wallSegment.transform.LookAt(turretB.transform.position + Vector3.up * (height / 2));
    }

    public override void grab()
    {
        base.grab();

        //if I have already placed the wall once 
        if (initialTurretA != new Vector3(10000, 10000, 10000))
        {
            resetWall();
        }
        showTurretHighlight();
    }

    public override void release(Vector3 vel)
    {
        base.release(vel);
        hideTurretHighlight();
    }



    public override void deactivate()
    {
        removeOutline();
    }

    public override void create_building()
    {
    }

    public void showTurretHighlight()
    {
        turretA.showTurretHighlight();
        turretB.showTurretHighlight();
    }

    public void hideTurretHighlight()
    {
        turretA.hideTurretHighlight();
        turretB.hideTurretHighlight();
    }
}
