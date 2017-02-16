using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    private GameObject target;
    private float speed = 3.0f;
    private bool move = false;
    private float startTime;
    private float journeyLength;
    private float damage = 5.0f;
    private bool damageDone = false;
    public Transform startMarker;
    private Vector3 enemyPos;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (move)
        {
            
            if (target == null)
            {
                Destroy(gameObject);
            }
            else
            {
                enemyPos = new Vector3(target.transform.position.x, 1.5f, target.transform.position.z);

                if (Vector3.Distance(transform.position, enemyPos) < 0.3f)
                {
                    if (!damageDone)
                    {
                        HealthManager health = target.GetComponent<HealthManager>();
                        if (health != null)
                        {
                            health.decrementHealth(damage);
                            damageDone = true;
                        }
                        else
                        {
                            Debug.Log("arrow cannot damage something without health");
                        }
                    }
                    Destroy(gameObject,1.5f);
                }
                else
                {
                    
                    transform.LookAt(enemyPos);
                    float distCovered = (Time.time - startTime) * speed;
                    float fracJourney = distCovered / journeyLength;
                    transform.position = Vector3.Lerp(startMarker.position,enemyPos, fracJourney);
                }
            }
        }
	}
    public void attack(GameObject t)
    {
        startMarker = transform;
        target = t;
        move = true;
        startTime = Time.time;
        enemyPos = new Vector3(target.transform.position.x, 1.5f, target.transform.position.z);
        journeyLength = Vector3.Distance(startMarker.position, enemyPos);

    }

}
