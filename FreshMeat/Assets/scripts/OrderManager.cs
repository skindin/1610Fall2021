using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public float initialOrderRate = 20;
    public float orderAccRate = 1;
}

public struct Order
{
    public string item;
    public float timeLimit;
    public Vector3 adress;
}
