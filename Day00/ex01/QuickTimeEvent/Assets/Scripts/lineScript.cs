using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineScript : MonoBehaviour {

	public GameObject	prefabButton;
	float				currentTime = 0f;
	float				createButtonTimeInterval;
	float				buttonSpeed;
	Vector3				buttonPosition;
	GameObject			newButton = null;
	float				precision = 0;

	// Use this for initialization
	void Start () {
		createButtonTimeInterval = Random.Range(1f, 2.45f);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (newButton == null) {
			currentTime += Time.deltaTime;
			if (currentTime >= createButtonTimeInterval) {
				currentTime -= createButtonTimeInterval;
				newButton = Instantiate(prefabButton, prefabButton.transform.position, Quaternion.identity);
				buttonSpeed = Random.Range(0.1f, 0.3f);
			}
		}
		else {
			newButton.transform.Translate(Vector3.down * buttonSpeed);
			if (newButton && newButton.transform.position.y <= -5f) {
				Destroy(newButton, 0);
				newButton = null;
				createButtonTimeInterval = Random.Range(1f, 2.45f);
			}
			if ((Input.GetKeyDown(KeyCode.A) && newButton.tag == "a") || (Input.GetKeyDown(KeyCode.S) && newButton.tag == "s") ||
				(Input.GetKeyDown(KeyCode.D) && newButton.tag == "d")) {
				precision = -4 - newButton.transform.position.y;
				if (precision < 0) {
					precision *= -1;
				}
				Debug.Log(" Precision: " + precision);
			}
		}
	}
}
