using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour {

	public GameObject[] brokenObjects;

	void OnCollisionStay2D(Collision2D coll){
		if (coll.rigidbody.mass > 49f) {
			for (int i = 0; i < brokenObjects.Length; i++) {
				brokenObjects[i].SetActive (true);
			}

			gameObject.SetActive (false);
		}
	}


}
