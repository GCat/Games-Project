using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meter : MonoBehaviour {

    public float faith = 0;
    private Vector3 basePos;
    float parentScale;
    public ResourceCounter resourceCounter;

    // Use this for initialization
    void Start () {
        basePos = gameObject.transform.position;
        parentScale = gameObject.transform.parent.transform.localScale.y;
        GameObject tablet = GameObject.Find("Resource_tablet");
        if (tablet != null) resourceCounter = (ResourceCounter)tablet.GetComponent<ResourceCounter>();
    }
	
	// Update is called once per frame
	void Update () {
        if (resourceCounter != null)
        {
            faith = resourceCounter.getFaith();
        }
        updateScale();
        updateBase();
        updateMeter();
	}

    void updateBase()
    {
        basePos = gameObject.transform.parent.transform.position;
        basePos.y -= parentScale*22.45f;
    }
    void updateScale()
    {
        parentScale = gameObject.transform.parent.transform.localScale.y;
    }
    void updateMeter()
    { 
        float displayFaith;
        if (faith < 0) displayFaith = 0;
        else if (faith > 1000) displayFaith = 1000;
        else displayFaith = faith;
        Vector3 scale = gameObject.transform.localScale;
        scale.y = displayFaith / 100;
        gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, scale, 2.0f * Time.deltaTime);
        Vector3 location = gameObject.transform.position;
        location.y = (displayFaith / 100)*parentScale + basePos.y;
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, location, 2.0f * Time.deltaTime);
    }
}
