using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


	public static GameManager instance;

	[HideInInspector]
	public GameObject endGamePanel;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	public void EndGame()
	{
		CheckHighScore ();
		endGamePanel.SetActive (true);
	}

	public void CheckHighScore()
	{
		int gameScore = GameObject.Find ("Score Text").GetComponent<ScoreManager> ().score;

		if (gameScore > PlayerPrefs.GetInt ("HighScore", 0)) 
		{
			PlayerPrefs.SetInt ("HighScore", gameScore);
		}
	}

	public void ReloadLevel()
	{
		SceneManager.LoadScene ("Game");
	}
}
