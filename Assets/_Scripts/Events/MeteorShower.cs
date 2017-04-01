using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorShower : Event {
    public GameObject meteor;
    public int Damage;
    private Vector3 max;
    private Vector3 min;
    public float meteorSpeed;
    public GameObject Racket;
    public int meteorAttack = 60;
    private GameObject racket_inhand1;
    private GameObject racket_inhand2;

    private void Awake()
    {
        GameObject ground = GameObject.FindGameObjectWithTag("Ground");
        Vector3 bounds = ground.GetComponent<Collider>().bounds.size;
        Vector3 position = ground.transform.position;

        max = new Vector3((position.x + bounds.x)/2, position.y ,(position.z + bounds.z)/2);
        min = new Vector3((position.x - bounds.x) / 2, position.y, (position.z - bounds.z) / 2);
    }

    public override void startEvent()
    {
        //GameObject racket_inhand = GameObject.Instantiate(Racket, GameObject.FindGameObjectWithTag("Hand").transform.position, Quaternion.identity) as GameObject;
        GameObject[] hands = GameObject.FindGameObjectsWithTag("Hand");
        racket_inhand1 = GameObject.Instantiate(Racket, hands[0].transform.position, Racket.transform.rotation) as GameObject;
        racket_inhand2 = GameObject.Instantiate(Racket, hands[1].transform.position, Racket.transform.rotation) as GameObject;

        racket_inhand1.transform.parent = hands[0].transform;
        racket_inhand2.transform.parent = hands[1].transform;
        racket_inhand2.SetActive(true);
        racket_inhand1.SetActive(true);
        StartCoroutine(SpawnMeteor());
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
            yield return new WaitForSeconds(1);
        }

        Destroy(racket_inhand1);
        Destroy(racket_inhand2);
    }


    //Random Targets
    private Vector3 Target()
    {
        float rand_x = UnityEngine.Random.Range(max.x, min.x);
        float rand_z = UnityEngine.Random.Range(max.z, min.z);
        return new Vector3(rand_x, 0, rand_z);
    }

}
