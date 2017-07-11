using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour {

	public string levelToLoad;

	public void OnClick(){
	
		PlayerPrefs.SetFloat ("xValue", 0f);
		PlayerPrefs.SetInt ("yValue", 0);
		SceneManager.LoadScene (levelToLoad);
	}
}
