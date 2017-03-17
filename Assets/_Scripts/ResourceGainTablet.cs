using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceGainTablet : MonoBehaviour {

    public Text text;
    public Renderer[] renderers;
    public GameObject head;

    void Start()
    {
        head = GameObject.FindGameObjectWithTag("MainCamera");

    }
    void Update()
    {
        if (gameObject.activeSelf)
        {
            Vector3 headPos = head.transform.position;
            headPos.y = gameObject.transform.position.y;
            gameObject.transform.LookAt(headPos);
            gameObject.transform.Rotate(0, -90, 0);
        }
    }

    public void activateThis()
    {
        head = GameObject.FindGameObjectWithTag("MainCamera");
        Vector3 headPos = head.transform.position;
        headPos.y = gameObject.transform.position.y;
        gameObject.transform.LookAt(headPos);
        gameObject.transform.Rotate(0, -90, 0);
        gameObject.SetActive(true);

    }

    public void setText(string input)
    {
        text.text = input;
    }
}
