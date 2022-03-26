using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackgrounds : MonoBehaviour {

	public float cloudSpeed, treeSpeed, houseSpeed, buildingSpeed;

	private Rigidbody2D myRigidBody;

	void Awake(){
		myRigidBody = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
	}


	void Movement(){
		switch(gameObject.name){
		case "Tree(Clone)":
			myRigidBody.velocity = Vector2.left * treeSpeed;
			break;

		case "Houses(Clone)":
			myRigidBody.velocity = Vector2.left * houseSpeed;
			break;

		case "Building(Clone)":
			myRigidBody.velocity = Vector2.left * buildingSpeed;
			break;

		case "Background(Clone)":
			myRigidBody.velocity = Vector2.left * cloudSpeed;
			break;
		}
	}
}
