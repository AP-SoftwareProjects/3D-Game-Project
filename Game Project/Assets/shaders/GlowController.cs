using UnityEngine;

public class PlayerGlowController : MonoBehaviour
{
    private Renderer lastHitRenderer; // Store the last hit object's renderer
    private Material defaultMaterial;

    public Material glowingMaterial; // Assign this in the Unity Editor
    public string glowTag = "Trash"; // Set the tag you want to trigger the glow effect

    void Start()
    {
        // Get and store the default material of the object
        lastHitRenderer = GetComponent<Renderer>();
        if (lastHitRenderer != null)
        {
            defaultMaterial = lastHitRenderer.material;
        }
        else
        {
            Debug.LogError("Renderer not found on the object. Ensure the object has a Renderer component.");
        }
    }

    void Update()
    {
        // Check if glowingMaterial is assigned
        if (glowingMaterial == null)
        {
            Debug.LogError("Glowing material is not assigned. Please assign it in the Unity Editor.");
            return;
        }

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            // Check if the object being looked at has the specified tag
            if (hit.collider.gameObject.CompareTag(glowTag))
            {
                // When looking at an object with the specified tag, apply the glowing material
                if (lastHitRenderer != null)
                {
                    lastHitRenderer.material = defaultMaterial; // Revert the last hit renderer to default material
                }

                lastHitRenderer = hit.collider.gameObject.GetComponent<Renderer>();
                lastHitRenderer.material = glowingMaterial;
            }
        }
        else if (lastHitRenderer != null)
        {
            // If not looking at any object, and there's a previous hit, revert to the default material
            lastHitRenderer.material = defaultMaterial;
            lastHitRenderer = null;
        }
    }
}
