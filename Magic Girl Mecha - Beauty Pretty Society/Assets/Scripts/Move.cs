using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class Move : MonoBehaviour
{
    public float speed;
    public Boundary boundary;

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        this.GetComponent<Rigidbody>().velocity = movement * speed;
        this.GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(this.GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp(this.GetComponent<Rigidbody>().position.y, boundary.yMin, boundary.yMax),
			0.0f
        );
    }
}