using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public static PlayerController instance;

	public float speed;
	public float jumpPower;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public GameObject projectile;
	public Slider energyLevel;
	public Text energyText;
	public float energyCharger;
	private bool moveLeft, moveRight; 

	private float energy;
	private float maxEnergy = 100f; 
	private Rigidbody2D myRigidBody;
	private bool grounded;
	private Animator animator;
	private float maxLeft, maxRight;
	private Vector3 pos;
	private float time = 0f;

	void Awake(){
		energy = maxEnergy;
		energyLevel.value = energy;
		energyText.text = energy + "%";
		myRigidBody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		PlayerPosition ();
		MakeInstance ();
	}

	void MakeInstance(){
		if(this != null){
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		
	}




	// Update is called once per frame
	void Update(){
		if(!transform.GetChild(0).gameObject.GetComponent<PlayerHealth>().hasDied){
			EnergyCharging ();
		}
	}

	public void JumpButton(){
		if(!transform.GetChild(0).gameObject.GetComponent<PlayerHealth>().hasDied){
			if (grounded) {
				grounded = false;
				myRigidBody.AddForce (new Vector2 (0, jumpPower), ForceMode2D.Impulse);
				if(myRigidBody.velocity.y > jumpPower){
					myRigidBody.velocity = new Vector2 (0, jumpPower);
				}
				animator.SetBool ("isGrounded", grounded);
			}
		}
	}

	void FixedUpdate () {
		if (!transform.GetChild(0).gameObject.GetComponent<PlayerHealth>().hasDied) {
			LimitBoundary ();
			if (Application.platform == RuntimePlatform.Android) {
				MoveThePlayer ();
			} else {
				PlayerKeyboardMovement ();
				MoveThePlayer ();
			}
				
		}
	}

	void PlayerPosition(){
		Vector3 leftBound = Camera.main.ViewportToWorldPoint (new Vector3 (1f, 0f, Camera.main.transform.position.z));
		Vector3 temp;
		maxLeft = leftBound.x;
		temp = transform.position;
		temp = new Vector3 (maxLeft + 1.5f, -2f, transform.position.z);
		transform.position = temp;
	}

	void PlayerKeyboardMovement(){
		float movement = Input.GetAxis ("Horizontal");
		grounded = Physics2D.OverlapCircle (groundCheck.position, 0.3f, groundLayer);

		animator.SetBool ("isGrounded", grounded);
		animator.SetFloat ("jumpSpeed", myRigidBody.velocity.y);
		myRigidBody.velocity = new Vector2 (movement * speed, myRigidBody.velocity.y);

	}

	void MoveThePlayer(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, 0.3f, groundLayer);
		animator.SetBool ("isGrounded", grounded);
		animator.SetFloat ("jumpSpeed", myRigidBody.velocity.y);


		if (moveRight) {
			MoveRight ();
		}

		if(moveLeft){
			MoveLeft ();
		}

	}
		
	public void MovePlayerLeft(){
		moveLeft = true;
		moveRight = false;
	}

	public void MovePlayerRight(){
		moveRight = true;
		moveLeft = false;
	}


	void MoveLeft(){
		myRigidBody.velocity = new Vector2(-speed, myRigidBody.velocity.y);
	}

	void MoveRight(){
		myRigidBody.velocity = new Vector2(speed, myRigidBody.velocity.y);
	}



	public void StopMoving(){
		moveLeft = moveRight = false;

		myRigidBody.velocity = new Vector2(0f, myRigidBody.velocity.y);
	} 

	void LimitBoundary(){
		Vector3 leftBoundary = Camera.main.ViewportToWorldPoint (new Vector3 (1f, 0f, Camera.main.transform.position.z));
		Vector3 rightBoundary = Camera.main.ViewportToWorldPoint (new Vector3 (0f, 0f, Camera.main.transform.position.z));
		maxLeft = leftBoundary.x;
		maxRight = rightBoundary.x;

		pos = transform.position;
		pos.x = Mathf.Clamp (pos.x, maxLeft + 1.5f, maxRight - 1.5f);
		transform.position = pos;
	}


	public void PlayerShoot(){
		if (!transform.GetChild(0).gameObject.GetComponent<PlayerHealth>().hasDied) {
			if (energy >= 5f) {
				energy -= 5f;
				energyLevel.value = (int)energy;
				energyText.text = (int)energy + "%";

				GameObject newProjectile = Instantiate (projectile, new Vector3 (transform.position.x + 1.5f, transform.position.y - 0.02f, transform.position.z), Quaternion.identity) as GameObject;
				if (GameController.instance.isMusicOn) {
					AudioSource.PlayClipAtPoint (MusicController.instance.audioClips [2], newProjectile.transform.position);
				}
			}
		}
	}

	void EnergyCharging(){
		if(energyLevel.value <= 100f && energyLevel.value != 100f){
			energy += energyCharger * Time.deltaTime; 
			energyLevel.value = (int)energy;
			energyText.text = (int)energy + "%";
		}
	}

	public void AddBattery(int powerup){
		energy += powerup;
		if(energy >= 100f){
			energy = 100f;
		}
	}








}
