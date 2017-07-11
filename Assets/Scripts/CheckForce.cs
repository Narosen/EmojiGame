using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckForce : MonoBehaviour {

	private float mass;
	private Vector2 acceleration;
	private Vector2 velocity;
	private Rigidbody2D rb;
	private Vector2 force;
	public string levelToLoad;

	public Vector2 deadForce = new Vector2 (25f ,25f );


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		mass = rb.mass;
	}
	
	// Update is called once per frame
	void Update () {

		acceleration = rb.velocity / Time.time;
		force = mass * acceleration;
								
	}



	void OnCollisionEnter2D(Collision2D coll) {
		if ((Mathf.Abs(force.x) >= deadForce.x) || (Mathf.Abs(force.y) >= deadForce.y)) {

			if (coll.gameObject.tag == "Player") {
				PlayerPrefs.SetString ("sceneToLoad", levelToLoad);
				SceneManager.LoadScene (levelToLoad);
			} else if(coll.gameObject.tag == "Enemy") {
				Destroy (coll.gameObject);
				
			}
		}
	}


}
