using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bee : MonoBehaviour, HealthManager {


    public float damage;
    public float speed;
    private float totalHealth;
    private Vector3 attackPoint = Vector3.zero;
    private bool active = false;
    private GameObject target;
    private Rigidbody rb;
    private float range = 10.0f;
    private bool attacking = false;
    public HealthBar healthBar;
    protected GameObject infoText;
    protected Quaternion infoTextOri;
    Vector3 cameraPos;
    private ParticleSystem damageEffect;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        healthBar = GetComponentInChildren<HealthBar>();
        damageEffect = Instantiate(Resources.Load("Particles/Damage") as GameObject, transform).GetComponent<ParticleSystem>();
        damageEffect.gameObject.transform.position = transform.position;
        damageEffect.transform.SetParent(transform);
    }

    // Update is called once per frame
    void Update () {
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
        healthBar.decrementHealth(damage);
        damageEffect.Clear();
        damageEffect.Play();
        if (healthBar.health <= 0)
        {
            Destroy(healthBar);
            healthBar.gameObject.SetActive(false);
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;

            //GameObject ghost = Instantiate(Resources.Load("Particles/Spooky_Explosion") as GameObject, transform.position, Quaternion.identity);
            //Destroy(ghost, 3f);
            gameObject.tag = "Untagged";
            StartCoroutine(WaitToDestroy(5f));
            active = false;
            GetComponentInChildren<Animator>().enabled = false;
        }
    }

    IEnumerator WaitToDestroy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GameObject.Destroy(gameObject);
    }

    protected void createInfoText()
    {
        Bounds dims = gameObject.GetComponent<Collider>().bounds;
        Vector3 actualSize = dims.size;
        infoText = GameObject.Instantiate(Resources.Load("AttackSprite")) as GameObject;
        infoText.transform.position = gameObject.transform.position;
        infoText.transform.localScale *= 2;
        infoText.transform.Translate(new Vector3(0, actualSize.y * 1.4f, 0));
        infoText.transform.localRotation = gameObject.transform.localRotation;
        infoText.transform.Rotate(new Vector3(0, -90, 0));
        infoText.transform.SetParent(gameObject.transform);
        infoText.SetActive(false);
    }

    IEnumerator WaitToDie (float timeout)
    {
        yield return new WaitForSeconds(timeout);
        if (gameObject != null) Destroy(gameObject);
    }

    IEnumerator WaitToAttack(float timeout, GameObject victim)
    {
        if (attacking) {
            yield break;
        }
        attacking = true;
        yield return new WaitForSeconds(timeout);
        if( victim != null)
        {
            HealthManager hvic = victim.GetComponent<HealthManager>();
            hvic.decrementHealth(damage);
        }
        attacking = false;
    }


    public void slap()
    {
        StartCoroutine(knock());
    }

    IEnumerator knock()
    {
        active = false;
        GetComponentInChildren<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(1f);
        GetComponentInChildren<Rigidbody>().useGravity = false;

        active = true;
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
