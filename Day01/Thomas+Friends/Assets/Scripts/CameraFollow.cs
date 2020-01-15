
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour {

	public GameObject		red;
	public GameObject		yellow;
	public GameObject		blue;
	float					smoothSpeed = 0.125f;
	Transform				target = null;
	Vector3					offset;
	bool					win = false;

	public static bool	redInBox = false;
	public static bool	blueInBox = false;
	public static bool	yellowInBox = false;

	void Update () {
		if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1)) {
			PlayerScript_ex00.redSelected = true;
			PlayerScript_ex00.yellowSelected = false;
			PlayerScript_ex00.blueSelected = false;
			PlayerScript_ex01.redSelected = true;
			PlayerScript_ex01.yellowSelected = false;
			PlayerScript_ex01.blueSelected = false;
			target = red.transform;
		}
		else if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2)) {
			PlayerScript_ex00.redSelected = false;
			PlayerScript_ex00.yellowSelected = true;
			PlayerScript_ex00.blueSelected = false;
			PlayerScript_ex01.redSelected = false;
			PlayerScript_ex01.yellowSelected = true;
			PlayerScript_ex01.blueSelected = false;
			target = yellow.transform;
		}
		else if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3)) {
			PlayerScript_ex00.redSelected = false;
			PlayerScript_ex00.yellowSelected = false;
			PlayerScript_ex00.blueSelected = true;
			PlayerScript_ex01.redSelected = false;
			PlayerScript_ex01.yellowSelected = false;
			PlayerScript_ex01.blueSelected = true;
			target = blue.transform;
		}
		if (Input.GetKeyDown(KeyCode.R)) {
			red.transform.position = new Vector3(-3.25f, -4.11f, 5);
			blue.transform.position = new Vector3(-5.43f, -3.65f, 5);
			yellow.transform.position = new Vector3(-4.01f, -3.65f, 5);
		}
		if (target) {
			Vector3 velocity = Vector3.zero;
			offset = new Vector3(0, target.position.y * -1, -10);
			Vector3 desiredPosition = target.position + offset;
			Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
			transform.position = smoothedPosition;
		}
		if (redInBox && blueInBox && yellowInBox && !win) {
			Debug.Log("You Win!");
			redInBox = false;
			SceneManager.LoadScene("ex02", LoadSceneMode.Single);
		}
	}
}

