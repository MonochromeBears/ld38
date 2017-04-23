using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

	public GameObject particleSystem;

	private ParticleSystem instance;
	private float duration = 0f;
	private float limit = 1f;
	private bool isSummoned = false;

	// Use this for initialization
	void Start () {
		GameObject effect = Teleport.Instantiate(
			this.particleSystem, 
			this.transform.position,
			this.transform.rotation);
		
		this.instance = effect.transform.Find("Particle System").GetComponent<ParticleSystem>();
		this.reset();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.isSummoned) {
			this.duration += Time.deltaTime;

			if (this.duration > this.limit) {
				this.reset();
			}
		}
	}

	void reset() {
		this.duration = 0;
		this.isSummoned = false;
		this.instance.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
	}

	public void summon() {
		this.duration = 0;
		this.isSummoned = true;
		this.instance.Play();
	}
}
