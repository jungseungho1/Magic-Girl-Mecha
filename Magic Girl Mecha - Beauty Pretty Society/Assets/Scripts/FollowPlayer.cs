using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;
    public Vector3 offset;
    [Range(0f, 50f)]
    public float smoothSpeed = 0.125f;

    void FixedUpdate()
    {
        Vector3 desiredPos = player.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed*Time.deltaTime);
        transform.position = smoothedPos;
        //transform.LookAt(player);
    }
}
