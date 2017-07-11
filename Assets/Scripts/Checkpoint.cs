using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		//the position will be saved for the next play or death
		if (col.tag == "Player") {
			PlayerPrefs.SetFloat ("xValue", this.transform.position.x);
			PlayerPrefs.SetInt ("yValue", (int)this.transform.position.y);
		}
	
	}
}
