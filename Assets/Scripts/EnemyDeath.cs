using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {

	public float bounceOnEnemy;

	public Rigidbody2D rb;

	void Start(){

	}

	//death of the enemy
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {

			rb.velocity = new Vector2 (rb.velocity.x, bounceOnEnemy);
			Destroy (transform.parent.gameObject);

		}


	}
}
