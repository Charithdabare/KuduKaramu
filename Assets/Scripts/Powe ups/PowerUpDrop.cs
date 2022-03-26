using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDrop : MonoBehaviour {

	public GameObject battery;

	private float time, maxLeft, maxRight, maxTop;
	private int delay;

	void Awake(){
		time = 0f;
		delay = Random.Range (10, 25);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		SpawnerPosition ();
		SpawnBattery ();
	}


	void SpawnBattery(){
		time += Time.deltaTime;
		if(time >= delay){
			time = 0f;
			Instantiate (battery, new Vector3 (Random.Range (maxLeft + 0.9f, maxRight - 0.9f), maxTop + 1.5f, 0), Quaternion.identity);
		}
	}

	void SpawnerPosition(){
		Vector3 leftBound = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, Camera.main.transform.position.z));
		Vector3 rightBound = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, Camera.main.transform.position.z));
		Vector3 topBound = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, Camera.main.transform.position.z));

		maxTop = topBound.y;
		maxLeft = leftBound.x;
		maxRight = rightBound.x;
	}

}
