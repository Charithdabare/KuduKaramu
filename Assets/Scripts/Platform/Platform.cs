using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	public float speed;

	private Rigidbody2D rigidBody;


	void Awake(){
		rigidBody = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
			
	}

	void Movement(){
		rigidBody.velocity = Vector2.left * speed;
	}
}
