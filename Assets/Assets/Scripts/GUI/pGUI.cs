using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bool hasNoHarvesters = GameObject.FindObjectsOfType<HarvesterController> ().Length == 0;
		bool isSyloDestroyed = GameObject.FindObjectsOfType<Sylo>().Length == 0;
		if (hasNoHarvesters || isSyloDestroyed) {
			this.transform.Find ("GameOver").gameObject.SetActive (true);
		}
	}
}
