using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class DayNight : MonoBehaviour
{
    [SerializeField] private Light sun;
    [SerializeField] private Light moon;
    [SerializeField] private int rotationSpeed = 100;

    private void Update()
    {
        // Calculate rotation angle based on time and speed
        float rotationAngle = Time.deltaTime * rotationSpeed;

        // Rotate the sun and moon around the X-axis
        sun.transform.Rotate(Vector3.right, rotationAngle);
        moon.transform.Rotate(Vector3.right, rotationAngle);
    }
}
