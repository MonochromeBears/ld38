using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindObjectsOfType<HarvesterController> ().Length == 0) {
			this.transform.Find ("GameOver").gameObject.SetActive (true);
		}
	}
}
