using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

    private GameObject handle;
    public GameObject rotator;
	// Use this for initialization
	void Start () {
        handle = transform.FindChild("handle").gameObject;
        handle.transform.SetParent(null);
        transform.SetParent(handle.transform);
        if(rotator != null)
        {
            //rotator.transform.parent = null;
        }
	}

	
	// Update is called once per frame
	void Update () {

        //positions[0] = gameObject.transform.position;
        //positions[1] = handle.transform.position;
        //rope.SetPositions(positions);
        //Vector3 horizontal = handle.transform.position;
        //horizontal.y = transform.position.y;
        //float y = Mathf.Abs((transform.position - handle.transform.position).y);
        //if ((horizontal - transform.position).magnitude > 5)
        //{
        //    transform.position = Vector3.Slerp(transform.position, horizontal, Time.deltaTime * 10.0f);
        //}
    }
}
