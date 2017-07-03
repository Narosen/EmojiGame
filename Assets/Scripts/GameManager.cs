using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	static public GameManager gm;

	public GameObject player;

	public enum GameState{
		Playing,
		Menu,
		Respawn
	}

	GameState gameState;


	// Use this for initialization
	void Start () {

		if (gm == null) {
		
			gm = new GameManager ();
		}
		PlayerPrefs.SetString ("State", "NotRespawn");
		gameState = GameState.Playing;


		float x = PlayerPrefs.GetFloat ("xValue");
		float y = (float)PlayerPrefs.GetInt ("yValue");

		player.transform.position = new Vector3 (x, y, 0f);
		
	}
	
	// Update is called once per frame
	void Update () {

		if(PlayerPrefs.GetString("State")=="respawn"){

			gameState = GameState.Respawn;

		} else {
			gameState = GameState.Playing;
		}

		switch (gameState) {
		case GameState.Playing:
			{
				break;
			}

		case GameState.Menu:
			{
				break;
			}

		case GameState.Respawn:
			{	
				float x = PlayerPrefs.GetFloat ("xValue");
				float y = (float)PlayerPrefs.GetInt ("yValue");
				player.transform.position = new Vector3 (x, y, 0f);
				PlayerPrefs.SetString ("State", "NotRespawn");
				gameState = GameState.Playing;
				break;
			}

		}

		
	}
}
