using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyScript : MonoBehaviour {

	public float HP;
	public Animator animator;
	public NavMeshAgent agent;
	public GameObject target;
	
	private void Start() {
		Debug.Log(Vector3.Distance(target.transform.position, transform.position));
		animator.SetFloat("HP", HP);
	}

	void FixedUpdate () {
		agent.destination = target.transform.position;
		if (Vector3.Distance(target.transform.position, transform.position) <= 3) {
			animator.SetBool("isWalking", false);
			animator.SetBool("isAttacking", true);
		}
		else if (Vector3.Distance(target.transform.position, transform.position) >= 10) {
			animator.SetBool("isWalking", false);
			animator.SetBool("isAttacking", false);
		}
		else {
			animator.SetBool("isWalking", true);
			animator.SetBool("isAttacking", false);
		}
	}
}
