using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.IO;

public class WorldStarter : MonoBehaviour {
    public ColorSourceManager colorManager;

    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

	}

	public void startGame(){


    }

    public void stopGame(){
        Debug.Log("Game finished");
        this.GetComponent<Animator>().SetTrigger("GameOver");
        if (colorManager != null)
        {
            takeMugShot();
        }
    }

    private void takeMugShot()
    {
        Texture2D mugshot = colorManager.GetColorTexture();
        byte[] pixels = mugshot.EncodeToPNG();
        string id = System.Guid.NewGuid().ToString("N");
        File.WriteAllBytes("images/" + id + ".png", pixels);

    }
}
