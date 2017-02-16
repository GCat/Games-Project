using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static bool withinBounds(Vector3 position)
    {
        float y = position.y;
        float x = position.x;
        float z = position.z;

        return (y > 0 && y < 40 && x > -50 && x < 50 && z > -100 && z < 100);
    }
}
