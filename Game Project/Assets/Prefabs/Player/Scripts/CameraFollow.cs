using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 18f;
    public float cameraSmoothSpeed = 10f;
    private Vector3 defaultOffset;
    public Vector3 thirdPersonOffset = new Vector3(0f, 4f, -3f);

    private bool isFirstPerson = true;
    private Camera mainCamera;

    void Start()
    {
        defaultOffset = transform.localPosition;
        mainCamera = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 desiredPosition = isFirstPerson ? defaultOffset : thirdPersonOffset;
        if (isFirstPerson)
            transform.position = Vector3.Lerp(transform.position, target.position, cameraSmoothSpeed * Time.deltaTime);
        else
            transform.localPosition = Vector3.Lerp(transform.localPosition, desiredPosition, smoothSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.F5))
            isFirstPerson = !isFirstPerson;

        mainCamera.cullingMask = !isFirstPerson ?
          (mainCamera.cullingMask | (1 << LayerMask.NameToLayer("PlayerBody"))) :
          (mainCamera.cullingMask & ~(1 << LayerMask.NameToLayer("PlayerBody")));
    }
}
