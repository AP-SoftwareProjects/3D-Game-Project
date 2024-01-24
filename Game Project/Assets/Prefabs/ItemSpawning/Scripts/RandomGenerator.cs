using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RandomGenerator : MonoBehaviour
{
    public GameObject[] myObjects;

    private Vector3 center;
    private Vector3 size;
    public float scale = 1f;

    public static int MaxSpawnCounter = 10;
    public static int Counter = 0;

    // Use this for initialization
    void Start()
    {
        center = gameObject.transform.position;
        size = gameObject.transform.localScale;
    }

    private float nextActionTime = 0.0f;
    public float period = 1f;
    // Update is called once per frame
    public void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            if(Counter <= MaxSpawnCounter)
            {
                SpawnGarbage();
            }
        }
    }

    public void SpawnGarbage()
    {
        int randomIndex = Random.Range(0, myObjects.Length);
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        Counter++;
        Debug.Log(Counter);
        Instantiate(myObjects[randomIndex], pos, Quaternion.identity);
    }
}
