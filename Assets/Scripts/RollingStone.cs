using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingStone : MonoBehaviour {

	public GameObject Stone;

	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.tag == "Player") {
			Stone.GetComponent<Rigidbody2D> ().AddForce (new Vector2(-250f, 20f),ForceMode2D.Impulse);
		}
	}
}
