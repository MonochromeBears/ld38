using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLog : MonoBehaviour {

	public int maxLines = 8;
	private Queue<string> queue = new Queue<string>();
	private string Mytext = "";

	public void NewActivity(string activity) {
		if (queue.Count >= maxLines)
			queue.Dequeue();

		queue.Enqueue(activity);

		Mytext = "";
		foreach (string st in queue)
			Mytext = Mytext + st + "\n";
	}


	void OnGUI() {

		GUI.Label(new Rect(5,                             // x, left offset
			(Screen.height - 255),            // y, bottom offset
			300f,                                // width
			250f), Mytext,GUI.skin.textArea);    // height, text, Skin features

	}
}
