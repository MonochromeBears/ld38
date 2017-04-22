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
	}

	void spawn() {
		Transform earthTransform = earth.GetComponent<Transform> ();

		Vector3 resourcePosition = Vector3.Scale (Random.onUnitSphere, earthTransform.localScale) / 2;

		GameObject resource = Object.Instantiate (
			this.resource, 
			resourcePosition + earth.transform.position,
			new Quaternion()
		);

		resource.transform.rotation = Quaternion.FromToRotation (earth.transform.position, resourcePosition);
		Debug.Log (Quaternion.LookRotation(earth.transform.position - resourcePosition));
		this.resources.Add (resource.GetComponent<Resource>());
	}
}
