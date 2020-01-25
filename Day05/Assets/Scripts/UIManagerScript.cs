using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour {

	public FreeLookCam cameraScript;
	public Text cameraFollowButtonText;
	public Text holeNum;
	public Text shotNum;
	public Text enterText;
	public Text goalText;
	public Slider slider;
	public Text powerText;
	public bool showGoalscreen = false;
	public bool gameOver = false;
	public bool youWin = false;

	void goalScreen(bool showGoalBool) {
		enterText.enabled = showGoalBool;
		goalText.enabled = showGoalBool;
		slider.enabled = !showGoalBool;
		powerText.enabled = !showGoalBool;
	}

	void Update()
	{
		goalScreen(showGoalscreen);
		if (gameOver) {
			enterText.text = "Press Enter to quit";
			enterText.enabled = true;
			goalText.text = "Sorry, you loose!";
			goalText.enabled = true;
			slider.enabled = false;
			powerText.enabled = false;
			if (Input.GetKeyDown(KeyCode.Return)) {
				gameOver = false;
				Application.Quit();
				return;
			}
		}
		if (youWin) {
			enterText.text = "Press Enter to quit";
			enterText.enabled = true;
			goalText.text = "Woo-Hooo! You win!!!";
			goalText.enabled = true;
			slider.enabled = false;
			powerText.enabled = false;
			if (Input.GetKeyDown(KeyCode.Return)) {
				gameOver = false;
				Application.Quit();
				return;
			}
		}
	}

	public void followCamera() {
		cameraScript.followCursor = !cameraScript.followCursor;
		if (cameraScript.followCursor) {
			cameraFollowButtonText.text = "Follow Cursor: off";
		}
		else {
			cameraFollowButtonText.text = "Follow Cursor: on";
		}
	}
}
