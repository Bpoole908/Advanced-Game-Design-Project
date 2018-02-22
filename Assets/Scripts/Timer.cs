using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
	private float time;
	// Use this for initialization
	void Start () {
		time = GlobalVars.Instance.time;
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if (time <= 0) {
			time = 0;
		}
	}

	void OnGUI(){
		GUI.Box(new Rect(10, 10, 50, 20), "" + time.ToString("0"));
	}
}
