using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Character : ScriptableObject
{
    public string Name;
    public string xClass;
    public string race;

    public Alignment alignment;
}

[System.Serializable]
public class Alignment
{
    public XAlign x;
    public YAlign y;

    public enum XAlign
    { 
        lawful, nuetral, chaotic
    }

    public enum YAlign
    {
        good, nuetral, evil
    }
}
