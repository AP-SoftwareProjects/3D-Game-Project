using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerator : MonoBehaviour
{
    public GameObject[] myObjects;
    public int maxSpawnCount;
    private int currentSpawnCount = 0;

    private Vector3 center;
    private Vector3 size;

    // Use this for initialization
    void Start()
    {
        SpawnGarbage();
        currentSpawnCount++;
        center = gameObject.transform.localPosition;
        size = gameObject.transform.localPosition;
    }

    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    // Update is called once per frame
    public void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            if (currentSpawnCount < maxSpawnCount)
            {
                SpawnGarbage();
                currentSpawnCount++;
            }
        }
    }

    public void SpawnGarbage()
    {
        int randomIndex = Random.Range(0, myObjects.Length);
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        Instantiate(myObjects[randomIndex], pos, Quaternion.identity);
    }


    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
