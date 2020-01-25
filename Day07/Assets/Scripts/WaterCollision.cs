using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollision : MonoBehaviour {
	public TankScript tank;
	private void OnTriggerEnter(Collider other) {
			tank.gameOver = true;
	}
}
