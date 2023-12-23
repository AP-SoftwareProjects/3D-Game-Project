using UnityEngine;

public class TrashcanHandler : MonoBehaviour
{
    public LayerMask playerLayer;
    public LayerMask objectLayer;
    public KeyCode interactionKey = KeyCode.E;
    public Camera camera;
    public Canvas tagObject;
    public GameObject focusObject;
    public int tagDisplayRange = 5;

    public ParticleSystem particlePrefab;

    private bool _lookingAtTrashcan = false;

    void Update()
    {
        CheckPlayerInRange();

        if (_lookingAtTrashcan && Input.GetKeyDown(interactionKey))
        {
            InteractWithTrashcan();
        }
    }

    private void CheckPlayerInRange()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            _lookingAtTrashcan = hit.collider.gameObject.layer == LayerMask.NameToLayer("Trashcan");
        }

        if (Vector3.Distance(focusObject.transform.position, transform.position) < tagDisplayRange)
        {
            Vector3 directionToTarget = focusObject.transform.position - transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget, Vector3.up);

            rotationToTarget *= Quaternion.Euler(0f, 180f, 0f);
            tagObject.transform.rotation = rotationToTarget;

            tagObject.gameObject.SetActive(true);
        }
        else
        {
            tagObject.gameObject.SetActive(false);
        }
    }

    private void InteractWithTrashcan()
    {
        if (GameManager.Instance.TrashItems.Count <= 0) return;

        for (int i = 0; i < GameManager.Instance.TrashItems.Count; i++)
        {
            TrashItem trashItem = GameManager.Instance.TrashItems[i];
            GameManager.Instance.PlayerBalance.AddCoins(trashItem.Price);
        }
        GameManager.Instance.TrashItems.Clear();

        Vector3 spawnPosition = transform.position + new Vector3(0, 1.5f, 0);
        Quaternion spawnRotation = Quaternion.Euler(-90f, 0f, 0f);

        ParticleSystem spawnedParticles = Instantiate(particlePrefab, spawnPosition, spawnRotation, transform);
        spawnedParticles.transform.SetParent(transform);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, tagDisplayRange);
    }
}
