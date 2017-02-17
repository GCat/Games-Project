using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour {

    public static Vector2 bottomLeft = new Vector2(-50, -100);
    public static Vector2 topRight = new Vector2(50, 100);


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

    public static bool aboveBoard(Vector3 p)
    {
        return (p.x >= bottomLeft.x && p.z >= bottomLeft.y && p.x <= topRight.x && p.z <= topRight.y && p.y >= -1f);
    }

    public static float tableHeight()
    {
        return 0.0f;
    }
}
