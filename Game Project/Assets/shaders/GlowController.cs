using UnityEngine;

public class PlayerGlowController : MonoBehaviour
{
    private Renderer lastHitRenderer;
    private Material defaultMaterial;

    public Material glowingMaterial;
    public string glowTag = "Trash";

    void Start()
    {
        lastHitRenderer = GetComponent<Renderer>();
        if (lastHitRenderer != null)
            defaultMaterial = lastHitRenderer.material;
    }

    void Update()
    {
        if (glowingMaterial == null) return;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag(glowTag))
            {
                if (lastHitRenderer != null)
                    lastHitRenderer.material = defaultMaterial;

                lastHitRenderer = hit.collider.gameObject.GetComponent<Renderer>();
                lastHitRenderer.material = glowingMaterial;
            }
        }
        else if (lastHitRenderer != null)
        {
            lastHitRenderer.material = defaultMaterial;
            lastHitRenderer = null;
        }
    }
}
