using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayLevelOne()
	{
		SceneManager.LoadScene ("Level_One");
	}

	public void PlayLevelTwo()
	{
		SceneManager.LoadScene ("Level_Two");
	}

	public void QuitGame()
	{
		Debug.Log ("QUIT!");
		Application.Quit ();
	}
}
