using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using UnityEngine.UI;

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
        byte[] pixels = mugshot.EncodeToPNG();
        byte[] score = System.Text.Encoding.ASCII.GetBytes(timeText);
        byte[] final = new byte[pixels.Length + score.Length];
        System.Buffer.BlockCopy(pixels, 0, final, 0, pixels.Length);
        System.Buffer.BlockCopy(score, 0, final, pixels.Length, score.Length);
        string id = System.Guid.NewGuid().ToString("N");
        File.WriteAllBytes("images/" + id + ".png", final);
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
