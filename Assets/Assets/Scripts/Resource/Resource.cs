using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour {
	public int max = 50;
	public int min = 25;

	private int capacity;

	// Use this for initialization
	void Start () {
		this.capacity = Random.Range (this.min, this.max);
	}
	
	// Update is called once per frame
	void Update () {
		if (this.isEmpty ()) {
			Debug.Log ("Destroy");
			Destroy (this.gameObject, 2);
		}
	}

	public bool isEmpty() {
		return this.capacity == 0;
	}

	public int collect(int capacity) {
		int collectedCapacity = System.Math.Min (this.capacity, capacity);

		this.capacity -= collectedCapacity;


		return collectedCapacity;
	}

	public int getCapacity() {
		return this.capacity;
	}
}
