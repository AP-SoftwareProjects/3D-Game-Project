using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;

public class PickUpScript : MonoBehaviour
{
    public float pickupRange = 4f;
    private string _trashTag = "Trash";
    private Animator _animator;

    public float pickupDuration = 3f;
    private float _pickupTimer = 0f;

    public float pickupCooldown = 2f;
    private float _cooldownTimer = 0f;

    static private Timer timer = new Timer();
    private Camera _camera;

    private GameObject _seenTrash;
    public GameObject trashPickupCanvasPrefab;
    public GameObject timerCanvasPrefab;

    void Start()
    {
        _animator = GetComponent<Animator>();

        Transform childCamera = transform.Find("Camera");
        if (childCamera != null)
            _camera = childCamera.GetComponent<Camera>();

    }

    void Update()
    {
        if (_cooldownTimer > 0f)
            _cooldownTimer -= Time.deltaTime;

        GameObject lookingTrash = GetLookingTrash();

        ManageTrashCanvas(lookingTrash);

        if (Input.GetKeyDown(KeyCode.E) &&
            _cooldownTimer <= 0f &&
            !PlayerManager.Instance.IsPicking &&
            lookingTrash != null)
        {
            PlayerManager.Instance.IsPicking = true;
            _animator.SetBool("PickingUp", true);

            _cooldownTimer = pickupDuration;
            _pickupTimer = pickupDuration;

            GameObject timerInstance = Instantiate(timerCanvasPrefab, lookingTrash.transform);
            timerInstance.name = timerCanvasPrefab.name;
            timerInstance.transform.position = lookingTrash.transform.position;

            Canvas timerCanvas = timerInstance.GetComponent<Canvas>();
            if (timerCanvas != null)
            {
                timerCanvas.worldCamera = _camera;

                TimerCanvasScript timerScript = timerInstance.GetComponent<TimerCanvasScript>();
                if (timerScript != null)
                {
                    timerScript.countingUp = false;
                    timerScript.minCount = 0f;
                    timerScript.maxCount = pickupDuration;
                    timerScript.autoDestroy = true;
                }
            }

            Vector3 origin = new Vector3(0, 0, 0);
            Transform originTransform = lookingTrash.transform.Find("Origin");
            if (originTransform != null)
                origin = originTransform.localPosition;

            timerInstance.transform.localPosition = origin;

            LookAtTarget lookAtTargetScript = lookingTrash.AddComponent<LookAtTarget>();
            lookAtTargetScript.Start(3, timerInstance);
        }


        if (PlayerManager.Instance.IsPicking)
        {
            _pickupTimer -= Time.deltaTime;

            if (_pickupTimer <= 0f)
            {
                PickupTrash();
                PlayerManager.Instance.IsPicking = false;
                _animator.SetBool("PickingUp", false);

                _cooldownTimer = pickupCooldown;
                _pickupTimer = pickupDuration;
            }
        }
    }
    private void ManageTrashCanvas(GameObject lookingTrash)
    {
        if (lookingTrash != null && !PlayerManager.Instance.IsPicking)
        {
            Transform canvasTransform = lookingTrash.transform.Find(trashPickupCanvasPrefab.name);

            if (canvasTransform == null)
            {
                GameObject canvasInstance = Instantiate(trashPickupCanvasPrefab, lookingTrash.transform);
                canvasInstance.name = trashPickupCanvasPrefab.name;
                canvasInstance.transform.position = lookingTrash.transform.position;
                canvasInstance.GetComponent<Canvas>().worldCamera = _camera;

                Vector3 origin = new (0, 0, 0);
                if (lookingTrash.transform.Find("Origin"))
                    origin = lookingTrash.transform.Find("Origin").transform.localPosition;

                canvasInstance.transform.localPosition = origin;

                LookAtTarget lookAtTargetScript = lookingTrash.AddComponent<LookAtTarget>();
                lookAtTargetScript.Start(3, canvasInstance);
            }

            _seenTrash = lookingTrash;
        }
        else
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
    }
    private GameObject GetLookingTrash()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, pickupRange))
        {
            if (hit.collider.CompareTag("Trash"))
                return hit.collider.gameObject;
        }
        return null;
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
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pickupRange);
    }
    

    //timer code
}
