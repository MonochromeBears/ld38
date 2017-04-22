using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {
	public GameObject resource;
	public GameObject earth;
	public int min = 50;
	public int max = 100;
	public int initialCount = 10;

	private List<Resource> resources;

	// Use this for initialization
	void Start () {
		this.resources = new List<Resource> ();

		for (int i = 0; i < this.initialCount; i++) {
			this.spawn ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		var resources = this.resources.FindAll (resource => resource.isEmpty ());

		foreach (Resource resource in resources) {
			this.resources.Remove (resource);
			Destroy (resource.gameObject);
			this.spawn ();
		}
	}

	void spawn() {
		Transform earthTransform = earth.GetComponent<Transform> ();

		Vector3 resourcePosition = Vector3.Scale (Random.onUnitSphere, earthTransform.localScale) / 2;

		GameObject resourceObject = Object.Instantiate (
			this.resource, 
			resourcePosition + earth.transform.position,
			Quaternion.FromToRotation (earth.transform.position, resourcePosition)
		);

		Resource resource = resourceObject.GetComponent<Resource> ();

		resource.min = this.min;
		resource.max = this.max;

		this.resources.Add (resource);
	}
}
