using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScore : MonoBehaviour {

	public enum ScoreType {Game, HighScore}

	public ScoreType myType;

	int myScore;

	private Text myText;

	// Use this for initialization
	void Start () {

		myText = GetComponent<Text> ();

		switch (myType) 
		{
		case ScoreType.Game:
			myScore = GameObject.Find ("Score Text").GetComponent<ScoreManager> ().score;
			myText.text = "SCORE: " + myScore.ToString ();
			break;
		case ScoreType.HighScore:
			myScore = PlayerPrefs.GetInt ("HighScore", 0);
			myText.text = "BEST SCORE: " + myScore.ToString();
			break;
		}


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
