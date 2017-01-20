using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	private float speed = 20.0f;

	public float minX = -360.0f;
	public float maxX = 360.0f;

	public float minY = -90.0f;
	public float maxY = 90.0f;

	public float sensX = 100.0f;
	public float sensY = 100.0f;

	float rotationY = 0.0f;
	float rotationX = 0.0f;
	private float zoomSpeed = 2.0f;

	// Use this for initialization
	void Start () {
		//offset = transform.position - player.transform.position;
	}
	
	// LateUpdate is guaranted to run after all code in update has runned. 
	void LateUpdate () {
		if (Input.GetKey(KeyCode.RightArrow)){
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.LeftArrow)){
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.UpArrow)){
			transform.position += Vector3.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.DownArrow)){
			transform.position += Vector3.back * speed * Time.deltaTime;
		}

		rotationX += Input.GetAxis ("Mouse X") * sensX * Time.deltaTime;
		rotationY += Input.GetAxis ("Mouse Y") * sensY * Time.deltaTime;
		rotationY = Mathf.Clamp (rotationY, minY, maxY);
		transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);

		float scroll = Input.GetAxis("Mouse ScrollWheel");
		transform.Translate(0, scroll * zoomSpeed, scroll * zoomSpeed, Space.World);

	}
}
