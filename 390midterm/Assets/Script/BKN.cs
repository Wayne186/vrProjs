using UnityEngine;
using System.Collections;
using System;

	/// <summary>
	/// This script modifies an Object's transform to move it around the scene.
	/// </summary>
	public class BKN : MonoBehaviour {

		public float horizontalModifier = 0.1f;
		public float verticalModifier = 0.1f;
		public float inOutModifier = 0.1f;
		public float rotateModifier = 0.1f;
		private Transform objTransform;       //The object's transform, so we can move the object around
		// Use this for initialization
		void Start() {
			//set objTransform equal to the object's transform
			objTransform = this.transform;
			if (objTransform == null) {
				Debug.LogError("BasicKeyboardNavigation::Object does not contain a transform");
			}
			if (horizontalModifier == 0) {
				Debug.LogWarning("BasicKeyboardNavigation::Horizontal Modifier is 0");
			}
			if (verticalModifier == 0) {
				Debug.LogWarning("BasicKeyboardNavigation::Vertical Modifier is 0");
			}
			if (inOutModifier == 0) {
				Debug.LogWarning("BasicKeyboardNavigation::In Out Modifier is 0");
			}
		}

		// Update is called once per frame
		void Update() {
			if (objTransform != null) {
				//W & S is up/down 
				//A & D is left/right
				//Shift & Control is forward backward
				//Q & E are rotate left/right; rotates along the Y-axis
				Vector3 addedPosition = new Vector3(0, 0, 0);       //if Input is down, add to value
				Vector3 addedRotation = new Vector3(0, 0, 0);       //same as addedPosition
				if (Input.GetKey(KeyCode.W)) {
					addedPosition.z = addedPosition.z + verticalModifier;
				}
				if (Input.GetKey(KeyCode.S)) {
					addedPosition.z = addedPosition.z - verticalModifier;
				}
				if (Input.GetKey(KeyCode.A)) {
					addedPosition.x = addedPosition.x - horizontalModifier;
				}
				if (Input.GetKey(KeyCode.D)) {
					addedPosition.x = addedPosition.x + horizontalModifier;
				}
				objTransform.Translate(addedPosition);
				objTransform.Rotate(addedRotation);
			}
		}
	}