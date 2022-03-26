using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

	public GameObject settingPanel, exitPanel, howToPlayPanel;
	public Toggle toggleMusic;
	public Text highScoreText;
	public GameObject[] tutorial;

	private int count = 0;

	void Update(){
		if(Input.GetKey(KeyCode.Escape)){
			exitPanel.SetActive (true);
			if(settingPanel.activeInHierarchy){
				settingPanel.SetActive (false);
				howToPlayPanel.SetActive (false);
			}
		}
	}

	// Use this for initialization
	void Start () {
		if (GameController.instance.isMusicOn) {
			MusicController.instance.PlayBgMusic ();
			toggleMusic.isOn = true;
		} else {
			MusicController.instance.StopBgMusic ();
			toggleMusic.isOn = false;
		}
		InitializeMainMenuVariables ();
	}

	void InitializeMainMenuVariables(){
		highScoreText.text = GameController.instance.highScore.ToString("N0") + " M";
	}

	public void PlayButton(){
		SceneManager.LoadScene ("Gameplay");
	}

	public void SettingButton(){
		settingPanel.SetActive (true);
	}

	public void CloseSettingButton(){
		settingPanel.SetActive (false);
	}

	public void MusicToggle(){
		if(toggleMusic.isOn){
			GameController.instance.isMusicOn = true;
			MusicController.instance.PlayBgMusic();
			GameController.instance.Save ();
		}else{
			GameController.instance.isMusicOn = false;
			MusicController.instance.StopBgMusic();
			GameController.instance.Save ();
		}
	}

	public void YesButton(){
		Application.Quit ();
	}

	public void NoButton(){
		exitPanel.SetActive (false);
	}

	public void HowToPlay(){
		howToPlayPanel.SetActive (true);
	}

	public void CloseHowToPlay(){
		howToPlayPanel.SetActive (false);
	}

	public void NextButton(){
		count++;
		if(count == tutorial.Length){
			count = 0;
		}
		for (int i = 0; i < tutorial.Length; i++) {
			if (count == i) {
				tutorial [i].SetActive (true);
			} else {
				tutorial [i].SetActive (false);
			}
		}
	}

	public void PrevButton(){
		count--;
		if(count <= 0 - 1){
			count = tutorial.Length - 1;
		}

		for (int i = 0; i < tutorial.Length; i++) {
			if (count == i) {
				tutorial [i].SetActive (true);
			} else {
				tutorial [i].SetActive (false);
			}
		}
	}
}
