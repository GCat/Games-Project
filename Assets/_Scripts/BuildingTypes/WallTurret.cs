using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class WallTurret : Building
{
    private Wall wall;
    private GameObject radiusHighlight;
    private GameObject wallLengthHighlight;
    private float turretRadius;
    public List<WallTurret> overlappingTurrets;
    public WallTurret otherEnd;

    public override void activate()
    {
        limitLength();
        overlappingTurrets = new List<WallTurret>();
        canBeGrabbed = true;
        if (highlight != null) highlightDestroy();
        held = false;
        wall.updateWall();
        hideTurretHighlight();
        snap();
        removeOutline();
        wall.GetComponent<Collider>().enabled = true;
        GetComponent<Collider>().enabled = true;
        otherEnd.showWallLengthHighlight(false);
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(fixOutline());
        }

    }
    public void Start()
    {
        wall = transform.parent.gameObject.GetComponent<Wall>();
    }

    private void limitLength()
    {
        if (Vector3.Distance(otherEnd.transform.position, transform.position) < wall.maxWallLength * 0.5f)
        {

            return;
        }
        Vector3 wallDirection = (transform.position - otherEnd.transform.position).normalized * wall.maxWallLength * 0.5f;
        transform.position = otherEnd.transform.position + wallDirection;

    }

    public void Update()
    {
        if (held)
        {
            wall.GetComponent<Collider>().enabled = false;
            showTurretHighlight();
            highlightCheck();
            wall.updateWall();
            adjustHighlight();

        }
        else if (wall == null)
        {
            Destroy(gameObject);
        }
    }

    public override void create_building()
    {
    }

    public override void deactivate()
    {

    }

    public override void grab()
    {
        foreach (WallTurret turret in overlappingTurrets)
        {
            turret.overlappingTurrets.Remove(this);
            turret.reveal();
        }
        base.grab();
        otherEnd.showWallLengthHighlight(true);
    }

    public void reveal()
    {
        bool reveal = true;
        foreach (WallTurret turret in overlappingTurrets)
        {
            if (turret.gameObject.activeInHierarchy)
            {
                reveal = false;
                turret.removeOutline();
            }
        }
        gameObject.SetActive(reveal);

    }

    public void snap()
    {
        int buildingLayer = 1 << 10;
        Collider[] points = Physics.OverlapSphere(transform.position, turretRadius / 2, buildingLayer);

        foreach (Collider collider in points)
        {
            if (collider.gameObject.tag == "Turret" && collider.gameObject != gameObject && collider.gameObject.GetComponent<WallTurret>().wall != wall)
            {
                transform.position = collider.transform.position;
                wall.updateWall();
                overlappingTurrets.Add(collider.gameObject.GetComponent<WallTurret>());
                collider.gameObject.GetComponent<WallTurret>().overlappingTurrets.Add(this);
                collider.gameObject.GetComponent<WallTurret>().removeOutline();
            }
        }
        reveal();
        try
        {
            if (gameObject.activeInHierarchy)
            {
                StartCoroutine(fixOutline());
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public override void die()
    {
        Destroy(highlight);

        if (gameObject != null)
        {

            Destroy(gameObject);
        }

    }

    private IEnumerator clearOutline()
    {
        while (!held)
        {
            yield return new WaitForSeconds(1f);
            removeOutline();

        }

    }
    public override Vector3 getLocation()
    {
        return transform.position;
    }

    public override string getName()
    {
        return "turret";
    }

    public void showTurretHighlight()
    {
        radiusHighlight.SetActive(true);
    }

    public void hideTurretHighlight()
    {
        radiusHighlight.SetActive(false);
    }

    public void adjustHighlight()
    {
        radiusHighlight.transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);

    }
    public void showWallLengthHighlight(bool active)
    {
        wallLengthHighlight.transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
        wallLengthHighlight.SetActive(active);
    }


    public void createHighlight(float radius, float maxWallLength)
    {
        radiusHighlight = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        radiusHighlight.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
        radiusHighlight.transform.localScale = new Vector3(radius, 0.1f, radius);
        radiusHighlight.transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
        radiusHighlight.transform.rotation = Quaternion.LookRotation(Vector3.forward);
        radiusHighlight.GetComponent<Collider>().enabled = false;
        radiusHighlight.GetComponent<Renderer>().enabled = true;
        radiusHighlight.SetActive(false);
        turretRadius = radius;

        wallLengthHighlight = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        wallLengthHighlight.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        wallLengthHighlight.transform.localScale = (new Vector3(maxWallLength, 0.1f, maxWallLength));
        wallLengthHighlight.transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
        wallLengthHighlight.transform.rotation = Quaternion.LookRotation(Vector3.forward);
        wallLengthHighlight.GetComponent<Collider>().enabled = false;
        // wallLengthHighlight.GetComponent<Renderer>().enabled = true;
        wallLengthHighlight.GetComponent<Renderer>().enabled = false;
        wallLengthHighlight.SetActive(false);

    }

    public override void highlightDestroy()
    {
        if (highlight != null)
        {
            highlight.SetActive(false);
        }
        if (radiusHighlight != null)
        {
            radiusHighlight.SetActive(false);
        }
    }

    public override void delete()
    {
        wall.delete();
        wallLengthHighlight.SetActive(false);
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
        highlightDestroy();
    }
}

