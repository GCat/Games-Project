using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartButton : MonoBehaviour {


    public GameObject button;
    public GameObject resource_tablet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            Debug.Log("Game started");
            button.transform.localPosition = button.transform.localPosition + Vector3.down * 0.1f;
            resource_tablet.active = true;
            startGame();
            Destroy(this.gameObject);
        }
    }

    private void startGame()
    {


    }
}
