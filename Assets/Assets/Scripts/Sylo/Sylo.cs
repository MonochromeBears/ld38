using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sylo : MonoBehaviour {
	public int damage = 30;
	public GameObject resource;

	private int capacity = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (this.damage <= 0) {
			Debug.Log("You are an idiot");
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
