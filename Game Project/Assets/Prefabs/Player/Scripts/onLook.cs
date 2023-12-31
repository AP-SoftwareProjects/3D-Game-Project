using UnityEngine;

public class ActivateCanvasOnLook : MonoBehaviour
{
    public Camera playerCamera; // Assign the player camera in the Unity Editor
    public Canvas trashCanvas; // Assign the Canvas in the Unity Editor

    void Update()
    {
        // Check if the player is looking at an object with the tag "Trash"
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Trash"))
            {
                // Activate the Canvas when looking at the "Trash" object
                trashCanvas.gameObject.SetActive(true);
            }
            else
            {
                // Deactivate the Canvas when not looking at the "Trash" object
                trashCanvas.gameObject.SetActive(false);
            }
        }
        else
        {
            // Deactivate the Canvas when not looking at any object
            trashCanvas.gameObject.SetActive(false);
        }
    }
}

