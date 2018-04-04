using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Character_Controller : MonoBehaviour {
	[HideInInspector] public GameObject controller;
	[HideInInspector] public GlobalVars target;
	public float speed = 10.0F;
	public float jumpVelocity = 550.0f;
	public float maxSlope = 60;
	private bool grounded = false;
	Rigidbody rb;

	void Start () {
		//Turns off cursor on screen and locks inside game window
		Cursor.lockState = CursorLockMode.Locked;
		rb = gameObject.GetComponent<Rigidbody> ();
		controller = GameObject.Find ("GameController");
		target = controller.GetComponent<GlobalVars> ();
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
	// Death
	void OnCollisionEnter(Collision collision){
		if (collision.transform.tag == "Restart") {
			int scene = SceneManager.GetActiveScene().buildIndex;
			SceneManager.LoadScene(scene, LoadSceneMode.Single);
		}

		// Finish Level
		// CHANGE to scene 2 or main menue
		if (collision.transform.tag == "Finish" && target.targetCount == 1) {
			StartCoroutine (ExecuteAfterTime (1));
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

	IEnumerator ExecuteAfterTime(float time){
		yield return new WaitForSeconds (time);
		int scene = SceneManager.GetActiveScene ().buildIndex;
		print (scene);
		if (scene < 1) {
			scene += 1;
		} else {
			//return to main menu
		}
		SceneManager.LoadScene(scene, LoadSceneMode.Single);
	}

}
