using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Drawing.Text;
using Microsoft.Win32;
using System;

public class WorldStarter : MonoBehaviour
{
    public GameObject colorScreen;
    private ColorSourceManager colorManager;
    private float startTime;
    public Text gameOverText;
    public Portal portal;
    string timeText;
    bool quit = false;

    void Start()
    {
        colorManager = colorScreen.GetComponent<ColorSourceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (quit)
        {
            Application.Quit();
        }

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
        try
        {
            StartCoroutine(mugShotCountdown());
        }
        catch (Exception e)
        {

        }
    }



    IEnumerator mugShotCountdown()
    {
        string text = gameOverText.text;
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
        quit = true;
    }


    private void takeMugShot()
    {
        var foo = new PrivateFontCollection();
        Texture2D mugshot = colorManager.GetColorTexture();
        Image<Bgr, byte> img = UnityTextureToOpenCVImage(mugshot);
        
        img = img.Rotate(90.0, new Bgr(0, 0, 0), false);
        timeText = addtimeScore();
        string score = timeText;
        img.Draw(score, new System.Drawing.Point(300, 100),
            FontFace.HersheyComplex, 3.0, new Bgr(242, 25, 236),3);

        AddLogo(img);
        
    }

    private void AddLogo(Image<Bgr,Byte> image)
    {
        int x = 0;
        int y = 0;
        Image<Bgra, Byte> logoIm = new Image<Bgra, Byte>("C:/Users/gp14958/OneDrive/images/logo.png");
        for (int i = image.Mat.Cols -200; i < image.Mat.Cols; i++)
        {
            for(int j = image.Mat.Rows -200; j<image.Mat.Rows; j++)
            {
                Bgra logoVal = logoIm[x, y];
                if(logoVal.Alpha != 0)
                {
                    Bgr v = new Bgr(logoVal.Blue, logoVal.Green, logoVal.Red);
                    image[i, j]= v;
                }
                y++;
            }
            x++;
        }

        string id = System.Guid.NewGuid().ToString("N");
        image.Save("C:/Users/gp14958/OneDrive/images/" + id + ".png");
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
        int secint = (int)sec;
        string text = "Lasted " + min + " min " + secint + " s!";
        return text;
    }
}
