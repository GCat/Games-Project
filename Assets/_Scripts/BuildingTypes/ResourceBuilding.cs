using UnityEngine;
using System.Collections;

public abstract class ResourceBuilding : MonoBehaviour, Building
{
    public string buildingName;
    public Vector3 location;
    public float timer;
    public float startTime;
    public float timeStep;
    public ResourceCounter resourceCounter;

    public abstract void create_building();
    public abstract void incrementResource();
    string Building.getName()
    {
        return buildingName;
    }
    Vector3 Building.getLocation()
    {
        return this.gameObject.transform.position;
    }
}
