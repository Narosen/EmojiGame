using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTouch : MonoBehaviour {

	public Transform checkpoint;
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			coll.transform.position = checkpoint.position;
		}


	}
}
