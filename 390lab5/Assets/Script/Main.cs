using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

	public GameObject star;
	public GameObject star1;
	public GameObject star2;
	public GameObject star3;
	public GameObject star4;
	public Material skybox1;
	public Material skybox2;
	public Material skybox3;
	private float waitTime = 10.0f;
	private float waitTime1 = 15.0f;
	private float waitTime2 = 20.0f;
	private float waitTime3 = 25.0f;
	private float waitTime4 = 30.0f;
	private float startTime = 0.0f;
	private float startTime1 = 0.0f;
	private float startTime2 = 0.0f;
	private float startTime3 = 0.0f;
	private float startTime4 = 0.0f;
	private Vector3 stp;
	private Vector3 stp1;
	private Vector3 stp2;
	private Vector3 stp3;
	private Vector3 stp4;

	// Use this for initialization
	void Start () {
		stp = new Vector3(star.transform.position.x, 
						star.transform.position.y, 
						star.transform.position.z);
		stp1 = new Vector3(star.transform.position.x, 
			star1.transform.position.y, 
			star1.transform.position.z);
		stp2 = new Vector3(star.transform.position.x, 
			star2.transform.position.y, 
			star2.transform.position.z);
		stp3 = new Vector3(star.transform.position.x, 
			star3.transform.position.y, 
			star3.transform.position.z);
		stp4 = new Vector3(star.transform.position.x, 
			star4.transform.position.y, 
			star4.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - startTime >= waitTime) {
			star.transform.position = stp;
			startTime = Time.time;
		}
		if (Time.time - startTime1 >= waitTime1) {
			star1.transform.position = stp1;
			startTime1 = Time.time;
		}
		if (Time.time - startTime2 >= waitTime2) {
			star2.transform.position = stp2;
			startTime2 = Time.time;
		}
		if (Time.time - startTime3 >= waitTime3) {
			star3.transform.position = stp3;
			startTime3 = Time.time;
		}
		if (Time.time - startTime4 >= waitTime4) {
			star4.transform.position = stp4;
			startTime4 = Time.time;
		}
		if (Input.GetKeyDown ("1"))
			RenderSettings.skybox = skybox1;
		if (Input.GetKeyDown("2"))
			RenderSettings.skybox = skybox2;
		if (Input.GetKeyDown("3"))
			RenderSettings.skybox = skybox3;
		star.transform.position = star.transform.position + new Vector3 (5, -5, -5);
		star1.transform.position = star1.transform.position + new Vector3 (5, -5, -5);
		star2.transform.position = star2.transform.position + new Vector3 (5, -5, -5);
		star3.transform.position = star3.transform.position + new Vector3 (5, -5, -5);
		star4.transform.position = star4.transform.position + new Vector3 (5, -5, -5);
	}
}
