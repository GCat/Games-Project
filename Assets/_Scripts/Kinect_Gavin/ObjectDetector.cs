using UnityEngine;
using System;
using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.UI;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Runtime.InteropServices;
using System.Drawing;


public class ObjectDetector : MonoBehaviour {

    public DepthWrapper dw;
    public DeviceOrEmulator devOrEmu;

    private Kinect.KinectInterface kinect;
    private int width = 640;
    private int height = 480;
    private bool done = false;
    public bool useTestImage;
    // Use this for initialization
    void Start () {
        kinect = devOrEmu.getKinect();
    }
	
	// Update is called once per frame
	void Update () {
        //For now print out a single image as a test
        if (useTestImage)
        {
            Mat input = CvInvoke.Imread("test.png", LoadImageType.AnyColor);
            Image<Bgr, byte> img = input.ToImage<Bgr, byte>();
            img.ToBitmap().Save("testout.png");
        }
        else
        {
            if (kinect.pollColor())
            {
                Image<Bgr, byte> img = mipmapImg(kinect.getColor(), width, height);
                img.ToBitmap().Save("test.png");
            }
        }

    }

    private Image<Bgr, byte> mipmapImg(Color32[] src, int width, int height)
    {
        int newWidth = width / 2;
        int newHeight = height / 2;
        Image<Bgr, byte> dst = new Mat(newHeight, newWidth, DepthType.Cv8U, 3).ToImage<Bgr, byte>();
        for (int yy = 0; yy < newHeight; yy++)
        {
            for (int xx = 0; xx < newWidth; xx++)
            {
                int TLidx = (xx * 2) + yy * 2 * width;
                int TRidx = (xx * 2 + 1) + yy * width * 2;
                int BLidx = (xx * 2) + (yy * 2 + 1) * width;
                int BRidx = (xx * 2 + 1) + (yy * 2 + 1) * width;
                 Color32 pixel = Color32.Lerp(Color32.Lerp(src[BLidx], src[BRidx], .5F),
                                                       Color32.Lerp(src[TLidx], src[TRidx], .5F), .5F);
                dst.Data[yy, xx, 0] = pixel.b;
                dst.Data[yy, xx, 1] = pixel.g;
                dst.Data[yy, xx, 2] = pixel.r;
            }
        }
        return dst;
    }

}
