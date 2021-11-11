using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> objects;
    public Vector3 spawnBox;
    public float spawnRate = 100;
    void Start()
    {

        for (int i = 0; i < spawnRate; i++)
        {
            var newObj = objects[Random.Range(0, objects.Count)]; //choose random animal from list
            var box = spawnBox / 2;
            var pos = new Vector3(Random.Range(-box.x, box.x), Random.Range(-box.y, box.y), Random.Range(-box.z, box.z)) + Vector3.up * 10;
            Instantiate(newObj, pos, newObj.transform.rotation, transform);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + Vector3.up * 10, spawnBox);
    }
}
