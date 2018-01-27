using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelChanger : MonoBehaviour {

	public string levelToChange = "koira";
	static Button button;

	// Use this for initialization
	void Start () {
		Button button = GetComponent<Button>();
		button.onClick.AddListener(ChangeLevel);
	}
	
	// Change level using levelToChange string
	void ChangeLevel() {
		SceneManager.LoadScene(levelToChange, LoadSceneMode.Single);
	}
}
