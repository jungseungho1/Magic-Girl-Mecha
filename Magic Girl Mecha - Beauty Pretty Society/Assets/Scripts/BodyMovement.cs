using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovement : MonoBehaviour {

	public Transform leftarm;
	public Transform rightarm;
	public Transform leftleg;
	public Transform rightleg;
	public float thrust;

	public Rigidbody body;

		void Start () {
		body = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		
		Vector3 leftArmDirection = leftarm.transform.forward;
		Vector3 rightArmDirection = rightarm.transform.forward;
		Vector3 leftLegDirection = leftleg.transform.forward;
		Vector3 rightLegDirection = rightleg.transform.forward;

		if (Input.GetKey ("g") == true) {
			body.AddForce (leftArmDirection * thrust);
		}
		if (Input.GetKey ("j") == true) {
			body.AddForce (rightArmDirection * thrust);
		}
		if (Input.GetKey ("b") == true) {
			body.AddForce (leftLegDirection * thrust);
		}
		if (Input.GetKey ("n") == true) {
			body.AddForce (rightLegDirection * thrust);
		}
	}
}
