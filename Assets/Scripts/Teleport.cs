using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

	public GameObject crate;

	void OnTriggerEnter2D(Collider2D other) {

		if(other.tag=="objects"){
			crate.SetActive (true);
			Destroy (other.gameObject);
		}

	}

}
