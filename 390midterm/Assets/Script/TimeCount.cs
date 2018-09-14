using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour {
	
	public Text ratioText;

	// Use this for initialization
	public static int timeLeft = 200;
	public static int nextSec = 1;


	// Update is called once per frame
	void Update () {
		if (Time.time > nextSec) {
			float ratio = ((float)timeLeft) / 200.0f;
			ratioText.text = timeLeft + "s";
			nextSec++;
			timeLeft--;
		}
		if (timeLeft < 0) {
			Application.LoadLevel ("Score");
			Score.score = EnableClick.s;
		}
	}
}
