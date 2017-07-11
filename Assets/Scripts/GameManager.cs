using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	static public GameManager gm;

	public GameObject player;

	public enum GameState{
		Playing,
		Menu
	}

	GameState gameState;

	private static string previousLoadScene;
	private static string sceneToLoad;


	// Use this for initialization
	void Start () {

		previousLoadScene = PlayerPrefs.GetString ("previousLoadScene");
		sceneToLoad = PlayerPrefs.GetString ("sceneToLoad");
		float x = PlayerPrefs.GetFloat ("xValue");
		float y = (float)PlayerPrefs.GetInt ("yValue");

		if (previousLoadScene == null) {
			previousLoadScene = "Prototype1";
			PlayerPrefs.SetString ("previousLoadScene", previousLoadScene);
		}

		if (previousLoadScene == sceneToLoad) {
			player.transform.position = new Vector3 (x, y, 0f);
		} else {
			player.transform.position = new Vector3 (0f, 0f, 0f);
		}

		PlayerPrefs.SetString ("previousLoadScene", sceneToLoad);
		gameState = GameState.Playing;


		
	}
	
	// Update is called once per frame
	void Update () {

		switch (gameState) {
		case GameState.Playing:
			{
				break;
			}

		case GameState.Menu:
			{
				break;
			}

		}

		
	}
}
