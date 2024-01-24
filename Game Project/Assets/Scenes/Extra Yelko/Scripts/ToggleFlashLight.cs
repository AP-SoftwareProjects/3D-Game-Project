using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleFlashLight : MonoBehaviour
{
	private Light flashlight;
	private bool isToggled = false;

	void Start()
	{
		flashlight = GetComponent<Light>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.F))
		{
			if (isToggled)
			{
				flashlight.intensity = 0;
				isToggled = false;
			}
			else
			{
				flashlight.intensity = 500;
				isToggled = true;
			}
		}
	}
}
