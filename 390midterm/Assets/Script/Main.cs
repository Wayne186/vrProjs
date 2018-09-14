using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {

	public Button start;

	void Start() {
		Button btn = start.GetComponent<Button>();
		btn.onClick.AddListener(toStart);
	}

	// Update is called once per frame
	void Update () {

	}

	public void toStart() {
		Application.LoadLevel ("Level1");
	}

	public void toScore() {
		Application.LoadLevel ("HighScore");
	}

	public void Quit() {
		Application.Quit ();
	}

}
