using UnityEngine;
using System.Collections;

public class PosB : MonoBehaviour
{

    public OSC osc;
    public Transform center;
    private float newX;
    private float newY;
    private float rawX;
    private float rawY;
    public float distance;

    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

    void Start()
    {
        osc.SetAddressHandler("/blueX", OnReceiveX);
        osc.SetAddressHandler("/blueY", OnReceiveY);
    }

    void OnReceiveX(OscMessage message)
    {
        rawX = message.GetFloat(0);
    }

    void OnReceiveY(OscMessage message)
    {
        rawY = message.GetFloat(0);
    }

    void FixedUpdate()
    {
        newX = map(rawX, -1, 1, distance, -distance);
        newY = map(rawY, -1, 1, distance, -distance);
        Vector3 oldPos = new Vector3(newX, newY, 0);
        Vector3 newPos = center.position + oldPos;
        transform.position = newPos;
        //Debug.Log("old " + oldPos + "new " + newPos);
    }

}
