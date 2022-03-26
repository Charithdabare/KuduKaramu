using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] enemies;
	public int delay;

	private float time;
	private float maxRight;


	void Awake(){
		time = 0f;
		delay = 1;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		SpawnPosition ();
		SpawnEnemies ();
	}


	void SpawnEnemies(){
		time += Time.deltaTime;

		if (GameplayController.instance.easy) {
			if (time >= delay) {
				time = 0;
				delay = Random.Range (3, 10);
				Instantiate (enemies [Random.Range (0, 2)], new Vector3 (maxRight - 1f, -4f, 0f), Quaternion.identity);
			}
		}

		if (GameplayController.instance.moderate) {
			if (time >= delay) {
				time = 0;
				delay = Random.Range (3, 8);
				Instantiate (enemies [Random.Range (0, 2)], new Vector3 (maxRight - 1f, -4f, 0f), Quaternion.identity);
			}
		}

		if (GameplayController.instance.hard) {
			if (time >= delay) {
				time = 0;
				delay = Random.Range (3, 6);
				Instantiate (enemies [Random.Range (0, 2)], new Vector3 (maxRight - 1f, -4f, 0f), Quaternion.identity);
			}
		}

		if (GameplayController.instance.veryHard) {
			if (time >= delay) {
				time = 0;
				delay = Random.Range (2, 5);
				Instantiate (enemies [Random.Range (0, 2)], new Vector3 (maxRight - 1f, -4f, 0f), Quaternion.identity);
			}
		}

	}

	void SpawnPosition(){
		Vector3 rightBound = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, Camera.main.transform.position.z));
		maxRight = rightBound.x;
	}
}
