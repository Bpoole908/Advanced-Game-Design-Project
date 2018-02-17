using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour {
	public float speed = 10.0F;
	public float jumpVelocity = 550.0f;
	public float maxSlope = 60;
	private bool disable = false;
	private bool grounded = false;
	Rigidbody rb;

	void Start () {
		//Turns off cursor on screen and locks inside game window
		Cursor.lockState = CursorLockMode.Locked;
		rb = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		// If esacpe is pressed disable controlls and unlock cursor
		if (Input.GetKeyDown ("escape")) {
			Cursor.lockState = CursorLockMode.None;
			disable = true;
		}
		// If left mouse and cursor is on screen resume controls and lock cursor
		if (Cursor.visible == true && Input.GetKeyDown (KeyCode.Mouse0)) {
			Cursor.lockState = CursorLockMode.Locked;
			disable = false;
		}

		// Movement
		float translation = Input.GetAxis ("Vertical") * speed;
		float straffe = Input.GetAxis ("Horizontal") * speed;
		if (!disable) {
			translation *= Time.deltaTime;
			straffe *= Time.deltaTime;
			transform.Translate (straffe, 0, translation);
		}
		if (Input.GetButtonDown ("Jump") && grounded && !disable) {
			rb.AddForce (0, jumpVelocity, 0);
		}

	}
	 //Detect if you on the ground to jump
	 void OnCollisionStay (Collision collision){
		foreach (ContactPoint contact in collision.contacts){

			if (Vector3.Angle(contact.normal, Vector3.up) < maxSlope){
				grounded = true;
			}
		}
	}

	void OnCollisionExit (Collision collision){
		grounded = false;
	}
}
