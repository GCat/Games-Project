using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorShower : Event {
    public GameObject meteor;
    public int Damage;
    private Vector3 max;
    private Vector3 min;
    public float meteorSpeed = 1.0f;

    private void Awake()
    {
        GameObject ground = GameObject.FindGameObjectWithTag("Ground");
        Vector3 bounds = ground.GetComponent<Collider>().bounds.size;
        Vector3 position = ground.transform.position;

        max = new Vector3(position.x + bounds.x/2, position.y ,position.z + bounds.z/2);
        min = new Vector3(position.x - bounds.x / 2, position.x, position.z - bounds.z / 2);
    }

    public override void startEvent()
    {
        StartCoroutine(SpawnMeteor());
        //StartCoroutine(MeteorOutside(4))
    }

    private IEnumerator SpawnOutside(int targets)
    {
        //acquire multiple targets outside the table
        yield return new WaitForSeconds(3);
    }
    

    //dont use move towards, cause need to use the update function to see it ?
    private IEnumerator SpawnMeteor()
    {
        //dafuck 
        while(true)
        {
            Debug.Log("Spawn METEORRRRR");
            Vector3 target = Target();
            float step = meteorSpeed * Time.deltaTime;
            Debug.Log(meteor.transform.position);
            GameObject shot = GameObject.Instantiate(meteor, meteor.transform.position, meteor.transform.rotation) as GameObject;
            shot.GetComponent<Rigidbody>().velocity = target;
            yield return new WaitForSeconds(1);
        }
    }


    //activate partical effect, inflict damage 
    private void onHit()
    {
        //do something (puff somke..)
    }

    //Random Targets
    private Vector3 Target()
    {
        float rand_x = UnityEngine.Random.Range(max.x, min.x);
        float rand_z = UnityEngine.Random.Range(max.z, min.z);
        return new Vector3(rand_x, max.y, rand_z);
    }

}
