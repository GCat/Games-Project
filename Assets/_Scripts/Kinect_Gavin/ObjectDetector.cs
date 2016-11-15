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
using UnityEngine.UI;


public class ObjectDetector : MonoBehaviour {

    public DepthWrapper dw;
    public DeviceOrEmulator devOrEmu;
    public GameObject imagePlane;
    public GameObject testCube;
    public GameObject playerLocation;
    public UnityEngine.Color target;
    private Hsv targetHsv;
    private Hsv tolerance = new Hsv(15, 50, 50);
    private Hsv lower;
    private Hsv upper;

    public Text text;
    
    private Kinect.KinectInterface kinect;
    private int width = 640;
    private int height = 480;
    private float depthWidth = 320;
    private float depthHeight = 240;
    private float scale = 50f;
    private bool done = false;
    public bool useTestImage;
    private SimpleBlobDetector blobDetector;
    private Texture2D tex;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    private Matrix4x4 kinectToWorld;
    public Matrix4x4 flipMatrix;
    private float lastGoodZ;
    private bool a = true;
    private short[] mappedDepth;
    struct Coord
    {
        public int x;
        public int y;
        public int z;
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


        Matrix4x4 trans = new Matrix4x4();
        trans.SetTRS(new Vector3(-kinect.getKinectCenter().x,
                                  kinect.getSensorHeight() - kinect.getKinectCenter().y,
                                  -kinect.getKinectCenter().z),
                     Quaternion.identity, Vector3.one);
        Matrix4x4 rot = new Matrix4x4();
        Quaternion quat = new Quaternion();
        double theta = Mathf.Atan((kinect.getLookAt().y + kinect.getKinectCenter().y - kinect.getSensorHeight()) / (kinect.getLookAt().z + kinect.getKinectCenter().z));
        float kinectAngle = (float)(theta * (180 / Mathf.PI));
        quat.eulerAngles = new Vector3(-kinectAngle, 0, 0);
        rot.SetTRS(Vector3.zero, quat, Vector3.one);

        //final transform matrix offsets the rotation of the kinect, then translates to a new center
        kinectToWorld = flipMatrix * trans * rot;
        //Kinect.INuiCoordinateMapper frameTexture = (Kinect.INuiCoordinateMapper)Marshal.GetObjectForIUnknown(ptr);
        mappedDepth = new short[640 * 480];
    }

    void FixedUpdate()
    {
       
    }

    // Update is called once per frame
    void Update () {

        if (kinect.pollColor())
        {
            if (dw.pollDepth())
            {
                try
                {

                    mappedDepth = dw.mappedDepth;

                }
                catch (Exception e)
                {
                    Debug.Log(e);
                }

                Image<Bgr, byte> input = mipmapImg(kinect.getColor(), width, height);
                Mat mat = input.Mat.Clone();
                float start = Time.realtimeSinceStartup;
                CvInvoke.CvtColor(mat, mat, ColorConversion.Bgr2Hsv);
                Image<Hsv, byte> img = mat.ToImage<Hsv, byte>();

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    calibrateColors(img);
                }
                CvInvoke.Circle(input.Mat, new Point((int)img.Cols / 2, (int)img.Rows / 2), 5, new MCvScalar(255, 0, 0));

                //Debug.Log(coordinateMapper);

                Image<Gray, Byte> redimg = img.InRange(lower, upper);

                CvInvoke.Erode(redimg, redimg, CvInvoke.GetStructuringElement(ElementShape.Ellipse, new Size(5, 5), new Point(-1, -1)), new Point(-1, -1), 1, BorderType.Default, new MCvScalar(1));
                CvInvoke.Dilate(redimg, redimg, CvInvoke.GetStructuringElement(ElementShape.Ellipse, new Size(5, 5), new Point(-1, -1)), new Point(-1, -1), 1, BorderType.Default, new MCvScalar(1));

                CvInvoke.Erode(redimg, redimg, CvInvoke.GetStructuringElement(ElementShape.Ellipse, new Size(5, 5), new Point(-1, -1)), new Point(-1, -1), 1, BorderType.Default, new MCvScalar(1));
                CvInvoke.Dilate(redimg, redimg, CvInvoke.GetStructuringElement(ElementShape.Ellipse, new Size(5, 5), new Point(-1, -1)), new Point(-1, -1), 1, BorderType.Default, new MCvScalar(1));

             

                MKeyPoint[] keyPoints = blobDetector.Detect(redimg);
 


                float end = Time.realtimeSinceStartup - start;
                Vector3 center = getObjectCenter(redimg.Mat, input.Mat, dw.depthImg);
                //align test cube, ignore unread z coords


                Vector3 targetPosition = playerLocation.transform.position + center;
                //testCube.transform.position = Vector3.SmoothDamp(testCube.transform.position, targetPosition, ref velocity, smoothTime);
                testCube.transform.position = targetPosition;
                tex.SetPixels32(toTexture(input));
                tex.Apply(false);
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

    private Vector3 getObjectCenter(Mat image, Mat display, short[] depthImg)
    {
        GCHandle handle = GCHandle.Alloc(depthImg, GCHandleType.Pinned);
        IntPtr pointer = handle.AddrOfPinnedObject();



        MCvMoments moments = CvInvoke.Moments(image);
        Coord center = new Coord();
        double x = 0;
        double y = 0;
        if (moments.M00 > 100)
        {
            x = (moments.M10 / moments.M00);
            y =  (moments.M01 / moments.M00);
            center.x = (int)x;
            center.y = (int)y;
            CvInvoke.Circle(display, new Point((int)x, (int)y),10, new MCvScalar(0, 0, 255), 3);
        }

        //flip y you silly goose
        float depth = getDepth(center, depthImg);
        int minDistance = -10;
        float scaleFactor = 0.0021f;

        //x = (x - width / 2) * (depth + minDistance) * scaleFactor;
        //y = (y - height / 2) * (depth + minDistance) * scaleFactor;
        return new Vector3((float)x, (float)y, depth);
    }

    private Hsv unityColorToHsv(UnityEngine.Color color)
    {
        float h = 0;
        float s = 0;
        float v = 0;
        UnityEngine.Color.RGBToHSV(color, out h, out s, out v);
        return new Hsv(h*360, s*255, v*255);
    }

    private float getDepth(Coord center, short[] depthImg)
    {
        int pix = (int) (center.x + center.y*depthWidth);
        short depthValue= (mappedDepth[pix]);
        if(depthValue == 0)
        {
            return lastGoodZ;
        }else
        {
            //float z = 0.1236f * Mathf.Tan(depthValue / 2842.5f + 1.1863f);
            //text.text = (depthValue + " ->:" + z + "m");
            float z = depthValue << 3;
            Debug.Log(depthValue);
            lastGoodZ = z;
            return z;
        }
    }
}
