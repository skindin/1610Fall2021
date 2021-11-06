using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float gravityMod = 10;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityMod;
    }
}
