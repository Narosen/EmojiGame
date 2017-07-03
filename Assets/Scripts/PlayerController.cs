using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 5f;
	private Rigidbody2D rb;

	public float jumpForce = 0.5f;
	public LayerMask ground;
	public Transform groundCheck;
	public float groundRaduis=0.5f;
	public static bool grounded;
	private bool jump = false;

	private float defaultBounceHeight = 3.0f;

	private float jumpHeight;


	// Use this for initialization
	void Start () {
		
		rb = GetComponent<Rigidbody2D> ();
		jumpHeight = defaultBounceHeight;

	}
	
	void Update(){

		//Debug.DrawRay(new Vector3(transform.position.x,transform.position.y,0.0f),new Vector3(groundRaduis,groundRaduis,0.0f));

	}

	int count = 0;
	void FixedUpdate () {

		float x = Input.GetAxis ("Horizontal");

		//checking if the player is grounded 
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRaduis, ground);
		//if not grounded but wants to jump, a force is added to the ball so that 
		//it can reach the ground fast and the next bounce will be the jump. Like the video
		if (Input.GetButtonDown ("Jump")) {
			count++;
			jump = true;
			jumpHeight = jumpForce;
			if (grounded == false) {
				rb.AddForce (new Vector2 (0.0f, -40f), ForceMode2D.Impulse);
			}

		}
	
		if (grounded) {

			Debug.Log (jumpHeight +" "+ count+" "+grounded);
			rb.velocity = new Vector2 (rb.velocity.x, jumpHeight );

			if (jump == true) {
				jump = false;
				jumpHeight = defaultBounceHeight;
		
			} 
		}


		rb.velocity = new Vector2 (x * speed, rb.velocity.y);
					
	


	}

	//int count =0;

	void OnCollisionEnter2D(Collision2D coll) {

		grounded = false;
		//rb.velocity = new Vector2 (rb.velocity.x, jumpHeight );


		//if (jump == true) {
		//	jump = false;
		//	jumpHeight = defaultBounceHeight;

		//} 

	}

	private void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		//Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
		Gizmos.DrawWireSphere(groundCheck.position,groundRaduis);
	}


}
