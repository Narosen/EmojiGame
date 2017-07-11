using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateOnWeightingScale : MonoBehaviour {

	public PhysicsMaterial2D crateMaterial;

	void Update(){
		crateMaterial.friction = 0.4f;
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Player") {
			crateMaterial.friction = 0f;
		}

	}
}
