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
}
