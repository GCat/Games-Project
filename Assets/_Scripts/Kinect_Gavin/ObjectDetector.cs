using UnityEngine;
using System;
using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.UI;
using Emgu.CV.Features2D;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Runtime.InteropServices;
using System.Drawing;


public class ObjectDetector : MonoBehaviour {

    public DepthWrapper dw;
    public DeviceOrEmulator devOrEmu;
    public GameObject imagePlane;
    public UnityEngine.Color target;
    private Hsv targetHsv;
    private Hsv tolerance = new Hsv(15, 50, 50);
    private Hsv lower;
    private Hsv upper;

    private Kinect.KinectInterface kinect;
    private int width = 640;
    private int height = 480;
    private bool done = false;
    public bool useTestImage;
    private SimpleBlobDetector blobDetector;
    private Texture2D tex;

    struct Coord
    {
        public int x;
        public int y;
    };

    // Use this for initialization
    void Start () {
        kinect = devOrEmu.getKinect();
        SimpleBlobDetectorParams blobParams = new SimpleBlobDetectorParams();
       /* blobParams.FilterByColor = true;
        blobParams.blobColor = 255;*/

        blobDetector = new SimpleBlobDetector(blobParams);
        tex = new Texture2D(320, 240, TextureFormat.ARGB32, false);
        imagePlane.GetComponent<Renderer>().material.mainTexture = tex;
        targetHsv = unityColorToHsv(target);
        lower = new Hsv(targetHsv.Hue - tolerance.Hue, targetHsv.Satuation - tolerance.Satuation, targetHsv.Value - tolerance.Value);
        upper = new Hsv(targetHsv.Hue + tolerance.Hue, targetHsv.Satuation + tolerance.Satuation, targetHsv.Value + tolerance.Value);

    }

    // Update is called once per frame
    void Update () {
        //For now print out a single image as a test
        //detects objects of a given color
        if (useTestImage)
        {
            float start = Time.realtimeSinceStartup;
            Mat input = CvInvoke.Imread("test.png", LoadImageType.AnyColor);
            CvInvoke.CvtColor(input, input, ColorConversion.Bgr2Hsv);
            Image<Hsv, byte> img = input.ToImage<Hsv, byte>();
            Image<Gray, Byte> redimg = img.InRange(lower, upper);
            Debug.Log("Value of red square: " + img.Data[123, 134, 0] + "," + img.Data[123, 134, 1] + "," + img.Data[123, 134, 2]);
            Debug.Log("Value of target: " + targetHsv.Hue + "," + targetHsv.Satuation + "," + targetHsv.Value);

            CvInvoke.Erode(redimg, redimg, CvInvoke.GetStructuringElement(ElementShape.Ellipse, new Size(5,5), new Point(-1,-1)), new Point(-1,-1),1, BorderType.Default, new MCvScalar(1));
            CvInvoke.Dilate(redimg, redimg, CvInvoke.GetStructuringElement(ElementShape.Ellipse, new Size(5, 5), new Point(-1, -1)), new Point(-1, -1), 1, BorderType.Default, new MCvScalar(1));

            CvInvoke.Erode(redimg, redimg, CvInvoke.GetStructuringElement(ElementShape.Ellipse, new Size(5, 5), new Point(-1, -1)), new Point(-1, -1), 1, BorderType.Default, new MCvScalar(1));
            CvInvoke.Dilate(redimg, redimg, CvInvoke.GetStructuringElement(ElementShape.Ellipse, new Size(5, 5), new Point(-1, -1)), new Point(-1, -1), 1, BorderType.Default, new MCvScalar(1));

            MKeyPoint[] keyPoints = blobDetector.Detect(redimg);
            Features2DToolbox.DrawKeypoints(img, new VectorOfKeyPoint(keyPoints),img,new Bgr(System.Drawing.Color.Red), Features2DToolbox.KeypointDrawType.Default);
            getObjectCenters(redimg.Mat, img.Mat);

            float end = Time.realtimeSinceStartup - start;
            Debug.Log("Detection time: " + end);
            redimg.ToBitmap().Save("testThresh.png");
            CvInvoke.Imwrite("testHsv.jpg", input);
            img.ToBitmap().Save("testout.png");



            tex.SetPixels32(toTexture(redimg));
            tex.Apply(false);
        }
        else
        {
            if (kinect.pollColor())
            {

                Image<Bgr, byte> input = mipmapImg(kinect.getColor(), width, height);
                Mat mat = input.Mat.Clone();
                float start = Time.realtimeSinceStartup;
                CvInvoke.CvtColor(mat, mat, ColorConversion.Bgr2Hsv);
                Image<Hsv, byte> img = mat.ToImage<Hsv, byte>();

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    calibrateColors(img);
                }


                Image<Gray, Byte> redimg = img.InRange(lower, upper);

                CvInvoke.Erode(redimg, redimg, CvInvoke.GetStructuringElement(ElementShape.Ellipse, new Size(5, 5), new Point(-1, -1)), new Point(-1, -1), 1, BorderType.Default, new MCvScalar(1));
                CvInvoke.Dilate(redimg, redimg, CvInvoke.GetStructuringElement(ElementShape.Ellipse, new Size(5, 5), new Point(-1, -1)), new Point(-1, -1), 1, BorderType.Default, new MCvScalar(1));

                CvInvoke.Erode(redimg, redimg, CvInvoke.GetStructuringElement(ElementShape.Ellipse, new Size(5, 5), new Point(-1, -1)), new Point(-1, -1), 1, BorderType.Default, new MCvScalar(1));
                CvInvoke.Dilate(redimg, redimg, CvInvoke.GetStructuringElement(ElementShape.Ellipse, new Size(5, 5), new Point(-1, -1)), new Point(-1, -1), 1, BorderType.Default, new MCvScalar(1));


                MKeyPoint[] keyPoints = blobDetector.Detect(redimg);

                Features2DToolbox.DrawKeypoints(redimg, new VectorOfKeyPoint(keyPoints), redimg, new Bgr(System.Drawing.Color.Red), Features2DToolbox.KeypointDrawType.Default);

                float end = Time.realtimeSinceStartup - start;
                //Debug.Log("Detection time: " + end + "\n keyPoints: " + keyPoints.Length);
                getObjectCenters(redimg.Mat, input.Mat);
                tex.SetPixels32(toTexture(input));
            tex.Apply(false);
                //img.ToBitmap().Save("test.png");
            }
        }

    }

    private void calibrateColors(Image<Hsv, byte> img)
    {
        int x = img.Cols / 2;
        int y = img.Rows / 2;
        targetHsv.Hue = img.Data[y, x, 0];
        targetHsv.Satuation = img.Data[y, x, 1];
        targetHsv.Value = img.Data[y, x, 2];
        Debug.Log("calibrated target color to" + targetHsv + "\n");
        lower = new Hsv(targetHsv.Hue - tolerance.Hue, targetHsv.Satuation - tolerance.Satuation, targetHsv.Value - tolerance.Value);
        upper = new Hsv(targetHsv.Hue + tolerance.Hue, targetHsv.Satuation + tolerance.Satuation, targetHsv.Value + tolerance.Value);
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

    private Color32[] toTexture(Image<Bgr, byte> src)
    {
        int width = src.Cols;
        int height = src.Rows;
        Color32[] dst = new Color32[width * height];
        for (int yy = 0; yy < height; yy++)
        {
            for (int xx = 0; xx < width; xx++)
            {
                dst[xx + yy * width] = new Color32(src.Data[yy, xx, 2], src.Data[yy, xx, 1], src.Data[yy, xx, 0], 255);
            }
        }
        return dst;
    }
    private Color32[] toTexture(Image<Gray, byte> src)
    {
        int width = src.Cols;
        int height = src.Rows;
        Color32[] dst = new Color32[width * height];
        for (int yy = 0; yy < height; yy++)
        {
            for (int xx = 0; xx < width; xx++)
            {
                dst[xx + yy * width] = new Color32(src.Data[yy, xx,0], src.Data[yy, xx,0], src.Data[yy, xx,0], 255);
            }
        }
        return dst;
    }

    private MCvMoments getObjectCenters(Mat image, Mat display)
    {
        MCvMoments moments = CvInvoke.Moments(image);

        if(moments.M00 > 100)
        {
            int x = (int) (moments.M10 / moments.M00);
            int y = (int) (moments.M01 / moments.M00);
            CvInvoke.Circle(display, new Point(x, y),2, new MCvScalar(255, 0, 0));
        }
        return moments;
    }

    private Hsv unityColorToHsv(UnityEngine.Color color)
    {
        float h = 0;
        float s = 0;
        float v = 0;
        UnityEngine.Color.RGBToHSV(color, out h, out s, out v);
        return new Hsv(h*360, s*255, v*255);
    }
}
