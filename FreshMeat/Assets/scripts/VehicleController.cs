using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    public float speed = 15;
    //public float maxSpeed = 1;
    //public float acceleration = 1;
    public float turnSpeed = 1;

    Rigidbody rigbod;
    // Start is called before the first frame update
    void Start()
    {
        rigbod = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var forwardInput = Input.GetAxis("Vertical");
        //if (forwardInput != 0)
        //{
        //    speed = Mathf.Min(speed + acceleration * Time.deltaTime, maxSpeed);
        //}
        //else
        //{
        //    speed = Mathf.Max(speed - acceleration * Time.deltaTime, 0);
        //}

        var turnInput = Input.GetAxis("Horizontal");

        if (forwardInput != 0)
            rigbod.velocity = transform.forward * forwardInput * speed;
        transform.Rotate(new Vector3(0,turnInput * turnSpeed * forwardInput * Time.fixedDeltaTime,0));
    }
}
