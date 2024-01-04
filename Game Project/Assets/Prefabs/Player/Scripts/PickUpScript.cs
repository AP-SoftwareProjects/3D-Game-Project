using Cinemachine;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public float pickupRange = 4f;
    public float pickupDuration = 3f;
    public float pickupCooldown = 2f;
    private float _pickupTimer = 0f;
    private float _cooldownTimer = 0f;

    private Animator _animator;
    [SerializeField] private CinemachineVirtualCamera _camera;
    private Camera _normalCamera;
    private GameObject _seenTrash;

    public GameObject trashPickupCanvasPrefab;
    public GameObject timerCanvasPrefab;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _normalCamera = _camera.GetComponent<Camera>();
    }

    void Update()
    {
        UpdateTimers();
        GameObject lookingTrash = GetLookingTrash();
        ManageTrashCanvas(lookingTrash);

        if (Input.GetKeyDown(KeyCode.E) && CanPickup(lookingTrash))
        {
            StartPickup(lookingTrash);
            SpawnTimer(lookingTrash);
        }

        if (IsPickingUp())
            ContinuePickup();
    }

    void UpdateTimers()
    {
        if (_cooldownTimer > 0f)
            _cooldownTimer -= Time.deltaTime;
        if (IsPickingUp())
            _pickupTimer -= Time.deltaTime;
    }

    bool CanPickup(GameObject lookingTrash)
    {
        return _cooldownTimer <= 0f && !PlayerManager.Instance.IsPicking && lookingTrash != null;
    }

    void StartPickup(GameObject trash)
    {
        PlayerManager.Instance.IsPicking = true;
        _animator.SetBool("PickingUp", true);
        _cooldownTimer = pickupDuration;
        _pickupTimer = pickupDuration;
    }

    void SpawnTimer(GameObject trash)
    {
        GameObject timerInstance = Instantiate(timerCanvasPrefab, trash.transform);
        ConfigureTimer(timerInstance, trash);
        ConfigureTimerLookAt(timerInstance, trash);
    }

    void ConfigureTimer(GameObject timerInstance, GameObject trash)
    {
        timerInstance.name = timerCanvasPrefab.name;
        timerInstance.transform.position = trash.transform.position;

        Canvas timerCanvas = timerInstance.GetComponent<Canvas>();
        if (timerCanvas != null)
        {
            timerCanvas.worldCamera = _normalCamera;

            TimerCanvasScript timerScript = timerInstance.GetComponent<TimerCanvasScript>();
            if (timerScript != null)
            {
                timerScript.countingUp = false;
                timerScript.minCount = 0f;
                timerScript.maxCount = pickupDuration;
                timerScript.autoDestroy = true;
            }
        }

        timerInstance.transform.localPosition = trash.transform.Find("Origin")?.localPosition ?? Vector3.zero;
    }

    void ConfigureTimerLookAt(GameObject timerInstance, GameObject trash)
    {
        LookAtTarget lookAtTargetScript = trash.AddComponent<LookAtTarget>();
        lookAtTargetScript.maxDistance = 3;
        lookAtTargetScript.hideGameobject = timerInstance;
    }

    void ManageTrashCanvas(GameObject lookingTrash)
    {
        if (lookingTrash != null && !PlayerManager.Instance.IsPicking)
        {
            Transform canvasTransform = lookingTrash.transform.Find(trashPickupCanvasPrefab.name);

            if (canvasTransform == null)
                SpawnTrashCanvas(lookingTrash);

            _seenTrash = lookingTrash;
        }
        else
            DestroyTrashCanvas();
    }

    void SpawnTrashCanvas(GameObject lookingTrash)
    {
        GameObject canvasInstance = Instantiate(trashPickupCanvasPrefab, lookingTrash.transform);
        canvasInstance.name = trashPickupCanvasPrefab.name;
        canvasInstance.transform.position = lookingTrash.transform.position;
        canvasInstance.GetComponent<Canvas>().worldCamera = _normalCamera;

        Vector3 origin = lookingTrash.transform.Find("Origin")?.localPosition ?? Vector3.zero;
        canvasInstance.transform.localPosition = origin;

        LookAtTarget lookAtTargetScript = lookingTrash.AddComponent<LookAtTarget>();
        lookAtTargetScript.maxDistance = 3;
        lookAtTargetScript.hideGameobject = canvasInstance;
    }

    void DestroyTrashCanvas()
    {
        if (_seenTrash != null)
        {
            Transform canvasTransform = _seenTrash.transform.Find(trashPickupCanvasPrefab.name);

            if (canvasTransform != null)
                Destroy(canvasTransform.gameObject);

            LookAtTarget lookAtTargetScript = _seenTrash.GetComponent<LookAtTarget>();
            if (lookAtTargetScript != null)
                Destroy(lookAtTargetScript);
        }
    }

    bool IsPickingUp()
    {
        return PlayerManager.Instance.IsPicking;
    }

    void ContinuePickup()
    {
        if (_pickupTimer <= 0f)
            FinishPickup();
    }

    void FinishPickup()
    {
        PickupTrash();
        PlayerManager.Instance.IsPicking = false;
        _animator.SetBool("PickingUp", false);
        _cooldownTimer = pickupCooldown;
        _pickupTimer = pickupDuration;
    }

    void PickupTrash()
    {
        DestroyTrash();
        GameManager.Instance.AddTrash(new(TrashItem.BinType.GREEN, 100));
    }

    void DestroyTrash()
    {
        Destroy(_seenTrash);
        _seenTrash = null;
    }

    GameObject GetLookingTrash()
    {
        Ray ray = _normalCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, pickupRange))
        {
            if (hit.collider.CompareTag("Trash"))
                return hit.collider.gameObject;
        }

        return null;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pickupRange);
    }
}
