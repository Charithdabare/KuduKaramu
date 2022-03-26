using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public int damage;

	private Rigidbody2D myRigidBody;

	void Awake(){
		myRigidBody = GetComponent<Rigidbody2D> ();
		myRigidBody.AddForce (new Vector2 (15f, myRigidBody.velocity.y), ForceMode2D.Impulse);
	}


	void OnTriggerEnter2D(Collider2D collider){
		if(collider.CompareTag("Enemy")){
			collider.GetComponent<EnemyController> ().Health (damage);
			Destroy (gameObject);
		}
	}
}
