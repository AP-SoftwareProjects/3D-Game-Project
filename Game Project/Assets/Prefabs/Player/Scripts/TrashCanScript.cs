using Cinemachine;
using UnityEngine;

public class TrashCanScript : MonoBehaviour
{
    public float interactionRange = 2f;
    public KeyCode interactionKey = KeyCode.E;
    public ParticleSystem particlePrefab;

    private GameObject _currentTrashCan;

    [SerializeField] private CinemachineVirtualCamera _camera;
    private Camera _normalCamera;
    void Start()
    {
        _normalCamera = _camera.GetComponent<Camera>();
    }

    void Update()
    {
        _currentTrashCan = GetLookingTrashcan();
        if (_currentTrashCan != null && Input.GetKeyDown(interactionKey))
            InteractTrashcan();
    }

    GameObject GetLookingTrashcan()
    {
        Ray ray = _normalCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, interactionRange))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Trashcan"))
                return hit.collider.gameObject;
        }

        return null;
    }
    private void InteractTrashcan()
    {
        if (GameManager.Instance.TrashItems.Count <= 0) return;

        for (int i = 0; i < GameManager.Instance.TrashItems.Count; i++)
        {
            TrashItem trashItem = GameManager.Instance.TrashItems[i];
            GameManager.Instance.PlayerBalance.AddCoins(trashItem.Price);
        }
        GameManager.Instance.TrashItems.Clear();

        Vector3 spawnPosition = _currentTrashCan.transform.position + new Vector3(0, 1.5f, 0);
        Quaternion spawnRotation = Quaternion.Euler(-90f, 0f, 0f);

        ParticleSystem spawnedParticles = Instantiate(particlePrefab, spawnPosition, spawnRotation, _currentTrashCan.transform);
        spawnedParticles.transform.SetParent(_currentTrashCan.transform);
    }
}
