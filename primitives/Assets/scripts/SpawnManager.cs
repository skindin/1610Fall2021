using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    public List<GameObject> enemies = new List<GameObject>();
    public float spawnRadius = 2;
    public float spawnHeight = 5;
    public int wave = 1;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        List<GameObject> remove = new List<GameObject> ();
        foreach (var obj in enemies)
        {
            if (obj != null && obj.transform.position.y < -20)
            {
                remove.Add(obj);
            }
        }
        foreach (var obj in remove)
        {
            enemies.Remove(obj);
            Destroy(obj, 5);
        }

        if (enemies.Count == 0)
        {
            for (var i = 0; i < wave; i++)
            {
                enemies.Add(SpawnNew(enemyPrefab));
            }
            SpawnNew(powerUpPrefab);
            wave++;
        }
    }

    GameObject SpawnNew (GameObject prefab)
    {
        var newObj = Instantiate(prefab, randomPoint() + Vector3.up * spawnHeight, Quaternion.identity);
        return newObj;
    }

    Vector3 randomPoint ()
    {
        Vector3 point = Random.insideUnitCircle * spawnRadius;
        point = new Vector3(point.x, 0, point.y);
        return point;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Vector3.up * spawnHeight, spawnRadius);
    }
}
