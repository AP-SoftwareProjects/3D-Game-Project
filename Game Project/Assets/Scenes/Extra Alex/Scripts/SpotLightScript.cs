using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class SpotLightScript : MonoBehaviour
{
    public Light flickeringLight; // Reference to the Light component
    public float intensityMultiplier = 1.0f; // Intensity multiplier for the flickering effect
    public float frequency = 2.0f; // Frequency of the flickering effect
    public float startDelay = 2.0f; // Start delay in seconds

    private float time = 0f;
    private float delayTimer = 0f;

    void Start()
    {
        if (flickeringLight == null)
            flickeringLight = GetComponent<Light>();

        if (flickeringLight == null)
            Debug.LogError("Light component not found. Please assign a Light component to the script.");

        delayTimer = startDelay;
    }

    void Update()
    {
        if (delayTimer > 0f)
        {
            // Decrement the start delay timer
            delayTimer -= Time.deltaTime;
        }
        else if (flickeringLight != null)
        {
            // Calculate the intensity based on a sine function
            float flickerIntensity = Mathf.Abs(Mathf.Sin(2 * Mathf.PI * frequency * time)) * intensityMultiplier;

            // Apply the calculated intensity to the light
            flickeringLight.intensity = flickerIntensity;

            // Increment the time variable
            time += Time.deltaTime;
        }
    }
}
