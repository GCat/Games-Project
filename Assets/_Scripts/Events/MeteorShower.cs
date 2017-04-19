using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorShower : Event {
    public GameObject meteor;
    public int Damage;
    private Vector3 max;
    private Vector3 min;
    public float meteorSpeed = 0.1f;
    public int meteorAttack = 30;

    private void Awake()
    {
        GameObject ground = GameObject.FindGameObjectWithTag("Ground");
        Vector3 bounds = ground.GetComponent<Collider>().bounds.size;
        Vector3 position = ground.transform.position;

        max = new Vector3(position.x + (bounds.x/ 2), position.y ,position.z + (bounds.z)/2);
        min = new Vector3(position.x - (bounds.x/ 2), position.y, position.z - (bounds.z) / 2);
    }

    public override void startEvent()
    {
        enable_disable_SphereCollider(true);
        StartCoroutine(SpawnMeteor());
    }
    
    private void enable_disable_SphereCollider(bool enable)
    {
        GameObject[] hands = GameObject.FindGameObjectsWithTag("Hand");

        foreach (GameObject hand in hands)
        {
            hand.GetComponent<CapsuleCollider>().enabled = !enable;
            //Collider handco = hand.GetComponent<CapsuleCollider>();
            //handco.GetComponent<Physics>().GetIgnoreLayerCollisions
            hand.GetComponent<SphereCollider>().enabled = enable;
        }
    }


    //dont use move towards, cause need to use the update function to see it ?
    private IEnumerator SpawnMeteor()
    {
        int round = 0;
        while( round < meteorAttack) 
        {
            Vector3 target = Target();
            Vector3 direction = target - meteor.transform.position; 
            GameObject shot = GameObject.Instantiate(meteor, meteor.transform.position, Quaternion.identity) as GameObject;
            shot.GetComponent<Rigidbody>().velocity = direction * meteorSpeed;
            round++;
            yield return new WaitForSeconds(2);
        }

        enable_disable_SphereCollider(false);
    }


    //Random Targets
    private Vector3 Target()
    {
        float rand_x = UnityEngine.Random.Range(max.x, min.x);
        float rand_z = UnityEngine.Random.Range(max.z, min.z);
        return new Vector3(rand_x, 10, rand_z);
    }

}
