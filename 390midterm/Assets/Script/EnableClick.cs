using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableClick : MonoBehaviour {

	public GameObject player;
	private GameObject cam;
	public GameObject hold;

	//0 for meat, 1 for apple, 2 for bread, 3 for cabbage, 4 for carrot
	public int item;
	//1 for cut, 2 for pot, 3 for pan, 4 for throw, 5 for oven, 6 for in
	public int place;
	public GameObject obj;
	private static int left = 3;
	private static int n = 1;
	private static bool w = false;
	public Text cutting;
	public Text score;
	public static int s = 0;



	// Use this for initialization
	void Start () {
		cam = GameObject.Find("Camera");
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > n) {
			n++;
			if (w == true)
				left--;
		}
		if (w == true) {
			if (left < 1) { 
				Debug.Log ("in");
				player.GetComponent<BKN> ().enabled = true;
				cam.GetComponent<Movement> ().enabled = true;
				w = false;
				left = 3;
				cutting.text = "";
			}
		}
		if (Vector3.Distance (transform.position, player.transform.position) < 2.6) {
			if (Input.GetKeyDown ("space")) {
				//pick
				if (HoldScript.getHold () == false && (place == 0)) {
					HoldScript.setHold (true);
					HoldScript.setItem (item);
					Debug.Log ("<color=red>Picked!!</color>");
					obj.SetActive (true);
				} 
				//cut
				else if ((HoldScript.getHold () == true) && (place == 1) &&
				         (HoldScript.getDeal () == false) &&
				         (HoldScript.getItem () > 0)) {
					Debug.Log ("<color=red>Cutted!!</color>");
					obj.SetActive (true);
					HoldScript.setDeal (true);
					cutting.text = "Cutting!!";
					w = true;
					player.GetComponent<BKN> ().enabled = false;
					cam.GetComponent<Movement> ().enabled = false;
				} 
				//boil
				else if ((place == 2)) {
					if (HoldScript.getHold () != true) {
						Debug.Log ("Take Pot");
						if (potCooking.timeLeft == 0 && potCooking.isOver == false)
							HoldScript._well = true;
						HoldScript.setHold (true);
						for (int i = 0; i < 5; i++)
							HoldScript.food[i] = potCooking.list[i];
						HoldScript._haveFood = true;
						obj.SetActive (true);
						potCooking.start = false;
						HoldScript.cook = 2;
					} else {
						if (HoldScript.getDeal () == true || HoldScript.getItem () == 0) {
							Debug.Log ("<color=red>Boil!!</color>");
							if (potCooking.start == false)
								potCooking.start = true;
							else if (potCooking.isOver == true) {
								HoldScript.clear ();
								return;
							} else {
								potCooking.reset = true;
								Debug.Log ("reset");
							}
							Debug.Log (HoldScript.getItem ());
							potCooking.list [HoldScript.getItem ()] = true;
							HoldScript.clear ();
						}
						if (HoldScript._haveFood == true && potCooking.isOver == false) {
							Debug.Log ("Put food boil");
							potCooking.start = true;
							for (int i = 0; i < 5; i++)
								potCooking.list[i] = HoldScript.food[i];
							HoldScript.clear ();
						}
					}
				}
				//fry
				else if ((place == 3)) {
					if (HoldScript.getHold () != true) {
						Debug.Log ("Take Pan");
						if (panCooking.timeLeft == 0 && panCooking.isOver == false)
							HoldScript._well = true;
						HoldScript.setHold (true);
						for (int i = 0; i < 5; i++)
							HoldScript.food[i] = panCooking.list[i];
						HoldScript._haveFood = true;
						obj.SetActive (true);
						panCooking.start = false;
						HoldScript.cook = 3;
					} else {
						if (HoldScript.getDeal () == true || HoldScript.getItem () == 0) {
							Debug.Log ("<color=red>Fry!!</color>");
							if (panCooking.start == false)
								panCooking.start = true;
							else if (panCooking.isOver == true) {
								HoldScript.clear ();
								return;
							} else {
								panCooking.reset = true;
								Debug.Log ("reset");
							}
							Debug.Log (HoldScript.getItem ());
							panCooking.list [HoldScript.getItem ()] = true;
							HoldScript.clear ();
						}
						if (HoldScript._haveFood == true && panCooking.isOver == false) {
							Debug.Log ("Put food fry");
							panCooking.start = true;
							for (int i = 0; i < 5; i++)
								panCooking.list[i] = HoldScript.food[i];
							HoldScript.clear ();
						}
					}
				}
				//throw
				else if ((HoldScript.getHold () == true) && (place == 4)) {
					Debug.Log ("<color=red>Throw!!</color>");
					HoldScript.clear ();
				} 
				//hand in food
				else if ((HoldScript._haveFood == true) && (place == 6) && HoldScript._well == true) {
					Debug.Log ("<color=red>Hand In!!</color>");
					for (int i = 0; i < 5; i ++)
						Debug.Log (HoldScript.food[i]);
					Debug.Log (HoldScript._well);
					if (HoldScript.cook == 2) {
						if (potCookTime.isItem1 == true) {
							Debug.Log ("pot1");
							if (HoldScript.food [0] == false && HoldScript.food [1] == true
							    && HoldScript.food [2] == false && HoldScript.food [3] == true
							    && HoldScript.food [4] == true) {
								s = s + 30;
								score.text = s.ToString();
							}
						}
						if (potCookTime.isItem2 == true) {
							Debug.Log ("pot2");
							if (HoldScript.food [0] == true && HoldScript.food[1] == false
								&& HoldScript.food[2] == false && HoldScript.food[3] == true
								&& HoldScript.food[4] == true) {
								s = s + 30;
								score.text = s.ToString();
							}
						}
					} else if (HoldScript.cook == 3) {
						Debug.Log ("pan1");
						if (panCookTime.isItem1 == true) {
							if (HoldScript.food [0] == true && HoldScript.food[1] == false
								&& HoldScript.food[2] == false && HoldScript.food[3] == true
								&& HoldScript.food[4] == true) {
								s = s + 30;
								score.text = s.ToString();
							}
						}
						if (panCookTime.isItem2 == true) {
							Debug.Log ("pan2");
							if (HoldScript.food [0] == true && HoldScript.food[1] == false
								&& HoldScript.food[2] == false && HoldScript.food[3] == false
								&& HoldScript.food[4] == true) {
								s = s + 20;
								score.text = s.ToString();
							}
						}
					}
					HoldScript.clear ();
				}
			}
		}
	}
}
