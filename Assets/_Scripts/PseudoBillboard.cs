using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PseudoBillboard : MonoBehaviour {

    public GameObject head;

    // Use this for initialization
    void Start () {
        head = GameObject.FindGameObjectWithTag("MainCamera");
    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.activeSelf)
        {
            head = GameObject.FindGameObjectWithTag("MainCamera");
            gameObject.transform.LookAt(head.transform.position);
        }
    }

    public void activateThis()
    {
        head = GameObject.FindGameObjectWithTag("MainCamera");
        gameObject.transform.LookAt(head.transform.position);
        gameObject.SetActive(true);
    }
}
