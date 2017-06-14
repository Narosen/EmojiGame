using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour {

	public GameObject doorOpen;
	public GameObject doorClose;

	public GameObject IndicatorGreen;
	public GameObject IndicatorRed;



	void FixedUpdate(){
		
		doorClose.SetActive (false);
		IndicatorRed.SetActive (false);

		doorOpen.SetActive (true);
		IndicatorGreen.SetActive (true);


	}


	void OnTriggerStay2D(Collider2D coll){


		doorClose.SetActive(true);
		IndicatorRed.SetActive (true);

		doorOpen.SetActive(false);
		IndicatorGreen.SetActive (false);

	}
}
