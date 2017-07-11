using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilianMovement : MonoBehaviour {

	private Rigidbody2D rb;
	private int flipNo = 1;
	public float bounceHeight = 3f;
	private bool nextMovement = true;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		flipNo = Random.Range (1,100);
		if (nextMovement) {
			nextMovement = false;
			StartCoroutine (move());

		}
		
	}

	IEnumerator move(){
		if (flipNo % 2 == 0) {
			rb.velocity =  new Vector2 (1, bounceHeight);
		} else {
			rb.velocity =  new Vector2 (-1, bounceHeight);
		}

		yield return new WaitForSeconds (Random.Range (2,7));

		nextMovement = true;
	}


}
