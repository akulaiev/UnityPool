using System.Collections;
using UnityEngine;
using System;
using System.Collections.Generic;

public class CharacterSelection : MonoBehaviour {
	public GameObject	prefabCharacter;
	public GameObject	prefabOrc;
	public List <GameObject> selectedCharacters = new List <GameObject>();
	float				currentTime = 0f;
	float				createCharacterTimeInterval = 10;
	GameObject			newCharacter = null;
	GameObject			newOrc = null;

	void Update () {
		
		currentTime += Time.deltaTime;
		if (currentTime >= createCharacterTimeInterval) {
			currentTime -= createCharacterTimeInterval;
			newCharacter = Instantiate(prefabCharacter, prefabCharacter.transform.position, Quaternion.identity);
			newOrc = Instantiate(prefabOrc, prefabOrc.transform.position, Quaternion.identity);
		}
	}
}
