using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AlarmScript : MonoBehaviour {

	public float alarmTime = 0;
	private bool exited = false;

	public Text caughtText;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		caughtText.enabled = false;
	}

	void OnTriggerStay(Collider other)
	{
		alarmTime += Time.deltaTime;
	}

	private void OnTriggerExit(Collider other) {
		exited = true;
	}

	private void FixedUpdate() {
		if (exited && alarmTime > 0) {
			exited = false;
			alarmTime -= 0.0001f;
		}
		if (alarmTime >= 5) {
			caughtText.enabled = true;
			if (Input.GetKeyDown(KeyCode.Return)) {
				caughtText.enabled = false;
				SceneManager.LoadScene("ex00");
			}
		}
	}
}
