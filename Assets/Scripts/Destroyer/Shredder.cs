using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.CompareTag("Enemy") || collider.CompareTag("Obstacle")){
			Destroy (collider.gameObject);
		}
	}
}
