using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message {
	public string text { get; set; }
	public Color color { get; set; }
}

public class GameLog : MonoBehaviour {

	public int maxLines = 8;
	private Queue<string> queue = new Queue<string>();
	private Message myMessage = new Message {
		text = "Wellcome!!!",
		color = Color.green
	};

	public void NewActivity(string activity) {
		if (queue.Count >= maxLines)
			queue.Dequeue();

		queue.Enqueue(activity);

		myMessage.text = "";
		myMessage.color = Color.grey;
		foreach (string st in queue)
			myMessage.text = myMessage.text + st + "\n";
	}


	void OnGUI() {
		GUI.contentColor = myMessage.color;
		GUI.Label(new Rect(5,                             // x, left offset
			(Screen.height - 255),            // y, bottom offset
			300f,                                // width
			250f), myMessage.text ,GUI.skin.textArea);    // height, text, Skin features

	}
}
