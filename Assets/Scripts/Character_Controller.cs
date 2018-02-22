﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour {
	public float speed = 10.0F;
	public float jumpVelocity = 550.0f;
	public float maxSlope = 60;
	private bool grounded = false;
	Rigidbody rb;

	void Start () {
		//Turns off cursor on screen and locks inside game window
		Cursor.lockState = CursorLockMode.Locked;
		rb = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		// Movement
		float translation = Input.GetAxis ("Vertical") * speed;
		float straffe = Input.GetAxis ("Horizontal") * speed;
		translation *= Time.deltaTime;
		straffe *= Time.deltaTime;
		transform.Translate (straffe, 0, translation);

		if (Input.GetButtonDown ("Jump") && grounded) {
			rb.AddForce (0, jumpVelocity, 0);
		}

	}
	 //Detect if you on the ground to jump
	 void OnCollisionStay (Collision collision){
		foreach (ContactPoint contact in collision.contacts){

			if (Vector3.Angle(contact.normal, Vector3.up) < maxSlope){
				print ("Can Jump");
				grounded = true;
			}
		}
	}

	void OnCollisionExit (Collision collision){
		print("Can't Jump");
		grounded = false;
	}
}
