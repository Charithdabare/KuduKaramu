using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	private Rigidbody2D myRigidBody;


	void Awake(){
		myRigidBody = GetComponent<Rigidbody2D> ();
		myRigidBody.velocity = Vector2.left * 10f;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.CompareTag("Player Health")){
			collider.GetComponent<PlayerHealth> ().PlayerDied ();
		}
	}
}
