using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour {

    // have to create function that calulates size of the ground and the height at which its placed
    // May require this object to not ber static

    public static Vector2 bottomLeft = new Vector2(-50, -100);
    public static Vector2 topRight = new Vector2(50, 100);
    private Vector3 bL;
    private Vector3 tR;
    private Bounds b;
    // Use this for initialization
    void Start () {
        b = GetComponent<MeshRenderer>().bounds;
        tR = b.max;
        bL = b.min;
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

    public float coardHeight()
    {
        return transform.position.y;
    }

    public Vector3 boardCenter()
    {
        return transform.position;
    }

    public bool dynamicAboveBoard(Vector3 p)
    {
        return (p.x >= bL.x && p.z >= bL.z && p.x <= tR.x && p.z <= tR.z && p.y >= b.center.y -1f);
    }

    public bool dynamicWithinBounds(Vector3 position)
    {
        float y = position.y;
        float x = position.x;
        float z = position.z;

        return (y > b.center.y && y < 40 && x > bL.x && x < tR.x && z > bL.z && z < tR.z);
    }
}
