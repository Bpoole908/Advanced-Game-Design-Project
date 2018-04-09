using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Timer : MonoBehaviour {
	public float time;
	// Use this for initialization
	void Start () {
		time = 60;
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if (time <= 0) {
			time = 0;
			int scene = SceneManager.GetActiveScene().buildIndex;
			SceneManager.LoadScene(scene, LoadSceneMode.Single);
		}
	}

	void OnGUI(){
		GUIStyle text = new GUIStyle (GUI.skin.box);
		text.fontSize = 50;
			
		GUI.Box(new Rect(20, 20, 100, 70), "" + time.ToString("0"), text);
	}
}
