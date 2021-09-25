using UnityEngine;
using System.Collections;

public class AwakeAndStart : MonoBehaviour
{
    void Awake ()
    {
        Debug.Log("I'm awake");
    }
    
    
    void Start ()
    {
        Debug.Log("I'm out of bed");
    }
}