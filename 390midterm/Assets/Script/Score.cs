using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour {

	public static int high = 0;
	public static int score = 0;
	public Text h;
	public Text s;

	// Use this for initialization
	void Start () {
		if (score > high)
			high = score;
		s.text = "Score: " + score.ToString ();
		h.text = "High Score: " + high.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			Application.LoadLevel ("Level1");
		} 
		if (Input.GetKeyDown ("escape")) {
			Application.Quit ();
		}
	}
}
