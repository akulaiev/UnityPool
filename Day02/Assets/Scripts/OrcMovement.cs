using UnityEngine;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class OrcMovement : MonoBehaviour {
	Vector3						newPos = Vector3.zero;
	Vector3						step = Vector3.zero;
	float						moveSpeed = 0.05f;
	public Animator				animator;
	public GameObject			audioObject;
	public bool					isSelected = false;
	PlayAudioScript				audioScript;
	SpriteRenderer				mySpriteRenderer;
	CharacterSelection			selectedCharacters;


	float				currentTime = 0f;
	float				moveTimeInterval = 15;
	
	private void Start() {
		stopAnimating();
		mySpriteRenderer = GetComponent<SpriteRenderer>();
		audioScript = audioObject.GetComponent(typeof(PlayAudioScript)) as PlayAudioScript;
	}

	void stopAnimating() {
		animator.SetBool("WalkUp", false);
		animator.SetBool("WalkRight", false);
		animator.SetBool("WalkDown", false);
	}

	void checkDirection(Vector3 newPos) {
		var velocity = newPos - transform.position;
		if (velocity.y > 0.1) {
			animator.SetBool("WalkUp", true);
		}
		if (velocity.y < -0.1){
			animator.SetBool("WalkDown", true);
		}
		if (velocity.x > 0.1){
			animator.SetBool("WalkRight", true);
			mySpriteRenderer.flipX = false;
		}
		if (velocity.x < -0.1){
			animator.SetBool("WalkRight", true);
			mySpriteRenderer.flipX = true;
		}
	}

	void Update () {
		float x = Random.Range(-9, 9);
		float y = Random.Range(-7, 7);
		currentTime += Time.deltaTime;
		if (currentTime >= moveTimeInterval) {
			currentTime -= moveTimeInterval;
			audioScript.playRandomSound();
			newPos = new Vector3(x, y, 5);
		}
		checkDirection(newPos);
		if (transform.position != newPos) {
			step = Vector3.MoveTowards(transform.position, newPos, moveSpeed);
			transform.position = new Vector3 (step.x, step.y, transform.position.z);
		}
		else {
			stopAnimating();
		}
	}
}

