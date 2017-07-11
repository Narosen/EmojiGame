using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadTouch : MonoBehaviour {

	//this is the script for harmful objects that will kill the player


	public string levelToLoad;
		
	void OnCollisionEnter2D(Collision2D coll) {

		//on colliding, the scene will be loaded again but as the checkpoint position is stored
		//the player will respawn in the latest checkpoint  
		if (coll.gameObject.tag == "Player") {
			PlayerPrefs.SetString ("sceneToLoad", levelToLoad);
			SceneManager.LoadScene (levelToLoad);

		} else if (this.gameObject.tag != "Enemy" && coll.gameObject.tag == "Enemy") {

			//even enemies should die if the falls on spikes,etc
			Destroy (coll.gameObject);
		}


	}
}
