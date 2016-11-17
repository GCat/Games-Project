using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class DisplayDepth : MonoBehaviour {
	
	public DepthWrapper dw;
    public short[] mappedDepth;

	private Texture2D tex;
	// Use this for initialization
	void Start () {
		tex = new Texture2D(640,480,TextureFormat.ARGB32,false);
		GetComponent<Renderer>().material.mainTexture = tex;
        mappedDepth = new short[640 * 480];

    }

    // Update is called once per frame
    void Update () {
		if (dw.pollDepth())
		{
			tex.SetPixels32(convertDepthToColor(dw.mappedDepth));
			//tex.SetPixels32(convertPlayersToCutout(dw.segmentations));
			tex.Apply(false);
		}
	}
	
	private Color32[] convertDepthToColor(short[] depthBuf)
	{
		Color32[] img = new Color32[depthBuf.Length];
		for (int pix = 0; pix < depthBuf.Length; pix++)
		{
			img[pix].r = (byte)(depthBuf[pix] / 32);
			img[pix].g = (byte)(depthBuf[pix] / 32);
			img[pix].b = (byte)(depthBuf[pix] / 32);
		}
		return img;
	}
	
	private Color32[] convertPlayersToCutout(bool[,] players)
	{
		Color32[] img = new Color32[320*240];
		for (int pix = 0; pix < 320*240; pix++)
		{
			if(players[0,pix]|players[1,pix]|players[2,pix]|players[3,pix]|players[4,pix]|players[5,pix])
			{
				img[pix].a = (byte)255;
			} else {
				img[pix].a = (byte)0;
			}
		}
		return img;
	}
}
