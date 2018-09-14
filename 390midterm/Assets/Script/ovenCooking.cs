using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ovenCooking : MonoBehaviour {
	public static bool[] lst;
	public static bool start = false;

	public Image healthBar;
	public static bool reset = false;

	public static int timeLeft = 20;
	public static int nextSec = 1;
	public static bool isOver = false;
	private static int overcook = 6;

	void Start() {
		lst = new bool[5];
		for (int i = 0; i < 5; i++)
			lst [i] = false;
	}

	// Update is called once per frame
	void Update () {
		GameObject meat = GameObject.Find ("/interior/furniture/Pan/Oven/Meat");
		GameObject bread = GameObject.Find ("/interior/furniture/Pan/Oven/Bread");
		GameObject cabbage = GameObject.Find ("/interior/furniture/Pan/Oven/Cabbage");
		GameObject carrot = GameObject.Find ("/interior/furniture/Pan/Oven/Carrot");

		if (Time.time > nextSec) {
			nextSec++;
			if (start == false) {
				healthBar.GetComponent<Image> ().color = new Color32 (95, 238, 78, 95);
				healthBar.rectTransform.localScale = new Vector3 (1, 1, 1);
				timeLeft = 20;
				overcook = 6;
				reset = false;
				for (int i = 0; i < 5; i++)
					lst [i] = false;
				meat.SetActive (false);
				bread.SetActive (false);
				cabbage.SetActive (false);
				carrot.SetActive (false);
			}
			if (start == true && timeLeft > 0) {
				float ratio = ((float)timeLeft) / 20.0f;
				healthBar.rectTransform.localScale = new Vector3 (ratio, 1, 1);
				timeLeft--;
				if (lst [0] == true) {
					meat.SetActive (true);
				}
				if (lst [2] == true) {
					bread.SetActive (true);
				}
				if (lst [3] == true) {
					cabbage.SetActive (true);
				}
				if (lst [4] == true) {
					carrot.SetActive (true);
				}
			}
			if (start == true && reset == true) {
				healthBar.GetComponent<Image> ().color = new Color32 (95, 238, 78, 95);
				healthBar.rectTransform.localScale = new Vector3 (1, 1, 1);
				timeLeft = 20;
				overcook = 6;
				if (lst [0] == true) {
					meat.SetActive (true);
				}
				if (lst [2] == true) {
					bread.SetActive (true);
				}
				if (lst [3] == true) {
					cabbage.SetActive (true);
				}
				if (lst [4] == true) {
					carrot.SetActive (true);
				}
				reset = false;
			}
			if (timeLeft <= 0) {
				timeLeft = 0;
				if (overcook < 0) {
					healthBar.rectTransform.localScale = new Vector3 (1, 1, 1);
					healthBar.GetComponent<Image> ().color = new Color32 (255, 0, 34, 168);
					for (int i = 0; i < 5; i++)
						lst [i] = false;
					isOver = true;
					meat.SetActive (false);
					bread.SetActive (false);
					cabbage.SetActive (false);
					carrot.SetActive (false);
				} else {
					healthBar.rectTransform.localScale = new Vector3 (1, 1, 1);
					healthBar.GetComponent<Image> ().color = new Color32 (255, 200, 34, 168);
				}
				overcook--;
			}
		}
	}

}
