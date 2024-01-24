using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeCalculator : MonoBehaviour
{
    public Transform playerTransform;
    public Transform zoneTransform;

    void Update()
    {
        // Calculate the distance between player and zone
        float distance = Vector3.Distance(playerTransform.position, zoneTransform.position);

        // Print the distance to the console (you can replace this with your logic)
        Debug.Log("Distance between player and zone: " + distance);

        // Example: Check if the player is within a certain range from the zone
        float rangeThreshold = 10f; // Set your desired range threshold
        if (distance < rangeThreshold)
        {
            Debug.Log("Player is within range of the zone!");
            // Add your logic here for what should happen when the player is within range
        }
    }
}
