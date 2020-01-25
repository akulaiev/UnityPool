using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour {

	public List <GameObject> enemyTypes;
	public GameObject spawnedEnemy = null;
	public GameObject target;
	private int enemyHp;
	float				currentTime = 0f;
	float				createCharacterTimeInterval = 10;

	private void Start() {
		createEnemy();
	}

	private void OnTriggerEnter(Collider other) {
		Debug.Log("here");
		if (other.tag == "Player") {
			enemyHp--;
		}
	}

	void createEnemy(){
		spawnedEnemy = Instantiate(enemyTypes[Random.Range(1, 1)],
		target.transform.position + new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5)), Quaternion.identity);
		spawnedEnemy.tag = "Enemy";
		enemyHp = 3;
	}

	void Update () {
		currentTime += Time.deltaTime;
		if (!spawnedEnemy && currentTime >= createCharacterTimeInterval) {
			currentTime -= createCharacterTimeInterval;
			createEnemy();
		}
		if (enemyHp == 0) {
			Destroy(spawnedEnemy);
			spawnedEnemy = null;
		}
	}
}
