using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyScript : MonoBehaviour {

	public Text enemyHP;
	private int hp = 5;
	public TankScript tankScript;
	
	private void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag  == "Untagged") {
			hp--;
			enemyHP.text = "Enemy HP " + hp.ToString();
			if (hp == 0) {
				tankScript.youWin = true;
				enemyHP.enabled = false;
			}
		}
		if (tankScript.gameOver) {
			enemyHP.enabled = false;
		}
	}
}
