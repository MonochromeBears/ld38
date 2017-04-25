using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour {

	dreamloLeaderBoard dl;
	string playerName = "";
	int score = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();
	}

	public void SetScore(int score) {
		this.score = score;
	}

	void OnGUI()
	{
		GUILayoutOption[] width200 = new GUILayoutOption[] {GUILayout.Width(200)};

		float width = 400;  // Make this wider to add more columns
		float height = 200;

		Rect r = new Rect((Screen.width / 2) - (width / 2), (Screen.height / 2 + 50) - (height), width, height);
		GUILayout.BeginArea(r, new GUIStyle("box"));

		GUILayout.Label("Total Score: " + this.score.ToString());
		GUILayout.BeginHorizontal();
		GUILayout.Label("Your Name: ");
		this.playerName = GUILayout.TextField(this.playerName, width200);

		if (GUILayout.Button("Save Score"))
		{
			if (dl.publicCode == "") Debug.LogError("You forgot to set the publicCode variable");
			if (dl.privateCode == "") Debug.LogError("You forgot to set the privateCode variable");

			dl.AddScore(this.playerName, this.score);

		}
		GUILayout.EndHorizontal();

		GUILayout.EndArea();
	}
}
