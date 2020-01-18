using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitLevel : MonoBehaviour {

	public GameObject sonic;
	public GameObject final;
	private Sonic sonicScript;
	public AudioSource		audioSource;
	private SpriteRenderer	spriteRenderer;
	private float			rotationTime = 0.5f;
	private float			currentTime = 0f;
	private float			launchTime;

	void Start () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		sonicScript = sonic.GetComponent<Sonic>();
		final.SetActive(false);
	}

	void OnTriggerEnter2D(Collider2D other) {
		audioSource.PlayOneShot(audioSource.clip);
		int points = calcTimePoints();
		final.SetActive(true);
		final.GetComponent<Text>().text = "Your Score: " + points.ToString();
	}

	int calcTimePoints() {
		int points = sonicScript.points;
		int testTime = Mathf.RoundToInt(currentTime);
		if (testTime < 200) {
			points += 20000 - testTime;
		}
		return (points);
	}
	void Update () {
		currentTime += Time.deltaTime;
		if (currentTime >= rotationTime) {
			currentTime -= rotationTime;
			spriteRenderer.flipX = !spriteRenderer.flipX;
		}
	}
}
