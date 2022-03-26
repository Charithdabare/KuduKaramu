using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

	public GameObject saw;
	public int delay;


	private float time;
	private float maxRight, maxTop, maxBottom;

	void Awake(){
		time = 0f;
		delay = 5;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		SpawnPosition ();
		SpawnObstacle ();
	}


	void SpawnObstacle(){
		time += Time.deltaTime;
		if(GameplayController.instance.easy){
			if(time >= delay){
				time = 0f;
				delay = Random.Range(10, 30);
				Instantiate (saw, new Vector3 (maxRight - 0.9f, Random.Range(maxBottom + 5.777673f, maxTop - 9.773496f), 0), Quaternion.identity);
			}
		}

		if(GameplayController.instance.moderate){
			if(time >= delay){
				time = 0f;
				delay = Random.Range(7, 23);
				Instantiate (saw, new Vector3 (maxRight - 0.9f, Random.Range(maxBottom + 5.777673f, maxTop - 9.773496f), 0), Quaternion.identity);
			}
		}

		if(GameplayController.instance.hard){
			if(time >= delay){
				time = 0f;
				delay = Random.Range(6, 19);
				Instantiate (saw, new Vector3 (maxRight - 0.9f, Random.Range(maxBottom + 5.777673f, maxTop - 9.773496f), 0), Quaternion.identity);
			}
		}

		if(GameplayController.instance.veryHard){
			if(time >= delay){
				time = 0f;
				delay = Random.Range(4, 13);
				Instantiate (saw, new Vector3 (maxRight - 0.9f, Random.Range(maxBottom + 5.777673f, maxTop - 9.773496f), 0), Quaternion.identity);
			}
		}


	}

	void SpawnPosition(){
		Vector3 rightBound = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, Camera.main.transform.position.z));
		Vector3 topBound = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, Camera.main.transform.position.z));
		Vector3 bottomBound = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, Camera.main.transform.position.z));
		maxTop = topBound.y;
		maxBottom = bottomBound.y;
		maxRight = rightBound.x;
	}
}
