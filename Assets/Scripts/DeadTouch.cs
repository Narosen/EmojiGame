using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadTouch : MonoBehaviour {

	public Transform checkpoint;
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			PlayerPrefs.SetFloat ("xValue", checkpoint.position.x);
			PlayerPrefs.SetInt ("yValue", (int)checkpoint.position.y);
			PlayerPrefs.SetString ("State", "respawn");
			SceneManager.LoadScene ("Prototype1");

		} else if (coll.gameObject.tag == "Enemy") {
		
			Destroy (coll.gameObject);
		}


	}
}
