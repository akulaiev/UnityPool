using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour {

	public GameObject enemyPrefab;
	public GameObject enemyTarget;
	private enemyScript enemyScript;
	private float time;
	private float spawnTime = 15f;
	private int enemyNum = 0;
	
	void spawnEnemy() {
		GameObject enemy = Instantiate(enemyPrefab, transform.position + new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5)), Quaternion.identity);
		enemyScript = enemy.GetComponent<enemyScript>();
		enemyScript.target = enemyTarget;
	}

	void Start()
	{
		spawnEnemy();
	}

	void Update () {
		time = Time.deltaTime;
		if (time > spawnTime) {
			time -= spawnTime;
			spawnEnemy();
		}
	}
}
