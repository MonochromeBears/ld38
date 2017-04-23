using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class pGUI : MonoBehaviour {
	public Sylo sylo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var harvestersLength = GameObject.FindObjectsOfType<HarvesterController> ().Length;
		bool hasNoHarvesters = harvestersLength == 0;
		bool isSyloDestroyed = GameObject.FindObjectsOfType<Sylo>().Length == 0;

		if (hasNoHarvesters || isSyloDestroyed) {
			this.transform.Find ("GameOver").gameObject.SetActive (true);
			GameObject.FindWithTag ("score").gameObject.SetActive (false);
			GameObject.FindWithTag ("h_count").gameObject.SetActive (false);
			GameObject.FindWithTag ("aim").gameObject.SetActive (false);
			GameObject.FindWithTag ("logger").gameObject.SetActive (false);
		}

		if (this.sylo != null) {
			var score = GameObject.FindWithTag ("score").GetComponent<Text>();
			score.text = 
				string.Format ("Score: {0}", this.sylo.getCollected ());
		}

		var hCount = GameObject.FindWithTag ("h_count").GetComponent<Text>();
		hCount.text = 
			string.Format ("Harvesters left: {0}", harvestersLength);
	}
}
