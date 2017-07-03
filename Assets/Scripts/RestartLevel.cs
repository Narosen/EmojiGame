using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour {

	public Transform firstCheckpoint;
	public string levelToLoad;

	public void OnClick(){
	
		PlayerPrefs.SetFloat ("xValue", firstCheckpoint.position.x);
		PlayerPrefs.SetInt ("yValue", (int)firstCheckpoint.position.y);
		PlayerPrefs.SetString ("State", "respawn");
		SceneManager.LoadScene (levelToLoad);
	}
}
