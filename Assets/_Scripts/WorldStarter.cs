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

    }

    public void stopGame(){
        Debug.Log("Game finished");
        this.GetComponent<Animator>().SetTrigger("GameOver");
    }
}
