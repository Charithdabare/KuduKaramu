using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public int maxHealth;
	public float speed;
	public GameObject explosion;
	public GameObject bullet;
	public GameObject powerUp;

	private float dropRate = 0.5f;
	private float time;
	private int delay;
	private int health;
	private Rigidbody2D myRigidBody;

	void Awake(){
		health = maxHealth;
		myRigidBody = GetComponent<Rigidbody2D> ();
		time = 0f;
		delay = Random.Range (3, 5);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		myRigidBody.velocity = Vector2.left * speed;
		EnemyShoot ();
	}

	public void Health(int damage){
		if (health > 0) {
			health -= damage;
		}

		if(health == 0){
			Destroy (gameObject);
			Instantiate (explosion, transform.position, Quaternion.identity);
			if(Random.Range(0.0f, 1.0f) <= dropRate){
				Instantiate (powerUp, transform.position, Quaternion.identity);
			}	
			if (GameController.instance.isMusicOn) {
				AudioSource.PlayClipAtPoint (MusicController.instance.audioClips [4], transform.position);
			}
		}

	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.CompareTag ("Player Health")) {
			collider.GetComponent<PlayerHealth> ().PlayerDied ();
		}
	}

	void EnemyShoot(){
		switch(gameObject.name){
		case"Enemy(Clone)":
			time += Time.deltaTime;
			if(time >= delay){
				time = 0;
				delay = Random.Range (3, 5);
				Instantiate (bullet, new Vector3 (transform.position.x - 2f, transform.position.y - 0.2f, transform.position.z), Quaternion.identity);
			}
			break;

		case"Tank(Clone)":
			time += Time.deltaTime;
			if(time >= delay){
				time = 0;
				delay = Random.Range (3, 5);
				Instantiate (bullet, new Vector3 (transform.position.x - 2.5f, transform.position.y + 0.8f, transform.position.z), Quaternion.identity);
			}
			break;
		}
	}
}
