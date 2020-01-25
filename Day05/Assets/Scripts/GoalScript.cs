using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour {

	public gameManager gameManager;

	private void OnTriggerEnter(Collider other) {
		gameManager.goal = true;
	}	
}
