using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class Move : MonoBehaviour
{
    public float speed;
    public Boundary boundary;

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        this.GetComponent<Rigidbody>().velocity = movement * speed;
        this.GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(this.GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(this.GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
        );
    }
}