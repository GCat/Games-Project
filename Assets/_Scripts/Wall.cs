using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	// Use this for initialization
	public float health;
    public GameObject turret_a;
    public GameObject turret_b;
    public GameObject wall_section;
	void Start () {
		health = 400;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = turret_a.transform.position - turret_b.transform.position;
        Vector3 middle = turret_b.transform.position + (direction / 2);
        float length = direction.magnitude;
        Vector3 current_scale = wall_section.transform.localScale;
        current_scale.z = length;
        wall_section.transform.localScale = current_scale;
        wall_section.transform.position = middle + Vector3.up*2;
        wall_section.transform.rotation = Quaternion.LookRotation(direction);
	}



	public void decrementHealth(float damage){
		health -= damage;
		if (health <= 0){
			Destroy(gameObject);
		}
	}
	void onCollisionEnter(Collision collision){
		Debug.Log("Sup");	
	}

}
