using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Levitate levitator;
    Rigidbody rigbod;
    PlayerController controller;
    public InputParam input;
    public float maxSpeed = 1;
    public float maxAcc;
    public float strength = 100;
    public float jumpForce = 10;
    bool onGround;

    public float currentForce;
    // Start is called before the first frame update
    void Start()
    {
        levitator = GetComponent<Levitate>();
        rigbod = GetComponent<Rigidbody>();
        controller = GetComponent<PlayerController>();

        if (controller != null)
        {
            input = controller.input;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (levitator != null)
        {
            onGround = levitator.onGround;
        }
        else
        {
            onGround = true;
        }

        Jump();
        Move();
    }

    void Jump ()
    {
        if (input.jump && onGround)
        {
            input.jump = false;
            rigbod.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void Move ()
    {
        if (onGround)
        {
            Vector3 newVelocity = input.direction * maxSpeed - rigbod.velocity;
            Vector3 force = newVelocity * maxAcc;
            rigbod.AddForce(force);
            //levitator.UpdateRot(Quaternion.FromToRotation(transform.forward, input));
            currentForce = force.magnitude;
        }
    }
}

public class InputParam
{
    public Vector3 direction;
    public bool jump;
}
