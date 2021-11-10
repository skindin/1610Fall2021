using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public InputParam input = new InputParam ();

    // Update is called once per frame
    void Update()
    {
        var target = FindObjectOfType<PlayerController>().transform;

        input.direction = (target.position - transform.position).normalized;
    }
}
