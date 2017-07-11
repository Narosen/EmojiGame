using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 5f;
	private Rigidbody2D rb;

	public float jumpForce = 0.5f;
	public LayerMask ground;
	public LayerMask movPlatform;
	public Transform groundCheck;
	public float groundRaduis=0.5f;
	public static bool grounded;
	private bool jump = false;

	private float defaultBounceHeight = 4.0f;

	private float jumpHeight;

	public static bool movingPlatform = false;


	// Use this for initialization
	void Start () {
		
		rb = GetComponent<Rigidbody2D> ();
		jumpHeight = defaultBounceHeight;

	}

	float x;
	void Update(){

		//the input function should always be in Update function, otherwose it will be missed sometimes
		x = Input.GetAxis ("Horizontal");

		if (Input.GetButtonDown ("Jump")) {
			jump = true;
			jumpHeight = jumpForce;
		}

	}

	void FixedUpdate () {

		//checking if the player is grounded 
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRaduis, ground);
		movingPlatform = Physics2D.OverlapCircle (groundCheck.position, groundRaduis, movPlatform);

		//if not grounded but wants to jump, a force is added to the ball so that 
		//it can reach the ground fast and the next bounce will be the jump. Like the video
		if (jump == true) {
			if (grounded == false) {
				rb.AddForce (new Vector2 (0.0f, -15f), ForceMode2D.Impulse);
			}
		}
	
		if (grounded) {

			//the player should not bounce on moving platform
			if (movingPlatform == false || jump == true) {
				rb.velocity = new Vector2 (rb.velocity.x, jumpHeight );
				jump = false;
				jumpHeight = defaultBounceHeight;
			}

		}


		rb.velocity = new Vector2 (x * speed, rb.velocity.y);
					
	


	}

	void OnCollisionEnter2D(Collision2D coll) {

		grounded = false;


	}

	private void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		//Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
		Gizmos.DrawWireSphere(groundCheck.position,groundRaduis);
	}


}
