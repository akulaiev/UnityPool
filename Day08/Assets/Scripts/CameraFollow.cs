using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	private Vector3 pos = new Vector3(1, 3f, -10f);

	void Start()
	{
		transform.forward = target.forward;
	}

	void Update () {
		transform.position = target.position + pos;
	}
}
