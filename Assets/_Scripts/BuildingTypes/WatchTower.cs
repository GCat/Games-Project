using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchTower : MonoBehaviour, Building
{

    public string buildingName;
    public float health = 100.0f;

    string Building.getName()
    {
        return buildingName;
    }
    Vector3 Building.getLocation()
    {
        return this.gameObject.transform.position;
    }
    float getHealth()
    {
        return health;
    }
    public void decrementHealth(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    public void create_building()
    {
        buildingName = "TOWER";
    }

    void Start () {
        create_building();
	}

    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Badies")
        {
            Debug.Log("Attack!");
            other.gameObject.SendMessage("decrementHealth", 5 * Time.deltaTime);
        }
    }


}
