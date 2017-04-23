using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sylo : MonoBehaviour {
	public int damage = 100;
	public GameObject resource;

	private int capacity = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void load(int capacity) {
		this.capacity = capacity;
	}
}
