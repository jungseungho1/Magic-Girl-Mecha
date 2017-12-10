using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrust : MonoBehaviour {

    public bool thrusting = true;

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "center")
        {
            thrusting = true;
        } 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "center")
        {
            thrusting = false;
        }
    }

}
