using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public float health;
    float originalHealth;
    Vector3 originalSize;


    void Awake()
    {
        originalHealth = health;
        originalSize = transform.localScale;
    }

    void faceForward()
    {
        Vector3 myLoc = transform.position;
        transform.LookAt(new Vector3(myLoc.x+10.0f, myLoc.y, myLoc.z));
        transform.Rotate(0, 0, 90.0f);
    }

    void Update()
    {
        faceForward();
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

    public float getOriginalHealth()
    {
        return originalHealth;
    }

}
