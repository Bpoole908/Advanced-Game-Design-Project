using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour {
	[HideInInspector] public GameObject[] getTargets;
	[HideInInspector] public int targetCount;
	// Use this for initialization
	void Start () {
		getTargets = GameObject.FindGameObjectsWithTag ("Target");
		targetCount = getTargets.Length;
		print("Init: " + targetCount);
	}
	
	// Update is called once per frame
	void Update () {

	}

}
