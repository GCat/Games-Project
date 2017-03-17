using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : MonoBehaviour
{

    private Quaternion rotation;

    // Use this for initialization
    void Start()
    {
        rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        //transform.rotation = rotation;
    }
}
