using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public float speed = 1;
    bool focus = true;

    // Update is called once per frame
    void Update()
    {
        var upInput = Input.GetAxis("Mouse Y");
        var turnInput = Input.GetAxis("Mouse X");

        //var currentUpRot = Vector3.Angle(transform.up, Vector3.up);

        //var upRot = Quaternion.AngleAxis(upInput,transform.right);

        transform.rotation = Quaternion.AngleAxis(turnInput * speed, Vector3.up) * transform.rotation;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
