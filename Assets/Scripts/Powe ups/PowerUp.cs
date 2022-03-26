using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

	private Rigidbody2D myRigidBody;

	void Awake(){
		myRigidBody = GetComponent<Rigidbody2D> ();
		Destroy (gameObject, 5f);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D collider){
		if(collider.CompareTag("Platform")){
			Vector3 temp = collider.transform.position;
			temp.y = -4.9f;
			transform.position = new Vector2 (transform.position.x, temp.y);
			myRigidBody.isKinematic = true;
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.CompareTag("Player Health")){
			Destroy (gameObject);
			collider.transform.parent.gameObject.GetComponent<PlayerController>().AddBattery(25);
		}
	}
}
