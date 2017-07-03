using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {

	/*public Transform player;
	private Camera cam;

	public float smooth;
	public float velocity;

	void Start(){

		cam = GetComponent<Camera> ();

	}

	void Update(){


	}*/

	public GameObject objectToFollow;

	public float speed = 2.0f;

	public float minX;
	public float maxX;
	public float minY;
	public float maxY;

	void Update () {

		float interpolation = speed * Time.deltaTime;

		Vector3 position = this.transform.position;

		position.y = Mathf.Lerp(this.transform.position.y, objectToFollow.transform.position.y, interpolation);
		position.x = Mathf.Lerp(this.transform.position.x, objectToFollow.transform.position.x, interpolation);

		if (position.x >= minX && position.x <= maxX) {
			
			this.transform.position = new Vector3 (position.x, this.transform.position.y, this.transform.position.z);
		
		}

		if(position.y >= minY && position.y <= maxY) {
			
			this.transform.position = new Vector3 (this.transform.position.x, position.y, this.transform.position.z);
		
		}  

	}

}
