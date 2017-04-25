using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour {

	dreamloLeaderBoard dl;

	void Start () 
	{
		// get the reference here...
		this.dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();

		// Stab: no request if not to do this;
		dl.AddScore("Looser", 0);
	}

	void Update () 
	{
	}

	void OnGUI()
	{
		GUILayoutOption[] width200 = new GUILayoutOption[] {GUILayout.Width(200)};

		float width = 400;  // Make this wider to add more columns
		float height = 200;

		Rect r = new Rect((Screen.width / 2) - (width / 2), (Screen.height / 2 + 50) - (height), width, height);
		GUILayout.BeginArea(r, new GUIStyle("box"));

		List<dreamloLeaderBoard.Score> scoreList = dl.ToListHighToLow();
		Debug.Log (scoreList.Count);
		Debug.Log (scoreList == null);
		if (scoreList == null) 
		{
			GUILayout.Label("(loading...)");
		} 
		else 
		{
			int maxToDisplay = 20;
			int count = 0;
			foreach (dreamloLeaderBoard.Score currentScore in scoreList)
			{
				Debug.Log (currentScore.playerName);
				count++;
				GUILayout.BeginHorizontal();
				GUILayout.Label(currentScore.playerName, width200);
				GUILayout.Label(currentScore.score.ToString(), width200);
				GUILayout.EndHorizontal();

				if (count >= maxToDisplay) break;
			}
		}

		GUILayout.EndArea();
	}


}