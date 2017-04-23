using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class pGUI : MonoBehaviour {
	public Sylo sylo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bool hasNoHarvesters = GameObject.FindObjectsOfType<HarvesterController> ().Length == 0;
		bool isSyloDestroyed = GameObject.FindObjectsOfType<Sylo>()[0].damage == 0;
		if (hasNoHarvesters || isSyloDestroyed) {
			this.transform.Find ("GameOver").gameObject.SetActive (true);
		}
		if (this.sylo != null) {
			var score = GameObject.FindWithTag ("score").GetComponent<Text>();
			score.text = 
				string.Format ("Score: {0}", this.sylo.getCollected ());
		}
	}
}
