using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}

	public Transform player;
	public float smoothTime = 2F;
	private float velocity = 0.0F;
	public float extraXPosition = 5f;
	public float extraYPosition = 1.09f;

	public float leftBoundary;
	public float rightBoundary;
	public float upBoundary;
	public float downBoundary;

	private float PresentLeftBoundary;
	private float PresentRightBoundary;
	private float PresentUpBoundary;
	private float PresentDownBoundary;


	void FixedUpdate() {

		float newPositionX = Mathf.SmoothDamp(transform.position.x, player.position.x + extraXPosition, ref velocity, smoothTime);

		PresentLeftBoundary = newPositionX - (transform.position.x / 2) + extraXPosition;
		PresentRightBoundary = newPositionX + (transform.position.x / 2) + extraXPosition;
		PresentUpBoundary = player.position.y + (transform.position.y / 2) + extraYPosition;
		PresentDownBoundary = player.position.y - (transform.position.y / 2) + extraYPosition;

		if (PresentLeftBoundary <= leftBoundary || PresentRightBoundary >= rightBoundary ) {
			transform.position = new Vector3 (transform.position.x, player.position.y + extraYPosition, transform.position.z);
		} 

		if (PresentDownBoundary <= downBoundary || PresentUpBoundary >= upBoundary ) {
			transform.position = new Vector3 (newPositionX, transform.position.y , transform.position.z);
		
		}

		if(PresentLeftBoundary >= leftBoundary && PresentRightBoundary <= rightBoundary && PresentDownBoundary >= downBoundary && PresentUpBoundary <= upBoundary){
			transform.position = new Vector3(newPositionX, player.position.y + extraYPosition, transform.position.z);
		}

	}
}
