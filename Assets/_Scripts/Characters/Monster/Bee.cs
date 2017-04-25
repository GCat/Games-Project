using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bee : MonoBehaviour, HealthManager {


    public float damage;
    public float health;
    public float speed;
    private float totalHealth;
    private Vector3 attackPoint = Vector3.zero;
    private bool active = false;
    private GameObject target;
    private Rigidbody rb;
    private float range = 10.0f;
    private bool attacking = false;
    protected GameObject healthBar;
    protected Quaternion healthBarOri;
    protected GameObject infoText;
    protected Quaternion infoTextOri;
    Vector3 cameraPos;
    GameObject damageText;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        totalHealth = health;
        damageText = Resources.Load("Damage Text") as GameObject;
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
        health -= damage;
        StartCoroutine(DamageText("-" + damage, Color.red));
        if (health > 0 && healthBar != null)
        {
            float scale = (health / totalHealth);
            float characterScale = gameObject.transform.localScale.x;
            healthBar.transform.localScale = new Vector3(0.1f / characterScale, scale / characterScale, 0.1f / characterScale);
            healthBar.GetComponent<Renderer>().material.SetColor("_Color", new Color(1.0f - scale, scale, 0));
        }
        if (health <= 0)
        {
            Destroy(healthBar);
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;

            GameObject ghost = Instantiate(Resources.Load("Particles/Spooky_Explosion") as GameObject, transform.position, Quaternion.identity);
            Destroy(ghost, 3f);
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

    public IEnumerator DamageText(string textString, Color color)
    {
        GameObject damageIndicator = Instantiate(damageText, (new Vector3(transform.position.x, transform.position.y + 5, transform.position.z)), Quaternion.LookRotation(transform.position - cameraPos, Vector3.up)) as GameObject;
        Text text = damageIndicator.GetComponentInChildren<Text>();
        text.text = textString;
        text.color = color;
        Destroy(damageIndicator, 1);
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            if (damageIndicator != null)
            {
                Color c = text.color;
                c.a = f;
                text.color = c;
                damageIndicator.transform.Translate(new Vector3(0, 0.1f, 0));
                damageIndicator.transform.LookAt(cameraPos);
                yield return null;
            }
        }
    }


    protected void createHealthBar()
    {
        Bounds dims = gameObject.GetComponent<Collider>().bounds;
        Vector3 actualSize = dims.size;
        healthBar = GameObject.Instantiate(Resources.Load("CharacterHealthBar")) as GameObject;
        healthBar.transform.position = gameObject.GetComponent<Collider>().transform.position;
        healthBar.transform.Translate(new Vector3(0, 0, dims.size.y * -1.0f));
        healthBar.transform.position += Vector3.up * 1f;
        healthBar.transform.SetParent(gameObject.transform);
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
