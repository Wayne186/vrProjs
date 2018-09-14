using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldScript : MonoBehaviour {

	//0 for meat, 1 for apple, 2 for bread, 3 for cabbage, 4 for carrot
	private static int item;
	private static bool _deal;
	private static bool _isHold;
	public static bool _haveFood;
	public static bool _well = false;
	public static bool[] food;
	public static GameObject apple;
	public static GameObject cut;
	public static GameObject cabbage;
	public static GameObject bread;
	public static GameObject carrot;
	public static GameObject dish;
	public static GameObject bowl;
	public static GameObject meat;
	public static int cook = 0;


	// Use this for initialization
	void Start () {
		_haveFood = false;
		food = new bool[5];
		apple = GameObject.Find ("/Capsule/Camera/Hold/_hApple");
		meat = GameObject.Find ("/Capsule/Camera/Hold/_hMeat");
		cut = GameObject.Find ("/Capsule/Camera/Hold/_hCut");
		cabbage = GameObject.Find ("/Capsule/Camera/Hold/_hCabbage");
		bread = GameObject.Find ("/Capsule/Camera/Hold/_hBread");
		carrot = GameObject.Find ("/Capsule/Camera/Hold/_hCarrot");
		dish = GameObject.Find ("/Capsule/Camera/Hold/_hDish");
		bowl = GameObject.Find ("/Capsule/Camera/Hold/_hBowl");
		for (int i = 0; i < 5; i++)
			food [i] = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static int getItem() {
		return item;
	}

	public static void setItem(int i) {
		item = i;
	}

	public static bool getHold() {
		return _isHold;
	}

	public static void setHold(bool b) {
		_isHold = b;
	}

	public static bool getDeal() {
		return _deal;
	}

	public static void setDeal(bool d) {
		_deal = d;
	}

	public static void clear() {
		Debug.Log ("Clear");
		apple.SetActive (false);
		cut.SetActive (false);
		bread.SetActive (false);
		meat.SetActive (false);
		dish.SetActive (false);
		cabbage.SetActive (false);
		carrot.SetActive (false);
		bowl.SetActive (false);
		_isHold = false;
		item = -1;
		_deal = false;
		for (int i = 0; i < 5; i++)
			food [i] = false;
		_haveFood = false;
		cook = 0;
		_well = false;
	}
}
