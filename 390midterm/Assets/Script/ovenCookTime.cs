using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ovenCookTime : MonoBehaviour {

	public Image healthBar;
	public static bool isItem1;
	public static bool isItem2;
	public GameObject item1;
	public GameObject item2;
	public static bool reset = false;

	// Use this for initialization
	public static int timeLeft = 50;
	public static int nextSec = 1;

	void Start() {
		float a = Random.Range (0, 2);
		if (a < 1) {
			item1.SetActive (true);
			isItem1 = true;
		} else {
			item2.SetActive (true);
			isItem2 = true;
		}
	}

	// Update is called once per frame
	void Update () {
		if (Time.time > nextSec) {
			float ratio = ((float)timeLeft) / 50.0f;
			healthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
			nextSec++;
			timeLeft--;
		}
		if (timeLeft < 0 || reset == true) {
			timeLeft = 50;
			healthBar.rectTransform.localScale = new Vector3(1, 1, 1);
			item1.SetActive (false);
			item2.SetActive (false);
			float a = Random.Range (0, 2);
			isItem1 = false;
			isItem2 = false;
			if (a < 1) {
			item1.SetActive (true);
			isItem1 = true;
			} else {
				item2.SetActive (true);
				isItem2 = true;
			}
		}
	}
}