using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchTower : MonoBehaviour, Building
{

    public string buildingName;
    private GameObject temple;
    public float health = 100.0f;
    public List<GameObject> targets;
    private float radius = 25.0f;


    bool active = false;
    public bool held = false;

    public float timer1;
    public float timer2;
    public float timer3;
    private float StartTime1;
    private float StartTime2;
    private float StartTime3;

    GameObject highlight = null;


    string Building.getName()
    {
        return buildingName;
    }
    Vector3 Building.getLocation()
    {
        return transform.position;
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
            Destroy(gameObject);
        }
    }

    public void create_building()
    {
        buildingName = "TOWER";
        targets = new List<GameObject>();
        timer1 = 0f;
        StartTime1 = Time.time;
        timer2 = 0f;
        StartTime2 = Time.time;
        timer3 = 0f;
        StartTime3 = Time.time;
    }

    void Start () {
        create_building();
        temple = GameObject.FindGameObjectWithTag("Temple");

    }

    void OnDrawGizmosSelected()
    {
       //Gizmos.color = Color.red;
       //Gizmos.DrawSphere(transform.position, radius);
    }

    void Update()
    {
        if (held)
        {
            if (highlight != null)
            {
                if (transform.position.y > 0.0 && Mathf.Abs(transform.position.x) <= 50 && Mathf.Abs(transform.position.z) <= 100)
                {
                    highlight.GetComponent<Renderer>().enabled = true;
                    highlight.transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
                }
                else
                {
                    highlight.GetComponent<Renderer>().enabled = false;
                }
            }
        }
        if (active)
        {
            if (temple != null)
            {
                if (targets.Count > 0)
                {
                    targets.RemoveAll(x => x == null);
                    int i = 0;
                    List<int> pop = new List<int>();
                    foreach (GameObject target in targets)
                    {
                        if (Vector3.Distance(transform.position, target.transform.position) <= radius)
                        {

                            attack(target, i);
                        }
                        else pop.Add(i);
                        i++;
                    }
                    foreach (int j in pop)
                    {
                        if (j < targets.Count) targets.RemoveAt(j);
                    }
                }
                if (targets.Count < 3)
                {
                    int layerMask = 1 << 11;
                    List<Collider> hitColliders = new List<Collider>(Physics.OverlapSphere(transform.position, radius, layerMask));
                    foreach (Collider c in hitColliders)
                    {
                        if (!targets.Contains(c.gameObject))
                        {
                            if (targets.Count >= 3) break;
                            else
                            {
                                targets.Add(c.gameObject);
                                attack(c.gameObject, targets.Count - 1);
                            }
                        }
                    }
                }
            }
        }
    }

    bool attack(GameObject victim,int id)
    {
        if (victim != null)
        {
            switch (id)
            {
                case 0:
                    timer1 = Time.time - StartTime1;
                    if (timer1 >= 3)
                    {
                        throwArrow(victim);
                        StartTime1 = Time.time;
                    }
                    break;
                case 1:
                    timer2 = Time.time - StartTime2;
                    if (timer2 >= 3)
                    {
                        throwArrow(victim);
                        StartTime2 = Time.time;
                    }
                    break;
                case 2:
                    timer3 = Time.time - StartTime3;
                    if (timer3 >= 3)
                    {
                        throwArrow(victim);
                        StartTime3 = Time.time;
                    }
                    break;
            }
            
            return true;
        }
        return false;
    }


    void throwArrow (GameObject victim)
    {
        if (victim != null)
        {
            Vector3 pos = transform.TransformPoint(GetComponent<BoxCollider>().center);
            pos.y = 10f;
            GameObject pre = Resources.Load("Arrow_Regular") as GameObject;
            GameObject c = GameObject.Instantiate(pre, pos, Quaternion.LookRotation(victim.transform.position)) as GameObject;
            ((Arrow)(c.GetComponent(typeof(Arrow)))).attack(victim);
        }
    }

    void activate()
    {
        active = true;
        if (highlight != null) Destroy(highlight);
        highlight = null;
        held = false;
    }
    void deactivate()
    {
        active = false;
    }

    void grabbed()
    {
        held = true;
        Material mat = Resources.Load("Materials/highlight.mat") as Material;
        highlight = GameObject.CreatePrimitive(PrimitiveType.Cube);
        highlight.GetComponent<Renderer>().material = mat;
        highlight.transform.localScale = new Vector3(GetComponent<BoxCollider>().bounds.size.x, 0.1f, GetComponent<BoxCollider>().bounds.size.z);
        highlight.transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
        highlight.GetComponent<Collider>().enabled = false;
        highlight.GetComponent<Renderer>().enabled = false;
    }

}
