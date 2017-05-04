using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System.Drawing;

public class WorldStarter : MonoBehaviour
{
    public GameObject colorScreen;
    private ColorSourceManager colorManager;
    private float startTime;
    private Rect TextAreaRect = new Rect(25, 25, 250, 100);
    public Text gameOverText;
    public Portal portal;
    string timeText;
    bool recordTime = false;
    void Start()
    {
        colorManager = colorScreen.GetComponent<ColorSourceManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startGame()
    {
        startTime = Time.time;
    }

    public void stopGame()
    {
        Debug.Log("Game finished");
        this.GetComponent<Animator>().SetTrigger("GameOver");
        colorScreen.SetActive(true);
        if (portal != null)
        {
            portal.gameOver(false);
        }
        colorScreen.GetComponent<ColorSourceView>().pause(false);
        StartCoroutine(mugShotCountdown());
    }



    IEnumerator mugShotCountdown()
    {
        string text = gameOverText.text;
        recordTime = true;
        for (int i = 5; i >= 0; i--)
        {
            yield return new WaitForSeconds(1);
            gameOverText.text = text + " " + i.ToString();
        }
        gameOverText.text = "";

        if (colorManager != null)
        {
            takeMugShot();
        }
        yield return new WaitForSeconds(2);
        Application.Quit();
    }


    private void takeMugShot()
    {
        Texture2D mugshot = colorManager.GetColorTexture();
        Image<Bgr, byte> img = UnityTextureToOpenCVImage(mugshot);
        int pointx = img.Mat.Cols/2;
        int pointy = img.Mat.Rows / 2;

        string score = string.Format("Score: {}",timeText);
        img.Draw(score, new System.Drawing.Point(pointx, pointy),
            FontFace.HersheyComplex, 2.0, new Bgr(255, 255, 255));
        string id = System.Guid.NewGuid().ToString("N");
        img.Save("images/" + id + ".png");
       
    }


    public  Image<Bgr, byte> UnityTextureToOpenCVImage(Texture2D tex)
    {
        return UnityTextureToOpenCVImage(tex.GetPixels32(), tex.width, tex.height);
    }

    public  Image<Bgr, byte> UnityTextureToOpenCVImage(Color32[] data, int width, int height)
    {

        byte[,,] imageData = new byte[width, height, 3];


        int index = 0;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                imageData[x, y, 0] = data[index].b;
                imageData[x, y, 1] = data[index].g;
                imageData[x, y, 2] = data[index].r;

                index++;
            }
        }

        Image<Bgr, byte> image = new Image<Bgr, byte>(imageData);

        return image;
    }

    private string addtimeScore()
    {
        float now = Time.time - startTime;
        float min = Mathf.Floor(now / 60);
        float sec = now % 60;
        string text = "Lasted " + min + " min" + sec + " s!";
        return text;
    }

    void OnGUI()
    {
        if (recordTime)
        {
            timeText = addtimeScore();
            timeText = GUI.TextField(new Rect(100, 100, 1000, 600), timeText, 75);
            recordTime = false;
        }
    }
}
