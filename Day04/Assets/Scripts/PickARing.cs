using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickARing : MonoBehaviour {

	public GameObject	textUpdate;
	public AudioSource	audioSource;
	private TextUpdate	textUpdateScript;

	private void Start() {
		textUpdateScript = textUpdate.GetComponent<TextUpdate>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		textUpdateScript.pickedRings.Add(gameObject);
		gameObject.SetActive(false);
		if (other.tag == "Player") {
			audioSource.PlayOneShot(audioSource.clip);
			other.gameObject.GetComponent<Sonic>().collectedRings++; 
			other.gameObject.GetComponent<Sonic>().points += 100;
		}
	}
}
