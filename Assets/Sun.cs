using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour {
	public Transform target;
	public float RotationSpeed = 100f;
	public float OrbitDegrees = 1f;

	void Update () {
		this.transform.Rotate(Vector3.up, this.RotationSpeed * Time.deltaTime);
		this.transform.RotateAround(this.target.position, Vector3.up, this.OrbitDegrees);
	}
}
