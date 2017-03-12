using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep_Sounds : MonoBehaviour {

	public AudioClip jump_sound;
	public AudioClip death_sound;

	private AudioSource my_audio;

	// Use this for initialization
	void Start () 
	{
		my_audio = GetComponent<AudioSource> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayJump()
	{
		my_audio.clip = jump_sound;
		my_audio.Play ();
	}

	public void PlayDeath()
	{
		my_audio.clip = death_sound;
		my_audio.Play ();
	}
}
