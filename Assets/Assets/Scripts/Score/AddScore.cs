using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScore : MonoBehaviour {

	dreamloLeaderBoard dl;
	string playerName = "";
	int score = 0;

	public InputField playerNameInput;
	public GameObject successMessage;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		this.dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();
	}

	public void SetScore(int score) {
		this.score = score;
		var scoreLebel = GameObject.Find("ScoreLabel").GetComponent<Text>(); 
		scoreLebel.text = scoreLebel.text + " " + this.score;
	}

	public void SubmitScore() {
		GameObject.Find("ScoreLabel").SetActive (true);
		this.playerName = playerNameInput.text.ToString();

		if (dl.publicCode == "") Debug.LogError("You forgot to set the publicCode variable");
		if (dl.privateCode == "") Debug.LogError("You forgot to set the privateCode variable");

		dl.AddScore(this.playerName, this.score);

		playerNameInput.gameObject.SetActive (false);
		GameObject.Find("Submit").SetActive (false);
		successMessage.SetActive (true);
	}
}
