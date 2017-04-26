using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    //the thing that shot this
    public GameObject parent = null;

    public float destroyDelay = 0;
    public ParticleSystem explosion;
    public bool bounce = false;
    public float explosionRadius = 0;
    public float damage = 8f;
    public bool explode;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(fadeOut(10));
        if (GetComponent<ParticleSystem>() != null && explode)
        {
            explosion = GetComponent<ParticleSystem>();
            explosion.Clear();
            explosion.Stop();
        }
    }

    IEnumerator fadeOut(float time)
    {
        yield return new WaitForSeconds(time);
        if (gameObject != null)
        {
            Destroy(gameObject);
            if (explosion != null && explosion.gameObject != null)
            {
                Destroy(explosion.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject != parent && other.gameObject.tag == "Badies" || other.gameObject.tag == "Ground")
        {
            if (!bounce)
            {
                GetComponent<Rigidbody>().isKinematic = true;
            }
            Destroy(gameObject, destroyDelay);
            if (explosion != null)
            {

                if (explosion.gameObject != gameObject)
                {
                    explosion.gameObject.transform.parent = null;
                }
                explosion.Clear();
                explosion.Play();
                if (explosionRadius > 0)
                {
                    int layerMask = 1 << 11;
                    Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
                    foreach (Collider collider in hitColliders)
                    {
                        HealthManager health = collider.GetComponent<HealthManager>();
                        if (health != null && collider.GetComponent<Agent>() == null)
                        {
                            health.decrementHealth(damage);
                        }
                    }

                }
            }
        }
    }
}
