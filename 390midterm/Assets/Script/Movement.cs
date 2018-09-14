using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	Vector2 mouseLook;
	Vector2 smoothV;
	public float sensitivity = 0.5f;
	public float smoothing = 0.2f;
	GameObject character;


	// Use this for initialization
	void Start () {
		character = this.transform.parent.gameObject;
	}

	// Update is called once per frame
	void Update () {
		var md = new Vector2 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"));

		md = Vector2.Scale (md, new Vector2 (1.0f, 1.0f));
		smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1.0f / smoothing);
		smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1.0f / smoothing);
		mouseLook += smoothV;

		transform.localRotation = Quaternion.AngleAxis (-mouseLook.y, Vector3.right);
		character.transform.localRotation = 
			Quaternion.AngleAxis (mouseLook.x, character.transform.up);

	}
}