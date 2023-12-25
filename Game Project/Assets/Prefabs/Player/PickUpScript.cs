using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public float interactionDistance = 2f; // Adjust the distance at which the player can interact with trash
    public string trashTag = "Trash"; // Set the tag for trash objects
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check for player input
        if (Input.GetKeyDown("E"))
        {
            // Check if player is close to a trash object
            if (IsCloseToTrash())
            {
                animator.SetBool("PickUp", true);
               
                InteractWithTrash();
            }
        }
        if (!Input.GetKey(KeyCode.E))
        {
            animator.SetBool("PickUp", false);
        }
    }

    bool IsCloseToTrash()
    {
        // Raycast to detect objects in front of the player
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance))
        {
            // Check if the hit object has the specified tag
            if (hit.collider.CompareTag(trashTag))
            {
                return true;
            }
        }

        return false;
    }

    void InteractWithTrash()
    {
        DestroyTrash();
    }

    void DestroyTrash()
    {
        // Destroy the trash object
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance))
        {
            Destroy(hit.collider.gameObject);
        }
    }
}
