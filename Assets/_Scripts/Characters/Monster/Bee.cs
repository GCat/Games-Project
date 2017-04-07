using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour, HealthManager {


    public float damage;
    public float health;
    public float speed;

    private Vector3 attackPoint = Vector3.zero;
    private bool active = false;
    private GameObject target;
    private Rigidbody rb;
    private float range = 10.0f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (active)
        {
            if (target == null) Destroy(gameObject);
            else
            {
                if (attackPoint != Vector3.zero)
                {
                    if (Move(attackPoint))
                    {
                        StartCoroutine(WaitToAttack(2.0f, target));
                    }
                }
                else
                {
                    if (Move(target.GetComponent<Collider>().ClosestPointOnBounds(transform.position)))
                    {
                        StartCoroutine(WaitToAttack(2.0f, target));
                    }
                }
            }
        }
	}


    private bool Move(Vector3 target)
    {
        transform.LookAt(target);
        if (Vector3.Distance(transform.position, target) > range)
        {
            Vector3 moveDirection = target - transform.position;
            Vector3 nMove = moveDirection.normalized;
            rb.velocity= nMove*speed;
            Debug.Log(rb.velocity);
            return false;
        }
        else
        {
            rb.velocity =Vector3.zero;

            return true;
        }
    }

    public void Spawn(GameObject target, float timeout)
    {
        this.target = target;
        active = true;
    }

    public void Spawn(GameObject target, float timeout, Vector3 t)
    {
        this.target = target;
        attackPoint = t;
        active = true;
        transform.LookAt(t);

    }

    public void decrementHealth(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator WaitToDie (float timeout)
    {
        yield return new WaitForSeconds(timeout);
        if (gameObject != null) Destroy(gameObject);
    }

    IEnumerator WaitToAttack(float timeout, GameObject victim)
    {
        yield return new WaitForSeconds(timeout);
        if( victim != null)
        {
            HealthManager hvic = victim.GetComponent<HealthManager>();
            hvic.decrementHealth(damage);
        }
    }

    void OnCollisionEnter(Collision col)
    {

    }

    void OnCollisionStay(Collision col)
    {

    }

    void OnCollisionExit(Collision col)
    {

    }
}
