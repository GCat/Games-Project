using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class WorldStarter : MonoBehaviour {
    public GameObject resource_tablet;
    /* This class should start the game and control the game flow
     * 
     * What should be in here:
     * 
     * Start tutorial, ensure player looks at correct places with visual and audio ques
     * 
     * Once temple placed render the enviornment (TOOLSHED)
     * 
     * Start voiceover explaining building and resources
     * 
     * Then show humans when the first appear explain the importance
     * 
     * 
     * 
     * 
     * 
     */
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startGame(){
		Debug.Log("Game started");
        resource_tablet.SetActive(true);
	}

    public void stopGame(){
        Debug.Log("Game finished");
    }
}
