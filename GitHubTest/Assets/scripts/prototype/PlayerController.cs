using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float acceleration = 1;
    public float turnspeed = 1;

    public List<Rigidbody> wheels;
    public Rigidbody rigBod;

    void FixedUpdate()
    {
        float forward = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Horizontal");

        if (forward != 0)  //only moves the vehicle if it is moving forwards/backwards
        {
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * forward);
            //rigBod.AddForce(transform.forward * acceleration * forward, ForceMode.Acceleration);
            foreach (var wheel in wheels)
            {
                wheel.AddTorque(transform.right * acceleration * forward);
            }
            transform.Rotate(Vector3.up, turnspeed * turn);
        }
    }
}
