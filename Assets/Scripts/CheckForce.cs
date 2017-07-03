using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForce : MonoBehaviour {

	private float mass;
	private Vector2 acceleration;
	private Vector2 velocity;
	private Rigidbody2D rb;
	private Vector2 force;

	public Vector2 deadForce = new Vector2 (25f ,25f );

	public Transform checkpoint;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		mass = rb.mass;
	}
	
	// Update is called once per frame
	void Update () {

		acceleration = rb.velocity / Time.time;
		force = mass * acceleration;

		Debug.Log (force);
						
	}



	void OnCollisionEnter2D(Collision2D coll) {
		if ((Mathf.Abs(force.x) >= deadForce.x) || (Mathf.Abs(force.y) >= deadForce.y)) {

			if (coll.gameObject.tag == "Player") {
				coll.transform.position = checkpoint.position;
			} else if(coll.gameObject.tag == "Enemy") {
				Destroy (coll.gameObject);
				
			}
		}
	}


}
