using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrust : MonoBehaviour {

    public float thrustForce = 50f;
    public GameObject center;

    void FixedUpdate()
    {
        if (Input.GetKey("z") == true)
        {
            this.GetComponent<Rigidbody>().AddRelativeForce(0, 0, thrustForce);
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "center")
    //    {
    //        transform.parent.gameObject.rigidbody.AddForceAtPosition(thrustForce, transform.position);
    //    }
    //}
}
