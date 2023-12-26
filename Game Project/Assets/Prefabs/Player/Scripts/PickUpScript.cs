using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

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
}
