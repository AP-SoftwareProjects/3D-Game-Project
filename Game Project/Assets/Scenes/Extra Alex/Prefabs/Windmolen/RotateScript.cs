using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector3 rotateSpeed;
    [SerializeField] private GameObject targetObject;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rotationDelta = Quaternion.Euler(rotateSpeed * Time.deltaTime);

        // Apply the rotation to the localRotation of the targetObject
        targetObject.transform.localRotation *= rotationDelta;
    }
}
