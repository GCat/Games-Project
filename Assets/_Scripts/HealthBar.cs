using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public float health;
    float originalHealth;
    Vector3 originalSize;


    void Start()
    {
        originalHealth = health;
        originalSize = transform.localScale;
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
