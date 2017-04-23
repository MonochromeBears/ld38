using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitLight : MonoBehaviour {

	private float duration = 0f;
	private float limit = 0.5f;
	private bool summoned = false;

	// Use this for initialization
	void Start () {
		this.reset();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.summoned) {
			this.duration += Time.deltaTime;

			if (this.duration > this.limit) {
				this.reset();
			}
		}
	}

	void reset() {
		this.duration = 0f;
		this.summoned = false;
		this.transform.position = Vector3.zero;
	}

	public void summon(Vector3 hitPoint) {
		Debug.Log(hitPoint);
		this.duration = 0f;
		this.summoned = true;
		this.transform.position = hitPoint;
	}
}
