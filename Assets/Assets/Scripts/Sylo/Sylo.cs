using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sylo : MonoBehaviour {
	public int damage = 30;
	public GameObject resource;
	public GameObject explosion;
	public GameObject harvester;

	private int spawnCapacity = 0;
	private int spawnLimit = 500;
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
				Debug.LogError ("You destroy the sylo depot!!!");
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

		this.SpawnExtraHarvester();
	}

	void SpawnExtraHarvester() {
		int harvAmount = GameObject.FindObjectsOfType<HarvesterController>().Length;
		bool isLimitReached = this.spawnCapacity >= this.spawnLimit;

		if (harvAmount < 4 && isLimitReached) {
			this.spawnCapacity = 0;
			Sylo.Instantiate(
				this.harvester, 
				this.transform.position + new Vector3(4, 0, 0), 
				this.transform.rotation
			);
		}
	}

	public void getDamage() {
		this.damage -= 10;
		Debug.LogError ("Stop attack sylo depot!!!");
	}

	public void load(int capacity) {
		this.spawnCapacity += capacity;
		this.capacity += capacity;
	}

	public int getCollected() {
		return this.capacity;
	}
}
