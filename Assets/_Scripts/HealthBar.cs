using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public float health;
    ResourceBuilding building;
    House house;
    bool isHouse = false;
    public float totalHealth;

    // Use this for initialization
    void Start () {
        building = gameObject.transform.parent.GetComponent<ResourceBuilding>();
        if (building == null)
        {
            house = gameObject.transform.parent.GetComponent<House>();
            isHouse = true;
        }
        if (isHouse)
        {
            totalHealth = house.health;
        }
        else
        {
            totalHealth = building.health;
        }
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (isHouse)
        {
            health = house.health;
        }
        else
        {
            health = building.health;
        }
        if (health < totalHealth)
        {
            gameObject.SetActive(true);
        }
        updateMeter();
	}

    void updateMeter()
    {
        float displayHealth;
        if (health < 0) displayHealth = 0;
        else if (health > totalHealth) displayHealth = totalHealth;
        else displayHealth = health/totalHealth;
        Vector3 scale = gameObject.transform.localScale;
        scale.y = displayHealth*1;
        gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, scale, 2.0f * Time.deltaTime);
    }
}
