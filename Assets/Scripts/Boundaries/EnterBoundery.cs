using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBoundery : MonoBehaviour {

	public GameObject platforms;
	public GameObject tree, house, cloud, building;

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.CompareTag("Platform")){
			Instantiate (platforms, new Vector3 (collider.transform.position.x + 37.41f, collider.transform.position.y, collider.transform.position.z), Quaternion.identity);
		}

		if(collider.CompareTag("Background")){
			switch(collider.gameObject.name){
			case "Tree(Clone)":
				Instantiate (tree, new Vector3 (collider.transform.position.x + 45f, collider.transform.position.y, collider.transform.position.z), Quaternion.identity);
				break;

			case "Houses(Clone)":
				Instantiate (house, new Vector3 (collider.transform.position.x + 94f, collider.transform.position.y, collider.transform.position.z), Quaternion.identity);
				break;

			case "Building(Clone)":
				Instantiate (building, new Vector3 (collider.transform.position.x + 37f, collider.transform.position.y, collider.transform.position.z), Quaternion.identity);
				break;

			case "Background(Clone)":
				Instantiate (cloud, new Vector3 (collider.transform.position.x + 374.1f, collider.transform.position.y, collider.transform.position.z), Quaternion.identity);
				break;
			}
		}

		if(collider.CompareTag("Player Projectile")){
			Destroy (collider.gameObject);
		}
	}
}
