using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchTower : MonoBehaviour, Building
{

    public string buildingName;
    public float health = 100.0f;
    public List<GameObject> targets;
    public float damage = 5.0f;
    public float radius = 15.0f;

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
        targets = new List<GameObject>();
    }

    void Start () {
        create_building();
	}

    void Update()
    {
        if (targets.Count > 0)
        {
            foreach(GameObject target in targets)
            {
                if(Vector3.Distance(transform.position, target.transform.position) <= radius)
                {
                    if (!attack(target)) targets.Remove(target);
                }
            }
        }
        if(targets.Count < 3)
        {
            int layerMask = 1 << 11;
            List<Collider> hitColliders = new List<Collider>(Physics.OverlapSphere(transform.position, radius, layerMask));
            foreach(Collider c in hitColliders)
            {
                if (!targets.Contains(c.gameObject))
                {
                    if (targets.Count >= 3) break;
                    else
                    {
                        targets.Add(c.gameObject);
                        attack(c.gameObject);
                    }
                }
            }
        }
    }

    bool attack(GameObject victim)
    {
        if (victim != null)
        {
            victim.SendMessage("decrementHealth", damage * Time.deltaTime);
            return true;
        }
        return false;
    }



}
