using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Game : MonoBehaviour {
	public Transform canvas;
	public Transform player;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			Pause ();
		}
	}

	public void Pause() {
		if (canvas.gameObject.activeInHierarchy == false) {
			canvas.gameObject.SetActive (true);
			GlobalVars.Instance._enable = false;
			Time.timeScale = 0;
			Cursor.lockState = CursorLockMode.None;
		} else {
			canvas.gameObject.SetActive (false);
			GlobalVars.Instance._enable = true;
			Cursor.lockState = CursorLockMode.Locked;
			Time.timeScale = 1;
		}
	}
}
