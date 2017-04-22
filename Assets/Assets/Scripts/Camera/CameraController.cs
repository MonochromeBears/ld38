using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Transform target;
	public float xSpeed = 12.0f;
	public float ySpeed = 12.0f;
	public float zSpeed = 12.0f;
	public float scrollSpeed = 10.0f;

	public float zoomMin = 1.0f;
	public float zoomMax = 20.0f;

	public float distance;
	public Vector3 position;
	public bool isActivated;
	public Texture aimTexture;


	float x = 0.0f;
	float y = 0.0f;


	// Use this for initialization
	void Start () {
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
	}

	void Update() {
//		Screen.lockCursor = true;
	}

	void LateUpdate () {
		if (this.target == null) {
			return;
		}

		Vector3 movement = new Vector3(
			-1.0f * this.xSpeed * Input.GetAxis ("Horizontal"),
			this.ySpeed * Input.GetAxis ("Vertical"),
			this.zSpeed * Input.GetAxis ("Zoom")) * 
			Time.deltaTime;

		this.transform.RotateAround(this.target.position, this.transform.up, movement.x);
		this.transform.RotateAround(this.target.position, this.transform.right, movement.y);

		float distance = this.ZoomLimit(
			Vector3.Distance (this.transform.position, this.target.position) - 
			this.zSpeed * Input.GetAxis ("Zoom")
		);
		
		this.transform.position = this.target.position - this.transform.forward * distance; 
	}

	public float ZoomLimit(float dist)
	{
		if (dist < this.zoomMin) {
			dist = this.zoomMin;
		}

		if (dist > this.zoomMax) {
			dist = this.zoomMax; 
		}

		return dist;
	}

	public void OnGUI() {
//		GUI.color = Color.black;
		GUI.DrawTexture (new Rect (Screen.width / 2 - 256, Screen.height / 2 - 182, 512, 364), this.aimTexture);
	}
}
