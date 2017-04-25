using UnityEngine;
using System.Collections;
using System;
using UnityEngine.AI;

public class Wall : Building
{

    // Use this for initialization
    public int cost_per_meter = 10;
    public float turretRadius = 20f;
    public float maxWallLength = 70f;
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
            boxSize = GetComponent<BoxCollider>().size;
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
        else
        {
            if (turretA == null || turretB == null)
            {
                die();
            }
        }

    }




    public new bool highlightCheck()
    {
        if (resourceCounter.withinBounds(transform.position))
        {
            highlight.SetActive(true);
            highlight.transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
            highlight.transform.rotation = transform.rotation;
            Collider[] colliders = Physics.OverlapBox(new Vector3(transform.position.x, 0, transform.position.z), boxSize, gameObject.transform.rotation, nobuildmask);
            foreach (Collider collider in colliders)
            {
                if (collider.GetComponent<WallTurret>() == null)
                {
                    foreach (Renderer t in highlight.GetComponentsInChildren<Renderer>())
                    {
                        t.material.SetColor("_Color", Color.red);
                    }
                    return false;
                }
            }

            foreach (Renderer t in highlight.GetComponentsInChildren<Renderer>())
            {
                t.material.SetColor("_Color", Color.green);
            }
            return true;
        }
        else
        {
            highlight.SetActive(false);
            return false;
        }
    }


    //return true if within bounds & not above another building
    public override bool canPlace()
    {

        float x = transform.position.x;
        float z = transform.position.z;

        if (resourceCounter.withinBounds(transform.position))
        {
            Collider[] colliders = Physics.OverlapBox(new Vector3(x, 0, z), boxSize, transform.rotation, nobuildmask);
            foreach (Collider collider in colliders)
            {
                if (collider.GetComponent<WallTurret>() == null)
                {
                    return false;
                }
            }
            GetComponent<Collider>().enabled = true;
            return true;
        }
        return false;
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
        spawnedFrom.amountSpawned--;
        Destroy(gameObject);
    }

    private void createTurretHighlight()
    {
        turretA.createHighlight(turretRadius, maxWallLength);
        turretB.createHighlight(turretRadius, maxWallLength);
    }

    public override void activate()
    {
        if (highlight != null) highlightDestroy();
        held = false;
       
        turretA.activate();
        turretB.activate();

        deactivate();
        canBeGrabbed = false;
        gameObject.layer = 0;
        setGrabbable(false);
        turretA.transform.parent = null;
        turretB.transform.parent = null;
        turretA.snap();
        turretB.snap();
        turretA.removeOutline();
        turretB.removeOutline();
        removeOutline();
        StartCoroutine(fixOutline());
    }

    public void updateWall()
    {
        alignWall(turretA.transform.position, turretB.transform.position);

    }
    private void alignWall(Vector3 pointA, Vector3 pointB)
    {
        Vector3 midPoint = pointA + (pointB - pointA) / 2f;
        //float height = transform.localScale.y;

        //wallSegment.transform.position = new Vector3(midPoint.x, height / 2, midPoint.z);
        wallSegment.transform.localScale = new Vector3(wallSegment.transform.localScale.x, wallSegment.transform.localScale.y, (pointB - pointA).magnitude);
        //wallSegment.transform.LookAt(pointB + Vector3.up * (height / 2));
        transform.position = new Vector3(midPoint.x, midPoint.y, midPoint.z);
        transform.LookAt(pointB);
        NavMeshObstacle obstacle = GetComponent<NavMeshObstacle>();
        obstacle.size = new Vector3(obstacle.size.x, obstacle.size.y, 1 + (pointB - pointA).magnitude);
        obstacle.center = wallSegment.transform.localPosition;
        BoxCollider wallCollider = GetComponent<BoxCollider>();
        wallCollider.size = new Vector3(wallCollider.size.x, wallCollider.size.y, 1 + (pointB - pointA).magnitude);
        wallCollider.center = wallSegment.transform.localPosition;
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
    public override void delete()
    {
        turretA.highlightDestroy();
        turretB.highlightDestroy();
        highlightDestroy();
        Destroy(turretA, 0.1f);
        Destroy(turretB, 0.1f);
        base.delete();
    }
}
