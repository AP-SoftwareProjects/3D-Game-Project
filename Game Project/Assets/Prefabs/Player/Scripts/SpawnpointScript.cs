using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnpointScript : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        player.transform.position = transform.position;
    }

    void Update()
    {
        
    }
}
