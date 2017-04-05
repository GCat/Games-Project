using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class WallTurret : Building
{
    private Wall wall;
    private GameObject radiusHighlight;
    private float turretRadius;

    public override void activate()
    {
        canBeGrabbed = true;
        if (highlight != null) highlightDestroy();
        held = false;
        wall.updateWall();
        hideTurretHighlight();
        snap();
        removeOutline();
        wall.GetComponent<Collider>().enabled = true;
        GetComponent<Collider>().enabled = true;
    }
    public void Start()
    {
        wall = transform.parent.gameObject.GetComponent<Wall>();
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
    }

    public override void create_building()
    {
    }

    public override void deactivate()
    {

    }

    public void snap()
    {
        int buildingLayer = 1 << 10;
        Collider[] points = Physics.OverlapSphere(transform.position, turretRadius / 2, buildingLayer);

        foreach (Collider collider in points)
        {
            if (collider.gameObject.tag == "Turret" && collider.gameObject != gameObject && collider.gameObject.GetComponent<WallTurret>().wall != wall )
            {
                transform.position = collider.transform.position;
                wall.updateWall();
            }
        }
    }

    public override void die()
    {
        Destroy(highlight);
        Destroy(gameObject);
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

    public void createHighlight(float radius)
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
    }

    public override void highlightDestroy()
    {
        if (highlight != null)
        {
            highlight.SetActive(false);
            radiusHighlight.SetActive(false);
        }
    }

    public override void delete()
    {
        wall.delete();
    }
}

