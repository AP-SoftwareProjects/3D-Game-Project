using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RandomGenerator : MonoBehaviour
{
    public GameObject[] myObjects;

    private GameObject trashObject;

    private Vector3 center;
    private Vector3 size;

    public static int MaxSpawnCounter = 50;
    public static int Counter = 0;

    private GameObject player;

    // Use this for initialization
    void Start()
    {
        center = gameObject.transform.position;
        size = gameObject.transform.localScale;
        player = GameObject.FindGameObjectWithTag("Player");
        if (GameObject.Find("===== TRASH =====") == null)
        {
            trashObject = new GameObject("===== TRASH =====");
            trashObject = GameObject.Find("===== TRASH =====");
        }
        else
            trashObject = GameObject.Find("===== TRASH =====");

        this.period = UpgradeManager.Instance.GetUpgrade(UpgradeType.SPAWN_RATE).Value;
    }

    private float nextActionTime = 0.0f;
    public float period = 10f;
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
        float distance = Vector3.Distance(player.transform.position, gameObject.transform.position);

        float rangeThreshold = 30f;
        if (distance < rangeThreshold)
        {
            int randomIndex = Random.Range(0, myObjects.Length);
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            Counter++;
            GameObject trashToSpawn = Instantiate(myObjects[randomIndex], pos, Quaternion.identity);
            trashToSpawn.transform.SetParent(trashObject.transform);
        }
    }
}
