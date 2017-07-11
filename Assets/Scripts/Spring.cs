using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour {

	private Animator anim;
	private Collision2D objectToBounce;
	public float jumpHeight = 10f;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll){

		objectToBounce = coll;
		StartCoroutine (animating ());





	}

	IEnumerator animating(){
		anim.SetBool ("Bounce", true);
		transform.position = new Vector3 (transform.position.x, transform.position.y - 0.08f, transform.position.z);
		yield return new WaitForSeconds (0.03f);
		transform.position = new Vector3 (transform.position.x, transform.position.y - 0.11f, transform.position.z);
		yield return new WaitForSeconds (0.03f);
		transform.position = new Vector3 (transform.position.x, transform.position.y - 0.06f, transform.position.z);
		yield return new WaitForSeconds (0.03f);
		transform.position = new Vector3 (transform.position.x, transform.position.y + 0.06f, transform.position.z);
		yield return new WaitForSeconds (0.03f);
		transform.position = new Vector3 (transform.position.x, transform.position.y + 0.11f, transform.position.z);
		objectToBounce.rigidbody.velocity = new Vector2(objectToBounce.rigidbody.velocity.x,jumpHeight) ;
		yield return new WaitForSeconds (0.03f);
		transform.position = new Vector3 (transform.position.x, transform.position.y + 0.08f, transform.position.z);
		anim.SetBool ("Bounce", false);
	}
}
