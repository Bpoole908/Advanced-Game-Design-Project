using UnityEngine;


public class GlobalVars : MonoBehaviour {

	public static GlobalVars Instance { get; set; }

	public bool _enable = true;

	void Awake(){
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}

}
