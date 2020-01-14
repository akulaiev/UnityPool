using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clubScript : MonoBehaviour {

	public GameObject	ball;
	float				spacePressStart = 0;
	float				timeSpacePressed = 0;
	bool				ballMoved = false;
	int 				points = -15;
	bool				rotated = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 translation;
		Vector3 ballDirection;

		if (ball) {
			if (Input.GetKey(KeyCode.Space))
			{
				if (spacePressStart == 0) {
					spacePressStart = Time.time;
				}
				transform.Translate(Vector3.down * 0.1f);
			}
			else
			{
				if (spacePressStart > 0 && ball) {
					if (timeSpacePressed == 0) {
						points += 5;
					if (points < 0) {
						Debug.Log("Score: " + points);
					}
					else {
						Debug.Log("Score: 0");
					}
						timeSpacePressed = Time.time - spacePressStart;
					}
					else if (timeSpacePressed > 0) {
						if (transform.position.y < ball.transform.position.y) {
							ballDirection = new Vector3(0, 1, 0);
						}
						else {
							ballDirection = new Vector3(0, -1, 0);
						}
						translation = checkWalls(ball.transform.position, ballDirection * timeSpacePressed);
						if (ball) {
							ball.transform.Translate(translation);
							timeSpacePressed = Mathf.Clamp(timeSpacePressed - 0.01f, 0, timeSpacePressed);
							ballMoved = true;
						}
					}
					if (ballMoved && timeSpacePressed == 0) {
						moveClubToBall();
					}
				}
			}
		}
	}

	bool checkHoleBehind() {
		if (ball.transform.position.y > 3) {
			return true;
		}
		return false;
	}

	Vector3 checkWalls(Vector3 ballPosition, Vector3 translation) {
		Vector3 newPosition = ballPosition + translation;
		Vector3 newTranslation = translation;
		if (newPosition.x < -2.8 || newPosition.x > 2.8) {
			newTranslation = new Vector3(translation.x * -1f, translation.y, translation.z);
		}
		else if (newPosition.y < -4.8 || newPosition.y > 4.8) {
			newTranslation = new Vector3(translation.x, translation.y  * -1f, translation.z);
		}
		else if (ballPosition.x > -0.3 && ballPosition.x < 0.3 && ballPosition.y > 2.7 && ballPosition.y < 3.3 && translation.y <= 0.1) {
			Destroy(ball, 0);
			ball = null;
			Debug.Log("You win!");
		}
		return newTranslation;
	}

	void moveClubToBall() {
		spacePressStart = 0;
		if (checkHoleBehind() && !rotated) {
			transform.Rotate(0, 0, 180, Space.Self);
			rotated = true;
		}
		else if (!checkHoleBehind() && rotated) {
			rotated = false;
			transform.Rotate(0, 0, 180, Space.Self);
		}
		transform.position = new Vector3(ball.transform.position.x - 0.2f, ball.transform.position.y + 0.2f, -1f);
		ballMoved = false;
	}
}
