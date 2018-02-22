using UnityEngine;


public class GlobalVars : MonoBehaviour {

	public static GlobalVars Instance { get; set; }

	public bool _enable = true;  // Stops player from firing while paused
	public float time = 120.0f; // Amount of time to complete level

	void Awake(){
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}

}
