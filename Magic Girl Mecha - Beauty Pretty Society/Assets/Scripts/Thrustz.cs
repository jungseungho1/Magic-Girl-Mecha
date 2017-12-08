using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrustz : MonoBehaviour {

	public float thrustForce = 50f;

	void FixedUpdate()
	{
		if (Input.GetKey("z") == true)
		{
			this.GetComponent<Rigidbody>().AddRelativeForce(0,0,thrustForce);
		}
	}
}