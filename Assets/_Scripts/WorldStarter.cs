using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class WorldStarter : MonoBehaviour {
	public GameObject pathFinder;
	// Use this for initialization
	void Start () {
		StartCoroutine(wait());
	}
	
	IEnumerator wait(){
		PathFinding script = (PathFinding) pathFinder.GetComponent(typeof(PathFinding));
		while (!script.done){
			yield return new WaitForSeconds(2);
		}
		initializeStrucutre();
	}
	// Update is called once per frame
	void Update () {
	
	}

	void initializeStrucutre(){
		float [] xs = new float[] {5.0f,25.0f,-25.0f,33.7f};
		float [] zs = new float[] {-88.0f,37.0f,87.0f,21.7f};
		foreach(float x in xs){
			foreach(float z in zs){
				Vector3 pos = new Vector3(x,4.0f,z);
				GameObject pre = Resources.Load("House") as GameObject;
				GameObject c = GameObject.Instantiate(pre,pos, Quaternion.identity) as GameObject;
			}
		}
		Vector3 position = new Vector3(0.0f,0.5f,0.0f);
		GameObject pref = Resources.Load("Human") as GameObject;
		GameObject h = GameObject.Instantiate(pref,position, Quaternion.identity) as GameObject;
		position = new Vector3(10.0f,0.5f,0.0f);
		GameObject h1 = GameObject.Instantiate(pref,position, Quaternion.identity) as GameObject;
		position = new Vector3(10.0f,0.5f,-15.0f);
		GameObject h2 = GameObject.Instantiate(pref,position, Quaternion.identity) as GameObject;
		position = new Vector3(25.0f,0.5f,-15.0f);
		GameObject h3 = GameObject.Instantiate(pref,position, Quaternion.identity) as GameObject;
	}
}
