using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashcanHandler : MonoBehaviour
{
    public float detectionRadius = 5f; // Adjust this radius as needed
    public LayerMask playerLayer; // Assign the player's layer in the Unity editor
    public LayerMask objectLayer; // Assign the player's layer in the Unity editor
    public KeyCode interactionKey = KeyCode.E; // Define the interaction key
    private bool playerInRange;

    private void Update()
    {
        CheckPlayerInRange();

        if (playerInRange && Input.GetKeyDown(interactionKey))
        {
            InteractWithTrashcan();
        }
    }

    private void CheckPlayerInRange()
    {
        // Check if the player is within the detection radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, playerLayer);
        playerInRange = colliders.Length > 0;

        // Check if the player is looking at the trash can using a raycast
        if (playerInRange)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, objectLayer))
            {
                Debug.Log(hit.transform.name);
                // Check if the hit object is the trash can
                if (hit.collider.gameObject == gameObject)
                {
                    playerInRange = true;
                }
                else
                {
                    playerInRange = false;
                }
            }
            else
            {
                playerInRange = false;
            }
        }
    }

    private void InteractWithTrashcan()
    {
        // Perform interaction logic here
        Debug.Log("Player pressed '" + interactionKey + "' while looking at the trash can.");
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a wire sphere in the scene view to visualize the detection radius
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
