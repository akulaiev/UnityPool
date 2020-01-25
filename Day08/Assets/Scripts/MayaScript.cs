using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MayaScript : MonoBehaviour {

	public Animator animator;
	private NavMeshAgent agent;
	private Rigidbody mayaRb;
	
	void Start() {
		agent = GetComponent<NavMeshAgent>();
		mayaRb = GetComponent<Rigidbody>();
		animator.SetInteger("HP", 50);

		Debug.Log(mayaRb.velocity);
	}
	
	void FixedUpdate() {
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
				if (hit.collider.gameObject.tag == "Enemy" &&
				Vector3.Distance(transform.position, hit.collider.gameObject.transform.position) < 15) {
					animator.SetBool("isAttacking", true);
					Debug.Log("here");
				}
				else
				{
					agent.destination = hit.point;
					animator.SetInteger("Speed", (int)agent.speed); 
				}	
			}
		}
		if (animator.GetInteger("Speed") > 0 && mayaRb.transform.position == agent.destination) {
			animator.SetInteger("Speed", 0);
		}
	}
}
