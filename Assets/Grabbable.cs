using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour, Placeable {

    private bool held = false;
    private GameObject highlight = null;
    public bool placeable = true;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void FixedUpdate()
    {
        if (held && placeable)
        {
            if (highlight != null)
            {
                if (transform.position.y > 0.0 && Mathf.Abs(transform.position.x) <= 50 && Mathf.Abs(transform.position.z) <= 100)
                {
                    highlight.GetComponent<Renderer>().enabled = true;
                    highlight.transform.position = new Vector3(Mathf.Floor(transform.position.x), 0.1f, Mathf.Floor(transform.position.z));
                    highlight.transform.rotation = Quaternion.LookRotation(Vector3.forward);

                }
                else
                {
                    highlight.GetComponent<Renderer>().enabled = false;
                }
            }
        }
    }

    void grabbed()
    {
        held = true;
        // Deactivate  collider and gravity


        // highlight where object wiould place if falling straight down
        Material mat = Resources.Load("Materials/highlight.mat") as Material;
        if (highlight != null)
        {
            DestroyImmediate(highlight);
        }
        highlight = GameObject.CreatePrimitive(PrimitiveType.Cube);
        highlight.GetComponent<Renderer>().material = mat;
        highlight.transform.localScale = new Vector3(GetComponent<BoxCollider>().bounds.size.x, 0.1f, GetComponent<BoxCollider>().bounds.size.z);
        highlight.transform.position = new Vector3(Mathf.Floor(transform.position.x), 0.1f, Mathf.Floor(transform.position.z));
        highlight.transform.rotation = Quaternion.LookRotation(Vector3.forward);

        highlight.GetComponent<Collider>().enabled = false;
        highlight.GetComponent<Renderer>().enabled = false;

        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;

    }

    public void activate()
    {

    }

    void release(Vector3 vel)
    {

        //Snap to grid
        float y = transform.position.y;
        float x = transform.position.x;
        float z = transform.position.z;

        //test within table bounds
        if (GameBoard.withinBounds(transform.position) && placeable)
        {
            transform.position = new Vector3(Mathf.Floor(x), 0, Mathf.Floor(z));
            transform.rotation = Quaternion.LookRotation(Vector3.forward);
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Collider>().enabled = true;
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Collider>().enabled = true;
            GetComponent<Rigidbody>().velocity = vel;
        }
    }
}
