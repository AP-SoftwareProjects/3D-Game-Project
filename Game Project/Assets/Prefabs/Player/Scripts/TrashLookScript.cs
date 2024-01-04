using Cinemachine;
using UnityEngine;

public class ActivateCanvasOnLook : MonoBehaviour
{
    public CinemachineVirtualCamera playerCamera;
    public Canvas trashCanvas;

    private PickUpScript _pickupScript;

    void Start()
    {
        _pickupScript = GetComponent<PickUpScript>();    
    }
    void Update()
    {
        
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit, Mathf.Infinity))
        {
            if (Vector3.Distance(playerCamera.transform.position, hit.point) <= _pickupScript.pickupRange)
                trashCanvas.gameObject.SetActive(hit.collider.CompareTag("Trash"));
            else
                trashCanvas.gameObject.SetActive(false);
        }
        else
            trashCanvas.gameObject.SetActive(false);
    }
}

