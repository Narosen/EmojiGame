using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour {

	public float speed = 0.5f;
	public Transform player;
	public LayerMask playerMask;

	private Vector2 startVelocity;
	private bool firstVelocity = false;
	private Rigidbody2D rb;

	private Vector3 pointA = new Vector3 (-14.38f,5.1f,0f);
	private Vector3 pointB = new Vector3 (14.38f,-5.1f,0f);

	// Use this for initialization
	void Start () {
		firstVelocity = false;
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.DrawLine(new Vector3(transform.position.x,transform.position.y,0f) + pointA, new Vector3(transform.position.x,transform.position.y,0f)+pointB);
		if(Physics2D.OverlapArea(transform.position+pointA,transform.position+pointB,playerMask))
			{
				if (Vector2.Distance (player.position, transform.position) > 0.5f) {

					transform.position = Vector2.MoveTowards(transform.position,player.position,speed*Time.deltaTime);
				}
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
