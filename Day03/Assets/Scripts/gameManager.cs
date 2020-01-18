using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {

	
	[HideInInspector]public int playerHp = 20;
	public int playerMaxHp = 20;
	[HideInInspector]public int playerEnergy = 300;
	public int playerStartEnergy = 300;
	public Button pauseButton;
	public Button playButton;
	public Button quitButton;
	public int delayBetweenWaves = 10;	public int nextWaveEnnemyHpUp = 20;
	public int nextWaveEnnemyValueUp = 30;
	public int averageWavesLenght = 15;
	public int totalWavesNumber = 20;
	public Text HP;
	public Text Energy;

	[HideInInspector]public bool lastWave = false;
	[HideInInspector]public int currentWave = 1;
	private float tmpTimeScale = 1;
	[HideInInspector]public int score = 0;
	private bool menuIsShowing = false;
	private bool isPaused = false;

	public static gameManager gm;

	void Awake () {
		if (gm == null)
			gm = this;
	}

	void Start() {
		Time.timeScale = 1;
		playerHp = playerMaxHp;
		playerEnergy = playerStartEnergy;
		pauseButton.gameObject.SetActive(false);
		playButton.gameObject.SetActive(false);
		quitButton.gameObject.SetActive(false);
	}

	private void Update() {
		HP.text = playerHp.ToString();
		Energy.text = playerEnergy.ToString();
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (!menuIsShowing) {
				quitButton.gameObject.SetActive(true);
				pauseButton.gameObject.SetActive(isPaused);
				playButton.gameObject.SetActive(!isPaused);
			}
			else {
				pauseButton.gameObject.SetActive(false);
				playButton.gameObject.SetActive(false);
				quitButton.gameObject.SetActive(false);
			}
		}
	}

	public void pause(bool paused) {
		if (paused == true) {
			tmpTimeScale = Time.timeScale;
			Time.timeScale = 0;
		}
		else
			Time.timeScale = tmpTimeScale;
	}

	public void changeSpeed(float speed) {
		Time.timeScale = speed;
	}

	public void damagePlayer(int damage) {
		playerHp -= damage;
		if (playerHp <= 0)
			gameOver();
		else
			Debug.Log ("Il reste au joueur " + playerHp + "hp");
	}
	public void gameOver() {
		Time.timeScale = 0;
		Debug.Log ("Game Over");
	}
}
