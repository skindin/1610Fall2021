using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitate : MonoBehaviour
{
    Rigidbody rigBod;
    public float levDist = 1;
    public float levForce = 100;
    public float levDampner = 10;
    public bool correctRot = true;
    public float rotForce = 100;
    public float rotDampner = 10;
    public bool onGround = false;

    // Start is called before the first frame update
    void Start()
    {
        rigBod = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateHover();
        if (correctRot)
        {
            UpdateRot(Quaternion.FromToRotation(transform.up,Vector3.up));
        }
    }

    void UpdateHover ()
    {
        Vector3 rayDir = Vector3.down;

        if (Physics.Raycast(transform.position, rayDir, out RaycastHit hit, levDist))
        {
            onGround = true;

            Vector3 vel = rigBod.velocity;

            Vector3 otherVel = Vector3.zero;
            Rigidbody hitBody = hit.rigidbody;
            if (hitBody != null)
            {
                otherVel = hitBody.velocity;
            }

            float rayDirVel = Vector3.Dot(rayDir, vel);
            float otherDirVel = Vector3.Dot(rayDir, otherVel);

            float relVel = rayDirVel - otherDirVel;

            float x = hit.distance - levDist;

            float springForce = (x * levForce) - (relVel * levDampner);

            rigBod.AddForce(rayDir * springForce);

            if (hitBody != null)
            {
                hitBody.AddForceAtPosition(rayDir * -springForce, hit.point);
            }
        }
        else
        {
            onGround = false;
        }

        //Color debugColor = Color.red;
        //Vector3 downPoint = Vector3.down * levDist + transform.position;

        //if (onGround)
        //{
        //    debugColor = Color.green;
        //    downPoint = hit.point;
        //}

        //Debug.DrawLine(transform.position, downPoint, debugColor);
    }

    public void UpdateRot (Quaternion newRotDelta)
    {
        Quaternion toGoal = newRotDelta;

        Vector3 rotAxis;
        float rotDegrees;

        toGoal.ToAngleAxis(out rotDegrees, out rotAxis);
        rotAxis.Normalize();

        float rotRadians = rotDegrees * Mathf.Deg2Rad;

        rigBod.AddTorque((rotAxis * (rotRadians * rotForce)) - (rigBod.angularVelocity * rotDampner));
    }
}
