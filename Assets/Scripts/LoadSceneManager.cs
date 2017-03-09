using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour {

	public string levelName = "";

	public void Play()
	{
		SceneManager.LoadScene (levelName);
	}
}
