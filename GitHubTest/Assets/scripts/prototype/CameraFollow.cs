using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform car;
    public float shiftSpeed;

    // Start is called before the first frame update
    //void Start()
    //{
    //    Cursor.lockState = CursorLockMode.Locked;
    //    Cursor.visible = false;
    //}

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = car.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(car.forward), shiftSpeed * Time.deltaTime);
    }
}
