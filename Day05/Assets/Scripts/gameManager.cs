using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {
	public Rigidbody ballRB;
	public Transform ballPos;
	public GameObject arrow;
	public GameObject cameraRig;
	public UIManagerScript ui;
	public bool goal = false;
	public int[] pars;
	public GameObject[] startPoints;
	private bool sliderOn = false;
	private bool reachedMax = false;
	private float forcePoint = 75;
	private float m_MoveSpeed = 1f;
	private bool ballMoved = false;
	private bool prevFrame = false;
	private int holeNumInt = 1;
	private int shotNumInt = 1;
	private int posNum = 0;

	void Start () {
		ui.slider.enabled = false;
	}
	
	void getPower() {
		if (!reachedMax) {
			ui.slider.value++;
		}
		if (ui.slider.value == ui.slider.maxValue) {
			reachedMax = true;
		}
		if (reachedMax && ui.slider.value >= 0) {
			ui.slider.value--;
		}
		if (ui.slider.value == 0) {
			reachedMax = false;
		}
	}

	void Update () {
		arrow.transform.forward = -Camera.main.transform.forward;
		arrow.transform.position = ballPos.position + Vector3.up * 10 + Vector3.forward * 15;
		ui.showGoalscreen = goal;
		if (ballMoved && !prevFrame) {
			prevFrame = true;
		}
		if (Input.GetKeyDown(KeyCode.Space) && !ballMoved) {
			if (!sliderOn) {
				sliderOn = true;
			}
			else {
				ballRB.AddForce(Camera.main.transform.forward * forcePoint * ui.slider.value + Vector3.up * (0.1f * forcePoint));
				sliderOn = false;
				ui.slider.value = 0;
				ballMoved = true;
				holeNumInt++;
				ui.shotNum.text = "Shot " + shotNumInt.ToString(); 
			}
			
		}
		if (Input.GetKeyDown(KeyCode.Return) && goal) {
			goal = false;
			ballPos = startPoints[posNum].transform;
			ballRB.velocity = Vector3.zero;
			posNum++;
		}
		if (posNum == 3) {
			ui.youWin = true;
		}
		if (sliderOn) {
			getPower();
		}
		if (prevFrame && ballRB.velocity.x <= 0.1 && ballRB.velocity.y <= 0.1 && ballRB.velocity.z <= 0.1 && !sliderOn) {
			FollowBall(0.85f);
			ballMoved = false;
			prevFrame = false;
		}
	}

    void FollowBall(float deltaTime)
    {
        cameraRig.transform.position = Vector3.Lerp(cameraRig.transform.position, ballPos.position, deltaTime * m_MoveSpeed);
    }
}
