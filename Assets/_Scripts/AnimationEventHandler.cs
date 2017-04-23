using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHandler : MonoBehaviour {

    [SerializeField]
    public GameObject parentCharacter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void hit()
    {
        transform.parent.GetComponent<Character>().hit();
    }
}
