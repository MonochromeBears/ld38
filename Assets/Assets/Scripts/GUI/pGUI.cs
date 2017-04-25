using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class pGUI : MonoBehaviour {
	public Sylo sylo;

	private bool isGameOver = false;

	public GameObject setScorePanel;
	dreamloLeaderBoard dl;
	string playerName = "";

	// Use this for initialization
	void Start () {
		this.dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.isGameOver) {
			return;
		}

		var harvestersLength = GameObject.FindObjectsOfType<HarvesterController> ().Length;
		bool hasNoHarvesters = harvestersLength == 0;
		bool isSyloDestroyed = GameObject.FindObjectsOfType<Sylo>().Length == 0;

		if ((hasNoHarvesters || isSyloDestroyed)) {
			this.GameOver ();
		}

		if (this.sylo != null && !this.isGameOver) {
			var score = GameObject.FindWithTag ("score").GetComponent<Text>();
			score.text = 
				string.Format ("Score: {0}", this.sylo.getCollected ());
		}

		var hCount = GameObject.FindWithTag ("h_count").GetComponent<Text>();
		hCount.text = 
			string.Format ("Harvesters left: {0}", harvestersLength);
	}

	private void GameOver() {
		this.isGameOver = true;
		this.transform.Find ("GameOver").gameObject.SetActive (true);
		//			GameObject.FindWithTag ("score").gameObject.SetActive (false);
		GameObject.FindWithTag ("h_count").gameObject.SetActive (false);
		GameObject.FindWithTag ("aim").gameObject.SetActive (false);
		GameObject.FindWithTag ("logger").gameObject.SetActive (false);

		setScorePanel.SetActive (true);
	}

	void OnGUI()
	{
		if (isGameOver) {
			GUILayoutOption[] width200 = new GUILayoutOption[] {GUILayout.Width(200)};

			float width = 400;  // Make this wider to add more columns
			float height = 200;

			Rect r = new Rect((Screen.width / 2) - (width / 2), (Screen.height / 2 + 50) - (height), width, height);
			GUILayout.BeginArea(r, new GUIStyle("box"));

			var score = this.sylo.getCollected ();

			GUILayout.Label("Total Score: " + score.ToString());
			GUILayout.BeginHorizontal();
			GUILayout.Label("Your Name: ");
			this.playerName = GUILayout.TextField(this.playerName, width200);

			if (GUILayout.Button("Save Score"))
			{
				Debug.Log ("here11");
				if (dl.publicCode == "") Debug.LogError("You forgot to set the publicCode variable");
				if (dl.privateCode == "") Debug.LogError("You forgot to set the privateCode variable");

				dl.AddScore(this.playerName, score);
			}
			GUILayout.EndHorizontal();

			GUILayout.EndArea();
		}
	}

}
