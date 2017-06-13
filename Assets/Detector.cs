using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour {

	GameObject doorOpen;
	GameObject doorClose;


	void OnTriggerStay(Collider2D coll){
				doorClose.SetActive(true);
				doorOpen.SetActive(false);
	}
}
