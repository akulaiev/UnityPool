using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CharachterMovement : MonoBehaviour {
	bool						moveTowardsNewPos = false;
	Vector3						newPos = Vector3.zero;
	Vector3						step = Vector3.zero;
	float						moveSpeed = 0.05f;
	public Animator				animator;
	public GameObject			audioObject;
	public bool					isSelected = false;
	PlayAudioScript				audioScript;
	SpriteRenderer				mySpriteRenderer;
	CharacterSelection			selectedCharacters;

	
	private void Start() {
		stopAnimating();
		mySpriteRenderer = GetComponent<SpriteRenderer>();
		audioScript = audioObject.GetComponent(typeof(PlayAudioScript)) as PlayAudioScript;
		selectedCharacters = Camera.main.GetComponent<CharacterSelection>();
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

	private void OnMouseDown() {

		isSelected = true;
		if (Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) {
			if (!objectAddedToSelected()) {
				selectedCharacters.selectedCharacters.Add(gameObject);
			}
		}
		else
		{
			if (selectedCharacters.selectedCharacters.Count > 0) {
				selectedCharacters.selectedCharacters.Clear();
			}
			else {
				selectedCharacters.selectedCharacters.Add(gameObject);
			}
		}
	}

	bool objectAddedToSelected() {
		foreach (GameObject character in selectedCharacters.selectedCharacters) {
			if (character.name == gameObject.name) {
				return (true);
			}
		}
		return(false);
	}

	void Update () {
		if (Input.GetMouseButtonDown(0) && !moveTowardsNewPos && objectAddedToSelected() &&
		!Input.GetKey(KeyCode.RightControl) && !Input.GetKey(KeyCode.LeftControl)) {
			moveTowardsNewPos = true;
			audioScript.playRandomSound();
			newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			newPos.z = transform.position.z;
		}
		if (moveTowardsNewPos) {
			checkDirection(newPos);
			if (transform.position != newPos) {
				step = Vector3.MoveTowards(transform.position, newPos, moveSpeed);
				transform.position = new Vector3 (step.x, step.y, transform.position.z);
			}
			else {
				moveTowardsNewPos = false;
				stopAnimating();
			}
		}
		if (Input.GetMouseButtonDown(1) && selectedCharacters.selectedCharacters.Count > 0) {
			selectedCharacters.selectedCharacters.Clear();
		}
	}
}
