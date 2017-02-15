using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchTower : MonoBehaviour, Building, Placeable
{


    public AudioClip build;
    public AudioClip destroy;

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
    private bool badplacement = false;
    private float placementTime;
    private Vector3 boxSize;


    public Material matEmpty;
    public Material matInval;


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
        boxSize = GetComponent<BoxCollider>().bounds.size / 2;
        boxSize.y = 0.01f;

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
                highlightCheck();
            }
        }
        else if (badplacement)
        {
            if (Time.time - placementTime > 5.0f)
            {
                DestroyObject(gameObject);
            }
        }
        else if (active)
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

    public void activate()
    {
        if (!badplacement)
        {
            active = true;
            if (highlight != null) Destroy(highlight);
            highlight = null;
            held = false;
        }

    }
    public void deactivate()
    {
        active = false;
    }

    public void grab()
    {
        held = true;
        badplacement = false;
        // Deactivate  collider and gravity
        if (highlight != null)
        {
            DestroyImmediate(highlight);
        }

        // highlight where object wiould place if falling straight down
        createHighlight();

        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;

    }
    public void release(Vector3 vel)
    {
        //Snap to grid
        float y = transform.position.y;
        float x = transform.position.x;
        float z = transform.position.z;
        int layerMask = (1 << 10);

        //test within table bounds
        if (GameBoard.withinBounds(transform.position))
        {
            GetComponent<Collider>().enabled = true;
            if (Physics.CheckBox(new Vector3(Mathf.Floor(x), 0, Mathf.Floor(z)), boxSize, Quaternion.LookRotation(Vector3.forward), layerMask))
            {
                badplacement = true;
                held = false;
                placementTime = Time.time;
                GetComponent<Collider>().enabled = false;
                highlightDestroy();
            }
            transform.position = new Vector3(Mathf.Floor(x), 0, Mathf.Floor(z));
            transform.rotation = Quaternion.LookRotation(Vector3.forward);
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<Rigidbody>().velocity = vel;
        }
    }

    private void highlightDestroy()
    {
        if (highlight != null) Destroy(highlight);
    }
    private void highlightCheck()
    {
        if (transform.position.y > 0.0 && Mathf.Abs(transform.position.x) <= 50 && Mathf.Abs(transform.position.z) <= 100)
        {
            highlight.GetComponent<Renderer>().enabled = true;
            highlight.transform.position = new Vector3(Mathf.Floor(transform.position.x), 0.1f, Mathf.Floor(transform.position.z));
            highlight.transform.rotation = Quaternion.LookRotation(Vector3.forward);
            int layerMask = 1 << 10;
            if (Physics.CheckBox(new Vector3(Mathf.Floor(transform.position.x), 0, Mathf.Floor(transform.position.z)), boxSize, Quaternion.LookRotation(Vector3.forward), layerMask))
                highlight.GetComponent<Renderer>().material = matInval;
            else
                highlight.GetComponent<Renderer>().material = matEmpty;


        }
        else
        {
            highlight.GetComponent<Renderer>().enabled = false;
        }
    }

    private void createHighlight()
    {
        highlight = GameObject.CreatePrimitive(PrimitiveType.Cube);
        highlight.GetComponent<Renderer>().material = matEmpty;
        highlight.transform.localScale = new Vector3(GetComponent<BoxCollider>().bounds.size.x, 0.1f, GetComponent<BoxCollider>().bounds.size.z);
        highlight.transform.position = new Vector3(Mathf.Floor(transform.position.x), 0.1f, Mathf.Floor(transform.position.z));
        highlight.transform.rotation = Quaternion.LookRotation(Vector3.forward);

        highlight.GetComponent<Collider>().isTrigger = true;
        highlight.GetComponent<Renderer>().enabled = false;
    }

}
