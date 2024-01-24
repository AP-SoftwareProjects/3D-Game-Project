using UnityEngine;

public class FlashlightFollow : MonoBehaviour
{
	public Camera mainCamera;

	// Update is called once per frame
	void Update()
    {
		if (mainCamera != null)
		{
			transform.position = mainCamera.transform.position + mainCamera.transform.forward;

			transform.LookAt(mainCamera.transform);
		}
	}
}
