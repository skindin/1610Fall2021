using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    //public float followSpeed = 1;
    //public float turnSpeed = 1;

    public Transform target;
    void Update()
    {
        transform.position = target.position;

        //var newRot = Quaternion.LookRotation(target.position);
        //transform.rotation = Quaternion.Lerp(transform.rotation, newRot, turnSpeed * Time.deltaTime);
    }
}
