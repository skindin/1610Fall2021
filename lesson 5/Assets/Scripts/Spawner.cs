using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner main;

    public List<GameObject> prefabs;
    public bool spawnObjects = true;

    public List<GameObject> liveObjects = new List<GameObject>();

    public float minHeight = 0;

    public float minSpawnInterval = .2f, maxSpawnInterval = 2f, minSpawnPos = -7, maxSpawnPos = 7, minLaunchForce = 10, maxLaunchForce = 50, maxLaunchAngle = 20;
    
    void Start()
    {
        if (main == null)
        {
            main = this;
        }
    }

    public IEnumerator SpawnNew (int mode)
    {
        while (spawnObjects)
        {
            var interval = Random.Range(minSpawnInterval, maxSpawnInterval) / mode;
            yield return new WaitForSeconds(interval);
            var prefab = prefabs[Random.Range(0, prefabs.Count)];

            var newPos = Vector3.right * Random.Range(minSpawnPos, maxSpawnPos);
            Debug.DrawLine(Vector3.right * minSpawnPos, Vector3.right * maxSpawnPos);

            var newObj = Instantiate(prefab, newPos, prefab.transform.rotation);
            liveObjects.Add(newObj);

            var rigBod = newObj.GetComponent<Rigidbody>();
            var angle = Random.Range(-maxLaunchAngle, maxLaunchAngle);
            var force = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.up * Random.Range(minLaunchForce, maxLaunchForce);
            rigBod.AddForce(force,ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        List<object> destroy = new();

        foreach (var obj in liveObjects)
        {
            if (obj != null)
            {
                if (obj.transform.position.y < minHeight)
                {
                    destroy.Add(obj);
                }
            }
        }

        foreach (GameObject obj in destroy)
        {
            liveObjects.Remove(obj);
            Destroy(obj);
        }
    }
}
