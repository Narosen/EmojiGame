using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is for the moving platform either horizontal or vertical

public class MovingTile : MonoBehaviour {

	public enum movementDirection
	{
		Vertical,
		Horizontal
	}

	public movementDirection direction;

	public float minY;
	public float maxY;

	public float minX;
	public float maxX;

	public float speed = 0.1f;

	private Transform tile;

	private Collider2D[] objects;

	private bool touched;

	float y = -1f;
	float x = 4.567821f;

	float xInter;
	float yInter;

	public float sizeX = 2f;
	public float sizeY = 1f;
	public float extraY = 0f; 
	public float extraX = 0f;

	public LayerMask layer;

	public bool moveOnWithPlayerTouch;


	// Use this for initialization
	void Start () {
		
		//getting the initial position of the platform to set the limits according to it
		tile = GetComponent<Transform> ();

	}

	// Update is called once per frame
	void Update () {

		//returning colliders that are on the moving platform so that it can move along with it
		objects = Physics2D.OverlapBoxAll (new Vector2 (transform.position.x + extraX, transform.position.y + extraY), new Vector2 (sizeX, sizeY),0.0f,layer);

		if (moveOnWithPlayerTouch == false) {


			//for movement, we use the sin movement. We convert the [-1,1] range of sin to range [0,1] using inverse lerp. 
			//Then we use the converted range on lerp for the min and max diatance to cover.

			//for vertical movement
			if (direction == movementDirection.Vertical) {

				yInter = Mathf.InverseLerp (-1f, 1f, Mathf.Sin (y));

				tile.position = new Vector3 (tile.position.x, (float) Mathf.Lerp (minY, maxY, yInter), tile.position.z);

				y += speed * Time.deltaTime;

			}

			//for horizontal movement
			else if (direction == movementDirection.Horizontal) {

				xInter = Mathf.InverseLerp (-1f, 1f, Mathf.Sin (x));

				float pos1 = tile.position.x;

				tile.position = new Vector3 ((float) Mathf.Lerp (minX, maxX, xInter) ,tile.position.y , tile.position.z);

				float pos2 = tile.position.x;

				//for the objects on top of the moving platform to move along, we add the distance covered by the platform
				//from initial to final position per frame rate to objects 
				for (int i = 0; i < objects.Length; i++) {
					objects[i].transform.position = new Vector3 (objects[i].transform.position.x + (pos2 - pos1), objects[i].transform.position.y, objects[i].transform.position.z);

				}

				x += speed * Time.deltaTime;

			}
		
		}


		
	}

	void OnCollisionEnter2D(Collision2D coll){
		
		if (coll.gameObject.tag == "Player") {
			moveOnWithPlayerTouch = false;
		}

	}

	private void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
			//Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
		Gizmos.DrawWireCube(new Vector3(transform.position.x + extraX,transform.position.y+extraY,transform.position.z), new Vector3(sizeX,sizeY,-3f));
	}


}
