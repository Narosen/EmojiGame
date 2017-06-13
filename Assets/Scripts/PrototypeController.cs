using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeController : MonoBehaviour {

	public float speed = 5f;
	public float jumpForce = 0.5f;
	public Transform groundCheck;
	public float groundRadius = 0.2f;

	private Rigidbody2D rb;
	public static bool grounded = true;
	public LayerMask groundMask;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate(){
		
		float moveX = Input.GetAxis ("Horizontal");
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius ,groundMask);

		if (grounded && Input.GetButtonDown ("Jump")) {
			rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
		}

		rb.velocity = new Vector2 (moveX * speed, rb.velocity.y);

	}
}
