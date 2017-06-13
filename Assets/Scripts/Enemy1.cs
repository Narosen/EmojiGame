using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour {

	public float speed = 0.5f;
	public Transform Player;

	private Vector2 startVelocity;
	private bool firstVelocity = false;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		firstVelocity = false;
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {


		if (Vector2.Distance (Player.position, transform.position) > 1.0f) {
			
			transform.position = Vector2.MoveTowards(transform.position,Player.position,speed*Time.deltaTime);
		}

		
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (firstVelocity == false) {
			startVelocity = rb.velocity;
			firstVelocity = true;
		} 

		rb.velocity = startVelocity;

	}
}
