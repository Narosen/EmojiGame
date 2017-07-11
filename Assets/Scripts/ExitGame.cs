using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Player") {
			PlayerPrefs.SetString ("sceneToLoad", "Prototype1");
			Application.Quit ();
		}
	}
}
