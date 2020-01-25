using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnumScript : MonoBehaviour {

	public float attackSpeed;
	public float damage;
	public Transform canonPoint;
	public ParticleSystem gunShot;
	public AudioSource audio;

	void Update () {
		RaycastHit hit;
		if (Input.GetMouseButtonDown(0)) {
			audio.PlayOneShot(audio.clip);
			Debug.DrawRay(canonPoint.position, Camera.main.transform.forward, Color.red);
			gunShot.Play();
			if (Physics.Raycast(canonPoint.position, Camera.main.transform.forward, out hit, Mathf.Infinity, 1 << 8))
			{
				Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
				Debug.Log("Did Hit");
			}
		}
	}
}
