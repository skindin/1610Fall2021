using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopsAndArrays : MonoBehaviour
{
    public List<Team> teams = new List<Team>();
    public GameObject cube;
    public float spaceBetween = 1;

    private void Start()
    {
        for (var i = 0; i < teams.Count; i++)
        {
            var pos = Vector3.right * i * spaceBetween;

            teams[i].cube = Instantiate(cube, pos, Quaternion.identity);
        }
    }

    private void Update()
    {
        foreach (var team in teams)
        {
            team.cube.GetComponent<MeshRenderer>().material.color = team.color;
        }
    }
}

[System.Serializable]
public class Team
{
    public string Name;
    public Color color = Color.white;
    public GameObject cube;
}

