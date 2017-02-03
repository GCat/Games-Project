using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceNode : MonoBehaviour {

    GameObject highlight;
    public float range;
	// Use this for initialization
	void Start () {
        Material mat = Resources.Load("Materials/Resource_Range.mat") as Material;
        highlight = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        highlight.GetComponent<Renderer>().material = mat;
        highlight.transform.localScale = new Vector3(range, 0.1f, range);
        highlight.transform.position = new Vector3(gameObject.transform.position.x, 0.1f, gameObject.transform.position.z);
        highlight.transform.rotation = Quaternion.LookRotation(Vector3.forward);

        highlight.GetComponent<Collider>().enabled = false;
        highlight.GetComponent<Renderer>().enabled = true;
        highlight.SetActive(false);

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void showRange()
    {
        highlight.SetActive(true);

    }

    public void hideRange()
    {
        highlight.SetActive(false);

    }
}
