using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {

	public void changeToScene(string sceneName) {
		SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
	}

	public void exitGame() {
		Application.Quit();
	}
}
