using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	private Rigidbody2D myRigiBody;

	void Awake(){
		myRigiBody = GetComponent<Rigidbody2D> ();
		myRigiBody.velocity = Vector2.left * 10f;
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.CompareTag("Player Health")){
			collider.gameObject.GetComponent<PlayerHealth> ().PlayerDied ();
		}	
	}
}
