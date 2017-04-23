using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sylo : MonoBehaviour {
	public int damage = 30;
	public GameObject resource;
	public GameObject explosion;

	private int capacity = 0;
	private bool playingDeath = false;
	private float animationDuration = 2.0f;
	private GameObject anim;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (this.playingDeath) {
			this.animationDuration -= Time.deltaTime;

			if (this.animationDuration <= 0) {
				Sylo.Destroy(this.anim);
				Sylo.Destroy(this.gameObject);
			}
		}

		if (this.damage <= 0 && !this.playingDeath) {
			this.playingDeath = true;
			GameObject model = this.transform.Find("SyloDepot").gameObject;
			model.GetComponent<Renderer>().enabled = false;
			this.anim = Sylo.Instantiate(this.explosion, this.transform.position, this.transform.rotation);
		}
	}

	public void getDamage() {
		this.damage -= 10;
	}

	public void load(int capacity) {
		this.capacity += capacity;
	}

	public int getCollected() {
		return this.capacity;
	}
}
