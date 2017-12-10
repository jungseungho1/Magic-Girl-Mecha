using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovement : MonoBehaviour
{

    public Transform leftarm;
    public Transform rightarm;
    public Transform leftleg;
    public Transform rightleg;
    public float thrust;

    public Rigidbody body;
    public ParticleSystem thrustParticlesLA;
    public ParticleSystem thrustParticlesRA;
    public ParticleSystem thrustParticlesLL;
    public ParticleSystem thrustParticlesRL;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }



    void FixedUpdate()
    {

        Vector3 leftArmDirection = leftarm.transform.forward;
        Vector3 rightArmDirection = rightarm.transform.forward;
        Vector3 leftLegDirection = leftleg.transform.forward;
        Vector3 rightLegDirection = rightleg.transform.forward;

        body.AddForce(Vector3.up * 1000);

        if ((GameObject.Find("leftArm").GetComponent<Thrust>().thrusting)){
            thrustParticlesLA.Play();
            body.AddForce(leftArmDirection * thrust);
        }else if (thrustParticlesLA.isPlaying){
            thrustParticlesLA.Stop();
        }
        if ((GameObject.Find("rightArm").GetComponent<Thrust>().thrusting)) {
            thrustParticlesRA.Play();
            body.AddForce(rightArmDirection* thrust);
        }else if (thrustParticlesRA.isPlaying){
            thrustParticlesRA.Stop();
        }
		if ((GameObject.Find("leftLeg").GetComponent<Thrust>().thrusting)) {
            thrustParticlesLL.Play();
            body.AddForce (leftLegDirection * thrust);
        }else if (thrustParticlesLL.isPlaying){
            thrustParticlesLL.Stop();
        }
		if ((GameObject.Find("rightLeg").GetComponent<Thrust>().thrusting)) {
            thrustParticlesRL.Play();
            body.AddForce (rightLegDirection * thrust);
		}else if(thrustParticlesRL.isPlaying){
            thrustParticlesRL.Stop();
        }

        //if (Input.GetKey("g") == true)
        //{
        //    body.AddForce(leftArmDirection * thrust);
        //}
        //if (Input.GetKey("j") == true)
        //{
        //    body.AddForce(rightArmDirection * thrust);
        //}
        //if (Input.GetKey("b") == true)
        //{
        //    body.AddForce(leftLegDirection * thrust);
        //}

    }
}
