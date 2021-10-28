using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    public List<Character> characters;
}


[System.Serializable]
public class Character
{
    public string Name;
    public Species species;
    public Properties properties;

    [System.Serializable]
    public class Species
    {
        public string Name;
        List<Character> members;
    }

    [System.Serializable]
    public struct Properties
    {
        public float height;
        public float weight;
    }
}