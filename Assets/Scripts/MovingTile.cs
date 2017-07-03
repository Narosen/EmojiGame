using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	float x = -1f;

	float xInter;
	float yInter;

	public float sizeX = 2f;
	public float sizeY = 1f;
	public float extraY = 0f; 
	public float extraX = 0f;

	public LayerMask layer;


	// Use this for initialization
	void Start () {

		tile = GetComponent<Transform> ();

	}

	// Update is called once per frame
	void Update () {

		objects = Physics2D.OverlapBoxAll (new Vector2 (transform.position.x + extraX, transform.position.y + extraY), new Vector2 (sizeX, sizeY),0.0f,layer);

		if (direction == movementDirection.Vertical) {

			yInter = Mathf.InverseLerp (-1f, 1f, Mathf.Sin (y));
		
			tile.position = new Vector3 (tile.position.x, (float) Mathf.Lerp (minY, maxY, yInter), tile.position.z);

			//for (int i = 0; i < objects.Length; i++) {
			//	objects[i].transform.position = new Vector3 (objects[i].transform.position.x, objects[i].transform.position.y , objects[i].transform.position.z);
			
			//}

			y += speed * Time.deltaTime;

		}

		else if (direction == movementDirection.Horizontal) {

			xInter = Mathf.InverseLerp (-1f, 1f, Mathf.Sin (x));

			float pos1 = tile.position.x;

			tile.position = new Vector3 ((float) Mathf.Lerp (minX, maxX, xInter) ,tile.position.y , tile.position.z);

			float pos2 = tile.position.x;

			for (int i = 0; i < objects.Length; i++) {
				objects[i].transform.position = new Vector3 (objects[i].transform.position.x + (pos2 - pos1), objects[i].transform.position.y, objects[i].transform.position.z);

			}

			x += speed * Time.deltaTime;

		}

		
	}

	private void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
			//Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
		Gizmos.DrawWireCube(new Vector3(transform.position.x + extraX,transform.position.y+extraY,transform.position.z), new Vector3(sizeX,sizeY,-3f));
	}


}
