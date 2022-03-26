using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {
	public static GameplayController instance;

	public Text distanceText;
	public float distanceMultiplier;
	public bool gameInProgress, gameInPause;
	public GameObject pausePanel, gameOverPanel;
	public Text scoreText, highScoreText;
	public bool easy, moderate, hard, veryHard;

	private float distance = 0;

	void Awake(){
		CreateInstance ();
		gameInProgress = true;
		GameDifficulties ();
	}


	void GameDifficulties(){
		easy = true;
		moderate = false;
		hard = false;
		veryHard = false;
	}

	void CreateInstance(){
		if(this != null){
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		if (GameController.instance.isMusicOn) {
			if (MusicController.instance.audioSource.isPlaying) {
				MusicController.instance.StopBgMusic ();
			}
			MusicController.instance.PlayGameplayMusic ();
		} else {
			MusicController.instance.StopBgMusic ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		UpdateGameplay ();
	}


	void UpdateGameplay(){
		if(gameInProgress){
			distance += distanceMultiplier * Time.deltaTime;
			distanceText.text = distance.ToString("0000") + " M";
			GameController.instance.currentScore = Mathf.Round(distance);
			Difficulty ();
		}
	}


	public void PauseGame(){
		if(gameInProgress){
			if(!gameInPause){
				Time.timeScale = 0;
				pausePanel.SetActive (true);
				gameInPause = true;
				gameInProgress = false;
			}
		}
	}

	public void ContinueGame(){
		if(!gameInProgress){
			if(gameInPause){
				Time.timeScale = 1;
				pausePanel.SetActive (false);
				gameInPause = false;
				gameInProgress = true;
			}
		}
	}

	public void ExitGame(){
		Time.timeScale = 1;
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex - 1);
		if (GameController.instance.isMusicOn) {
			if (MusicController.instance.audioSource.isPlaying) {
				MusicController.instance.StopBgMusic ();
				MusicController.instance.PlayBgMusic ();
			}
		}
	}

	public void RestartGame(){
		Time.timeScale = 1;
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

	public void GameOver(){
		gameOverPanel.SetActive(true);
		scoreText.text = GameController.instance.currentScore + " M";
		if(GameController.instance.currentScore >= GameController.instance.highScore){
			GameController.instance.highScore = GameController.instance.currentScore;
			GameController.instance.Save ();
			highScoreText.gameObject.SetActive (true);
		}
	}

	void Difficulty(){

		// MODERATE
		if(GameController.instance.currentScore <= 1000 && GameController.instance.currentScore >= 1000){
			easy = false;
			moderate = true;
			hard = false;
			veryHard = false;
		}

		//HARD
		if(GameController.instance.currentScore <= 2500 && GameController.instance.currentScore >= 2500){
			easy = false;
			moderate = false;
			hard = true;
			veryHard = false;
		}

		//VERY HARD
		if(GameController.instance.currentScore <= 5000 && GameController.instance.currentScore >= 5000){
			easy = false;
			moderate = false;
			hard = false;
			veryHard = true;
		}

	}

}
