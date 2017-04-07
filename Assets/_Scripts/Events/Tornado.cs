using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    public float damage;
    public float speed;
    public float lifetime;
    private Vector3 target;
    private Rigidbody rb;

    private void Start()
    {
        // Has to be adapted to a correct board size
        target = new Vector3(Random.Range(-100,60), 0f, Random.Range(-80,80));
        rb = GetComponent<Rigidbody>();
        StartCoroutine(WaitToDie());
    }

    private void Update()
    {
        if (Vector3.Distance(target, transform.position) < 2f)
        {
            StartCoroutine(WaitToMove());
        }
        else
        {
            Vector3 moveDirection = target - transform.position;
            Vector3 mDir = moveDirection.normalized * speed;
            rb.velocity = mDir;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        HealthManager hvic = col.gameObject.GetComponent<HealthManager>();
        if (hvic != null)
        {
            hvic.decrementHealth(damage * Time.deltaTime);

        }
    }

    private void OnTriggerStay(Collider col)
    {
        HealthManager hvic = col.gameObject.GetComponent<HealthManager>();
        if (hvic != null) hvic.decrementHealth(damage * Time.deltaTime);
    }

    IEnumerator WaitToMove()
    {
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(1);
        target = new Vector3(Random.Range(-100, 60), 0f, Random.Range(-80, 80));
    }

    IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }


}
