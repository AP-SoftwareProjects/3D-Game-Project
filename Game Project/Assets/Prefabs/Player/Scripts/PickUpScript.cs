using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;

public class PickUpScript : MonoBehaviour
{
    public float pickupRange = 5f;
    private string _trashTag = "Trash";
    private Animator _animator;

    public float pickupDuration = 1f;
    private float _pickupTimer = 0f;

    public float pickupCooldown = 2f;
    private float _cooldownTimer = 0f;

    private GameObject _trashObject;
    static private Timer timer = new Timer();


    public GameObject prefabToInstantiate; // prefab
    void Start()
    {
        _animator = GetComponent<Animator>();


    }

    void Update()
    {
        if (_cooldownTimer > 0f)
            _cooldownTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.E) && _cooldownTimer <= 0f && !PlayerManager.Instance.IsPicking)
        {
            if (IsCloseToTrash())
            {

                PlayerManager.Instance.IsPicking = true;
                _animator.SetBool("PickingUp", true);

                _cooldownTimer = pickupDuration;
                _pickupTimer = pickupDuration;

               
                GameObject newPrefabInstance = Instantiate(prefabToInstantiate,_trashObject.transform);
                newPrefabInstance.transform.parent = transform;
                newPrefabInstance.transform.position = new Vector3(0f, 0f, 0f);
                newPrefabInstance.transform.rotation = Quaternion.identity;
                //timer.Start();


                //   Vector3 directionToTarget = focusObject.transform.position - transform.position;
                // Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget, Vector3.up);

                //    rotationToTarget *= Quaternion.Euler(0f, 180f, 0f);
                //  tagObject.transform.rotation = rotationToTarget;

            }

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

    bool IsCloseToTrash()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, pickupRange))
        {
            if (hit.collider.CompareTag(_trashTag))
            {
                _trashObject = hit.collider.gameObject;
                return true;
            }
        }
        return false;
    }

    void PickupTrash()
    {
        DestroyTrash();
        GameManager.Instance.AddTrash(new(TrashItem.BinType.GREEN, 100));
    }

    void DestroyTrash()
    {
        Destroy(_trashObject);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pickupRange);
    }
    

    //timer code
}
