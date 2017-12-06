using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public float tumble;

    void Start()
    {
        this.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }
}
