using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	void toOtherScene(string sceneName) {
		SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Return)) {
			toOtherScene("DataSelect");
		}
	}
}
