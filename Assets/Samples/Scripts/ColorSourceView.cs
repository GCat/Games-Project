using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class ColorSourceView : MonoBehaviour
{
    public GameObject ColorSourceManager;
    private ColorSourceManager _ColorManager;
    private Renderer thisRenderer;
    
    void Start ()
    {
        gameObject.GetComponent<Renderer>().material.SetTextureScale("_MainTex", new Vector2(-1, 1));
        _ColorManager = ColorSourceManager.GetComponent<ColorSourceManager>();
        thisRenderer = gameObject.GetComponent<Renderer>();
    }

    void Update()
    {
        if (ColorSourceManager == null)
        {
            return;
        }
        
        if (_ColorManager == null)
        {
            return;
        }

        thisRenderer.material.mainTexture = _ColorManager.GetColorTexture();
    }
}
