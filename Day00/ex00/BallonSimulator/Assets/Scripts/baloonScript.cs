using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baloonScript : MonoBehaviour {

	float timeSinceBlow;
	float prevBlowTime;
	int breathLevel;

	// Use this for initialization
	void Start () {
		breathLevel = 15;
		timeSinceBlow = 0;
		prevBlowTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			timeSinceBlow = Time.time - prevBlowTime;
			prevBlowTime = Time.time;
			transform.localScale = new Vector3(transform.localScale.x * 1.1f, transform.localScale.y * 1.1f, transform.localScale.z * 1.1f);
			if (timeSinceBlow <= 0.5) {
				// breathLevel--;
				Debug.Log(breathLevel);
			}
		}
		else {
			transform.localScale = new Vector3(transform.localScale.x * 0.9f, transform.localScale.y * 0.9f, transform.localScale.z * 0.9f);
		}
	}
}
