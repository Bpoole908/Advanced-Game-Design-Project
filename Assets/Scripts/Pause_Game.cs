using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
		if (canvas) {
			if (canvas.gameObject.activeInHierarchy == false) {
				canvas.gameObject.SetActive (true);
				PauseSingle.Instance._enable = false;
				Time.timeScale = 0;
				Cursor.lockState = CursorLockMode.None;
			} else {
				canvas.gameObject.SetActive (false);
				PauseSingle.Instance._enable = true;
				Cursor.lockState = CursorLockMode.Locked;
				Time.timeScale = 1;
			}
		}
	}

	public void Restart(){
		canvas.gameObject.SetActive (false);
		PauseSingle.Instance._enable = true;
		Cursor.lockState = CursorLockMode.Locked;
		Time.timeScale = 1;
		Application.LoadLevel(Application.loadedLevel);
	}

	public void MainMenu(){
		canvas.gameObject.SetActive (false);
		PauseSingle.Instance._enable = true;
		Cursor.lockState = CursorLockMode.None;
		Time.timeScale = 1;
		SceneManager.LoadScene(0, LoadSceneMode.Single);
	}
}
