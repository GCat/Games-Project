using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : Tower
{
    private Animator animator;
    private GameObject rock;
    public GameObject launchPoint;
    // Use this for initialization
    void Start()
    {
        rock = Resources.Load("Rock") as GameObject;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        animator = GetComponent<Animator>();
    }

    //find a new nearby monster to attack
    public override bool acquireTarget()
    {
        List<Collider> hitColliders = new List<Collider>(Physics.OverlapSphere(floor, radius, attackMask));
        if (hitColliders.Count > 0)
        {
            Debug.Log("Acquired target");
            currentTarget = hitColliders[0].gameObject;
            return true;
        }

        return false;
    }

    private IEnumerator attack()
    {

        while (true)
        {
            if (currentTarget != null && Vector3.Distance(floor, currentTarget.transform.position) < radius)
            {
                throwRock(currentTarget);
            }
            yield return new WaitForSeconds(2);
        }
    }

    void throwRock(GameObject victim)
    {
        if (victim != null)
        {
            Debug.Log("Throwing rock");
            animator.SetTrigger("Fire");
        }
    }

    private void releaseRock()
    {
        if (currentTarget == null)
        {
            return;
        }
        GameObject newRock = Instantiate(rock, launchPoint.transform.position + Vector3.up * 2, Quaternion.identity);
        Vector3 target = currentTarget.transform.position;
        float innacuracy = Random.Range(0f, 0.8f);
        target.y = transform.position.y + 30 + innacuracy;
        newRock.GetComponent<Rigidbody>().AddForce((target - transform.position)*1.1f, ForceMode.Impulse);
        newRock.GetComponent<Projectile>().parent = gameObject;
        Physics.IgnoreCollision(GetComponent<Collider>(), newRock.GetComponent<Collider>());


    }

    public override void activeTower()
    {
        if (currentTarget != null)
        {
            Vector3 target = currentTarget.transform.position;
            target.y = transform.position.y;
            Quaternion lookRotation = Quaternion.LookRotation(target - transform.position, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 2f);

        }

    }

    IEnumerator WaitToDamage(float waitTime, float damage, GameObject victim)
    {
        yield return new WaitForSeconds(waitTime);
        if (victim != null)
        {
            HealthManager victimHealth = victim.GetComponent<HealthManager>();
            if (victimHealth != null)
            {
                victimHealth.decrementHealth(damage);
            }
        }
    }

    public override string getName()
    {
        return "Catapult";
    }

    public override void activate()
    {
        if (!bought) resourceCounter.removeFaith(faithCost);
        active = true;
        if (highlight != null) Destroy(highlight);
        highlight = null;
        held = false;
        hideRange();
        if (!activated)
        {
            StartCoroutine(attack());
            activated = true;
        }
        base.activate();
    }
}
