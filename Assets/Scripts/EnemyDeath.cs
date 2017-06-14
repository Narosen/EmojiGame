using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			Destroy (transform.parent.gameObject);
			other.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, 10f), ForceMode2D.Impulse);;
		}


	}
}
