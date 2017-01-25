using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class WorldStarter : MonoBehaviour {

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
    GameObject Temple;
	void Start () {
        Temple = GameObject.FindGameObjectWithTag("Temple");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void startTutorial(){
		
	}
}
