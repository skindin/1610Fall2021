using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Character character;
    CamController camLook;

    private void Start()
    {
        character = GetComponent<Character>();
        camLook = FindObjectOfType<CamController>();
    }

    void Update()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        var input = new Vector3(x, 0, y).normalized;
        var camTrans = Camera.main.transform;
        var camUpDelta = Vector3.Angle(camTrans.up, Vector3.up);
        var flatRot = Quaternion.AngleAxis(-camUpDelta, camTrans.right) * camTrans.rotation;
        character.input = flatRot * input;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            character.jump = true;
        }
    }
}
