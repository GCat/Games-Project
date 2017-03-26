using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

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
        b = GetComponent<Collider>().bounds;
        Debug.Log(b.center);
        tR = b.max;
        bL = b.min;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InputTracking.Recenter();
        }

	}

    public static bool withinBounds(Vector3 position)
    {
        float y = position.y;
        float x = position.x;
        float z = position.z;

        // y is -10 and not 0 so that we can deal with the case that some buildings are halfway through
        return (y > -40 && y < 40 && x > -50 && x < 50 && z > -100 && z < 100);
    }

    public static bool aboveBoard(Vector3 p)
    {
        return (p.x >= bottomLeft.x && p.z >= bottomLeft.y && p.x <= topRight.x && p.z <= topRight.y && p.y >= -1f);
    }

    public float tableHeight()
    {
        return bL.y -1;
    }

    public float coardHeight()
    {
        return transform.position.y;
    }

    public Vector3 boardCenter()
    {
        return transform.position;
    }

    public bool dynamicAboveBoard(Vector3 position)
    {
        return (position.x >= bL.x && position.z >= bL.z && position.x <= tR.x && position.z <= tR.z && position.y >= -1f);
    }

    public bool dynamicWithinBounds(Vector3 position)
    {
        float y = position.y;
        float x = position.x;
        float z = position.z;

        return (y >= -30 && y < 50 && x > bL.x && x < tR.x && z > bL.z && z < tR.z);
    }
    public Vector3 getTopRight()
    {
        return tR;
    }
    public Vector3 getBottomLeft()
    {
        return bL;
    }
}
