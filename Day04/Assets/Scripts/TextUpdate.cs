using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdate : MonoBehaviour {

	public Text		score;
	public Text		time;
	public Text		ringsNum;

	public List <GameObject> pickedRings = new List <GameObject>();
	public GameObject sonic;
	private Sonic sonicScript;

	private float	timeSinceStart = 0f;
	private float	secondsElapsed;
	private	string	secondsText = "";
	private string	minutesText = "";
	
	private void Start() {
		sonicScript = sonic.GetComponent<Sonic>();
	}

	void Update () {
		timeSinceStart += Time.deltaTime;
        secondsText = "";
		if (timeSinceStart > 60f)
        {
            secondsElapsed++;
            secondsText = "0";
            timeSinceStart = 0;
        }
		else if (timeSinceStart < 10f) {
			secondsText = "0";
		}
        secondsText += Mathf.RoundToInt(timeSinceStart).ToString();
        minutesText = secondsElapsed.ToString();
		time.text = "TIME " + minutesText + ":" + secondsText;
        ringsNum.text = sonicScript.collectedRings.ToString();
		score.text = "SCORE " + sonicScript.points.ToString();
	}
}
