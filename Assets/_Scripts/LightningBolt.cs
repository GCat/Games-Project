using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBolt : MonoBehaviour {

    public bool held = false;
    GameObject highlight = null;
    GameObject flash;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void grabbed()
    {
        held = true;
        // Deactivate collider and gravity


        // highlight where object wiould place if falling straight down
        /*Material mat = Resources.Load("Materials/highlight.mat") as Material;
        highlight = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        highlight.GetComponent<Renderer>().material = mat;
        highlight.transform.localScale = new Vector3(GetComponent<CapsuleCollider>().bounds.size.x, 0.1f, GetComponent<CapsuleCollider>().bounds.size.z);
        highlight.transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
        highlight.GetComponent<Collider>().enabled = false;
        highlight.GetComponent<Renderer>().enabled = false; */

        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;

    }
    void release(Vector3 vel)
    {
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Collider>().enabled = true;
        GetComponent<Rigidbody>().velocity = vel;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Ground") {
            ContactPoint hit = col.contacts[0];
            Destroy(this.gameObject);
            Collider[] damageZone = Physics.OverlapSphere(hit.point, 30);
          
            GameObject resource = Resources.Load("Bolt flash") as GameObject;
            flash = GameObject.Instantiate(resource, hit.point, Quaternion.identity);
            Destroy(flash.gameObject, 0.1f);

            int i = 0;
            while (i < damageZone.Length)
            {
                if (damageZone[i].name == "Badie")
                    damageZone[i].SendMessage("decrementHealth", 25);
                i++;
            }
        }
    }

    
   
}
