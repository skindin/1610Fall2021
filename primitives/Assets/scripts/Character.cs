using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Levitate levitator;
    Rigidbody rigbod;
    public Vector3 input;
    public float maxSpeed = 1;
    public float maxAcc;
    public bool jump;
    public float jumpForce = 10;
    // Start is called before the first frame update
    void Start()
    {
        levitator = GetComponent<Levitate>();
        rigbod = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Jump();
        Move();
    }

    void Jump ()
    {
        if (jump && levitator.onGround)
        {
            jump = false;
            rigbod.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void Move ()
    {
        if (levitator.onGround)
        {
            Vector3 newVelocity = input * maxSpeed - rigbod.velocity;
            Vector3 force = Vector3.ClampMagnitude(newVelocity * maxAcc,levitator.levForce);
            rigbod.AddForce(force);
        }
    }
}
