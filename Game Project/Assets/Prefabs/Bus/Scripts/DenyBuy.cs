using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DenyBuy : MonoBehaviour
{
    private Canvas canvasCar;
    private Canvas canvasHud;

	public void Start()
	{
	}
	public void Click()
    {
        canvasCar = GameObject.Find("Bus").GetComponentInChildren<Canvas>();
        canvasHud = GameObject.Find("HUD").GetComponentInChildren<Canvas>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Time.timeScale = 1;
        canvasCar.enabled = false;
        canvasHud.enabled = true;
    }
}
