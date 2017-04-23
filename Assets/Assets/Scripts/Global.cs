using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {
	public static bool afterStart = true;
	public pGUI gui;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);

		if (Global.afterStart) {
			var ui = GameObject.Find ("UI");
			var startMenu = ui.GetComponent<ShowPanels>();

			this.gui.gameObject.SetActive (false);
			startMenu.ShowMenu();
		}

		Global.afterStart = false;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
