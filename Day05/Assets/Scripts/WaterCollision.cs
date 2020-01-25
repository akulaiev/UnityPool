using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollision : MonoBehaviour {
	public UIManagerScript ui;

	private void OnTriggerEnter(Collider other) {
			ui.gameOver = true;
	}
}
