using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceGainTablet : MonoBehaviour {

    public Text text;
    public Renderer[] renderers;

    void Start()
    {
    }

    public void setText(string input)
    {
        text.text = input;
    }

    public void setAlpha(float alpha)
    {
        Color c;
        c = gameObject.GetComponent<Renderer>().material.color;
        c.a = alpha;
        gameObject.GetComponent<Renderer>().material.color = c;
        c = gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>().color;
        c.a = alpha;
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>().color = c;
        c = gameObject.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Renderer>().material.color;
        c.a = alpha;
        gameObject.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Renderer>().material.color = c;
    }
}
