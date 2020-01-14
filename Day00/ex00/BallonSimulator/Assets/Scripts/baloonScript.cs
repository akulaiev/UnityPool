using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baloonScript : MonoBehaviour {

	float	timerCurrent = 0f;
	float	timerTotal = 0.25f;
	float	currentBreathTimer = 0f;
	float	totalBreathTimer = 0.15f;
	int		breathLevel = 5;
	bool	outOfBreath = false;

	// Update is called once per frame
	void Update () {
		timerCurrent += Time.deltaTime;
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (breathLevel > 0) {
				outOfBreath = false;
				transform.localScale = new Vector3(transform.localScale.x * 1.15f, transform.localScale.y * 1.15f, transform.localScale.z * 1.15f);
				if(currentBreathTimer <= totalBreathTimer) {
					currentBreathTimer -= totalBreathTimer;
					breathLevel--;
				}
			}
			else {
				outOfBreath = true;
			}
		}
		if (timerCurrent >= timerTotal) {
			if (transform.localScale.x > 0.1f) {
				timerCurrent -= timerTotal;
				transform.localScale = new Vector3(transform.localScale.x * 0.9f, transform.localScale.y * 0.9f, transform.localScale.z * 0.9f);
			}
			if (breathLevel < 15 && outOfBreath) {
				breathLevel++;
			}
		}
		if (transform.localScale.x <= 0.1f || transform.localScale.x >= 8.5f) {
			Debug.Log("Balloon life time: " + Mathf.RoundToInt(Time.time) + "s");
			Destroy(gameObject);
		}
	}
}
