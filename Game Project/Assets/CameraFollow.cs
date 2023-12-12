using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public float smoothSpeed = 18f;
    public Vector3 offset = new Vector3(0f, 0.65f, 0f);

    void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 desiredPosition = target.position + offset;

        // Smoothly interpolate the camera's position and rotation towards the target
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }
}
