using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour {

	public GameObject[] selection;
	public Text			lostLives;
	public Text			bestScore;
	private GameObject	selected;
	private int			selectedIndx = 0;
	private int			unlockedScenes;

	private void Start() {
		selected = selection[0];
		unlockedScenes = PlayerPrefs.GetInt("UnlockedLevels");
		if (unlockedScenes < selection.Length) {
			  int i = unlockedScenes + 1;
			  while (i < selection.Length) {
				  SpriteRenderer sr = selection[i].GetComponent<SpriteRenderer>();
				  sr.color = Color.gray;
				  i++;
			  }
		}
		lostLives.text = PlayerPrefs.GetInt("LostLives").ToString();
		bestScore.text = PlayerPrefs.GetInt("BestScore").ToString();
	}

	void moveSelection(int direction) {
		if (selectedIndx + direction >= 0 && selectedIndx + direction < selection.Length) {
			selectedIndx += direction;
			selected = selection[selectedIndx];
			gameObject.transform.position = selected.transform.position;
		}
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			moveSelection(1);
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			moveSelection(-1);
		}
		if (Input.GetKeyDown(KeyCode.Return)) {
			if (unlockedScenes <= selectedIndx) {
				SceneManager.LoadScene("Level" + selectedIndx.ToString(), LoadSceneMode.Single);
			}
		}
	}
}
