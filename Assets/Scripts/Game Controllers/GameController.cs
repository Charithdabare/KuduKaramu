using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameController : MonoBehaviour {
	public static GameController instance;

	public bool isGameStartedFirstTime;
	public bool isMusicOn;
	public float highScore;
	public float currentScore;

	private GameData data;

	void Awake(){
		MakeInstance ();
		InitializeGameVariables ();
	}

	void MakeInstance(){
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	void InitializeGameVariables(){
		Load ();

		if (data != null) {
			isGameStartedFirstTime = data.GetIsGameStartedFirstTime ();
		} else {
			isGameStartedFirstTime = true;
		}

		if (isGameStartedFirstTime) {
			highScore = 0;
			isMusicOn = true;
			isGameStartedFirstTime = false;
			data = new GameData ();

			data.SetIsMusiOn (isMusicOn);
			data.SetHighScore (highScore);

			Save ();

			Load ();

		} else {
			highScore = data.GetHighScore ();
			isMusicOn = data.GetIsMusicOn ();
		}
	}

	public void Save(){
		FileStream file = null;

		try{
			BinaryFormatter bf = new BinaryFormatter();
			file = File.Create(Application.persistentDataPath + "/data.dat");

			if(data != null){
				data.SetIsMusiOn(isMusicOn);
				data.SetHighScore(highScore);
				data.SetIsGameStartedFirstTime(isGameStartedFirstTime);
				bf.Serialize(file, data);
			}

		}catch(Exception e){
			Debug.LogException (e, this);
		}finally{
			if(file != null){
				file.Close ();
			}
		}
	}

	public void Load(){
		FileStream file = null;

		try{
			BinaryFormatter bf = new BinaryFormatter();
			file = File.Open(Application.persistentDataPath + "/data.dat", FileMode.Open);
			data = (GameData)bf.Deserialize(file);

		}catch(Exception e){
			Debug.LogException (e, this);
		}finally{
			if(file != null){
				file.Close ();
			}
		}
	}

}

// Serialize GameData

[Serializable]
class GameData{
	private bool isGameStartedFirstTime;
	private bool isMusicOn;

	private float highScore;

	public void SetIsGameStartedFirstTime(bool isGameStartedFirstTime){
		this.isGameStartedFirstTime = isGameStartedFirstTime;
	} 

	public bool GetIsGameStartedFirstTime(){
		return this.isGameStartedFirstTime;
	}

	public void SetIsMusiOn(bool isMusicOn){
		this.isMusicOn = isMusicOn;
	}

	public bool GetIsMusicOn(){
		return this.isMusicOn;
	}

	public void SetHighScore(float highScore){
		this.highScore = highScore;
	}

	public float GetHighScore(){
		return this.highScore;
	}
}
	
