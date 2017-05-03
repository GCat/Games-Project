using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public float health;
    float originalHealth;
    Vector3 originalSize;


    void Start()
    {
        initBar();
    }

    public void initBar()
    {
        originalHealth = health;
        originalSize = transform.localScale;
    }

    void Update()
    {
        Vector3 myLoc = transform.position;
        transform.LookAt(new Vector3(myLoc.x, myLoc.y, myLoc.z-10.0f));
        transform.Rotate(new Vector3(90, 0, 0));
    }


    public void decrementHealth(float damage)
    {
        health -= damage;
        if (health > 0)
        {
            Vector3 newScale = originalSize;
            float scale = (health / originalHealth);
            newScale.y = scale * originalSize.y;
            transform.localScale = newScale;
            GetComponent<Renderer>().material.SetColor("_Color", new Color(1.0f - scale, scale, 0));
        }
    }

    public void resetHealth()
    {
        health = originalHealth;
        decrementHealth(0);
    }

}
