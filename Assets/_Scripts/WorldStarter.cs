using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class WorldStarter : MonoBehaviour {

	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

	}

	public void startGame(){
        Debug.Log("Game started");
    }

    public void stopGame(){
        Debug.Log("Game finished");
        this.GetComponent<Animator>().SetTrigger("GameOver");
    }
}
