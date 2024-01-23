using UnityEngine;

public class FlashlightFollow : MonoBehaviour
{
	public Camera mainCamera;

	// Update is called once per frame
	void Update()
    {
		if (mainCamera != null)
		{
			// Set the spotlight position to be in front of the camera
			transform.position = mainCamera.transform.position + mainCamera.transform.forward;

			// Look at the camera
			transform.LookAt(mainCamera.transform);
		}
	}
}
