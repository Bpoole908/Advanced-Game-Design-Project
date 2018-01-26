using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_MouseLook : MonoBehaviour {
	Vector2 mouseLook; // tracks total mouse movement
	Vector2 smoothV; // smooths movement of mouse
	Transform cam_trans;
	public float sensitivity = 5.0f;
	public float smoothing = 2.0f;
	public float viewRange = 50.0f;
	GameObject character;
	// Use this for initialization
	void Start () {
		character = this.transform.parent.gameObject; // character init
		cam_trans = this.transform;
	}
	
	// Update is called once per frame
	void Update () {

		var mouse_delta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")); // change in mouse
		mouse_delta = Vector2.Scale (mouse_delta, new Vector2 (sensitivity * smoothing, sensitivity * smoothing));
		smoothV.x = Mathf.Lerp (smoothV.x, mouse_delta.x, 1f / smoothing);
		smoothV.y = Mathf.Lerp (smoothV.y, mouse_delta.y, 1f / smoothing);
		mouseLook += smoothV; 

		cam_trans.localRotation = Quaternion.AngleAxis (-mouseLook.y, Vector3.right); // rotation around x axis
		cam_trans.localEulerAngles = new Vector3 (Mathf.Clamp (cam_trans.localEulerAngles.x, -viewRange, viewRange), 0, 0);
		print (cam_trans.localEulerAngles.x);
		if (cam_trans.localEulerAngles.x > viewRange) {
			cam_trans.localEulerAngles = new Vector3 (viewRange, 0, 0);
		} else if (cam_trans.localEulerAngles.x < -viewRange) {
			cam_trans.localEulerAngles = new Vector3 (-viewRange, 0, 0);
		}




		character.transform.localRotation = Quaternion.AngleAxis (mouseLook.x, character.transform.up);
	}

}
