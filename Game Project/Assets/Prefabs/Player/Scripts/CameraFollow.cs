using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 18f;
    public float rotationSpeed = 2f;
    public float minVerticalAngle = -80f; // Minimum vertical angle (looking down)
    public float maxVerticalAngle = 80f;  // Maximum vertical angle (looking up)
    public Vector3 defaultOffset = new Vector3(0f, 0.65f, 0f);
    public Vector3 thirdPersonOffset = new Vector3(0f, 1.5f, -3f);

    private Vector3 currentOffset;
    private Camera mainCamera;

    private float verticalRotation = 0f;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
        currentOffset = defaultOffset;
    }

    void LateUpdate()
    {
        if (target == null)
            return;

        if (Input.GetKeyDown(KeyCode.F5))
        {
            currentOffset = (currentOffset == defaultOffset) ? thirdPersonOffset : defaultOffset;

            mainCamera.cullingMask = (currentOffset == thirdPersonOffset) ?
                (mainCamera.cullingMask | (1 << LayerMask.NameToLayer("PlayerBody"))) :
                (mainCamera.cullingMask & ~(1 << LayerMask.NameToLayer("PlayerBody")));
        }

        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;

        if (currentOffset == thirdPersonOffset)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, currentOffset, smoothSpeed * Time.deltaTime);

            verticalRotation -= Input.GetAxis("Mouse Y") * rotationSpeed;
            verticalRotation = Mathf.Clamp(verticalRotation, minVerticalAngle, maxVerticalAngle);

            // Apply vertical rotation to the camera
            transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

            target.Rotate(Vector3.up * mouseX);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, defaultOffset, smoothSpeed * Time.deltaTime);
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;
            transform.Rotate(Vector3.left * mouseY);
            target.Rotate(Vector3.up * mouseX);
        }
    }
}
