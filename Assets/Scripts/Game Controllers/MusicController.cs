using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {
	public static MusicController instance;

	public AudioClip[] audioClips;
	public AudioSource audioSource;

	void Awake(){
		CreateInstance ();
		audioSource = GetComponent<AudioSource> ();
	}
		

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Create an instance of the script
	void CreateInstance(){
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	public void PlayBgMusic(){
		AudioClip bgMusic = audioClips [0];

		if(bgMusic){
			if(!audioSource.isPlaying){
				audioSource.clip = bgMusic;
				audioSource.loop = true;
				audioSource.volume = 1f;
				audioSource.Play ();
			}
		}
	}
		
	public void StopBgMusic(){
		if(audioSource.isPlaying){
			audioSource.Stop ();
		}
	}

	public void PlayGameplayMusic(){
		AudioClip bgMusic = audioClips [1];

		if(bgMusic){
			if(!audioSource.isPlaying){
				audioSource.clip = bgMusic;
				audioSource.loop = true;
				audioSource.volume = 1f;
				audioSource.Play ();
			}
		}
	}
}
