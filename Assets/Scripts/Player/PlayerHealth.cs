using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public GameObject blood;
	public Animator animator;

	[HideInInspector]
	public bool hasDied;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayerDied(){
		Instantiate (blood, transform.position, Quaternion.identity);
		if (GameController.instance.isMusicOn) {
			AudioSource.PlayClipAtPoint (MusicController.instance.audioClips [3], Camera.main.transform.position);
		}
		if (!hasDied) {
			hasDied = true;
			GameplayController.instance.gameInProgress = false;
			animator.SetFloat ("jumpSpeed", 0.0f);
			animator.SetBool ("isGrounded", true);
			animator.Play ("Died");
			StartCoroutine (DelayGameOver ());
		}

	}

	IEnumerator DelayGameOver(){
		yield return new WaitForSeconds (1f); 
		GameplayController.instance.GameOver ();
	}
}
