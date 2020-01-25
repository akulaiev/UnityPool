using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankScript : MonoBehaviour {

	public bool gameOver = false;
	public AudioSource sound;
	public Rigidbody tankRb;
	public GameObject canon;
	public ParticleSystem gunShot;
	private bool isGrounded = false;
	private float speed = 1f;
	private float time = 0f;
	private float boostTime = 5f;
	private bool boostReady = true;
	private bool didHit = false;
	public Text boostText;
	public Text ammoText;
	public Text enterText;
	public Text goalText;
	public bool showGoalscreen = false;
	private int ammoNum = 10;
	public bool youWin = false;

	void Start () {
		transform.forward = Vector3.forward;
		boostText.text = "Boost is ready";
	}

	void goalScreen(bool showGoalBool) {
		enterText.enabled = showGoalBool;
		goalText.enabled = showGoalBool;
	}

	void Update () {
		goalScreen(showGoalscreen);
		ammoText.text = "Ammo " + ammoNum.ToString();
		if (ammoNum == 0) {
			gameOver = true;
		}
		if (gameOver) {
			enterText.text = "Press Enter to quit";
			enterText.enabled = true;
			goalText.text = "Sorry, you loose!";
			goalText.enabled = true;
			if (Input.GetKeyDown(KeyCode.Return)) {
				gameOver = false;
				Application.Quit();
				return;
			}
			boostText.enabled = false;
			ammoText.enabled = false;
		}
		if (youWin) {
			enterText.text = "Press Enter to quit";
			enterText.enabled = true;
			goalText.text = "Woo-Hooo! You win!!!";
			goalText.enabled = true;
			boostText.enabled = false;
			ammoText.enabled = false;
			if (Input.GetKeyDown(KeyCode.Return)) {
				gameOver = false;
				Application.Quit();
				return;
			}
		}
		Move();
		shoot();
	}

	private void shoot() {
		RaycastHit hit;
		if (Input.GetMouseButtonDown(0)) {
			ammoNum--;
			sound.PlayOneShot(sound.clip);
			if (Physics.Raycast(canon.transform.position, canon.transform.forward, out hit, 15, 1 << 8))
			{
				Debug.DrawRay(canon.transform.position, canon.transform.forward * hit.distance, Color.red);
				didHit = true;
				ammoNum++;
			}
			var emitParams = new ParticleSystem.EmitParams();
			if (didHit) {
				emitParams.position = hit.point;
				didHit = false;
			}
			else {
				emitParams.position = canon.transform.position + canon.transform.forward * 15;
			}
			emitParams.velocity = Vector3.forward;
			gunShot.Emit(emitParams, 1);
		}
	}

	private void OnCollisionStay(Collision other) {
		if (other.gameObject.tag == "Terrain") {
			isGrounded = true;
		}
	}

	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.tag == "Terrain") {
			isGrounded = false;
		}
	}

	private void Move()
    {
		// canon.transform.forward = Camera.main.transform.forward;
		canon.transform.rotation = Camera.main.transform.rotation;
		if (Input.GetKey(KeyCode.R)) {
			tankRb.rotation = Quaternion.identity;
		}
		if (isGrounded) {
			if (Input.GetKeyDown(KeyCode.LeftShift) && boostReady) {
				time += Time.deltaTime;
			if (time >= boostTime) {
				time -= boostTime;
				boostReady = !boostReady;
				if (!boostReady) {
					speed = 1;
					boostText.text = "No boost";
				}
			else {
				boostText.text = "Boost is ready";
			}
		}
				speed = 2f;
			}
			if (Input.GetKey(KeyCode.W)) {
				tankRb.velocity = -transform.forward * 25 * speed;
			}
			if (Input.GetKey(KeyCode.S)) {
				tankRb.velocity = transform.forward * 25 * speed;
			}
			if (Input.GetKey(KeyCode.A)) {
				tankRb.transform.Rotate(Vector3.down * 0.5f);
			}
			if (Input.GetKey(KeyCode.D)) {
				tankRb.transform.Rotate(Vector3.up * 0.5f);
			}
		}
    }
}
