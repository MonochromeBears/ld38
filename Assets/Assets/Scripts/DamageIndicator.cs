using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIndicator : MonoBehaviour {

	private float duration = 0f;
	private float limit = 0.5f;

	// Update is called once per frame
	void Update () {
		this.duration += Time.deltaTime;

		if (this.duration >= this.limit) {
			DamageIndicator.Destroy(this.gameObject);
		}
	}
}
