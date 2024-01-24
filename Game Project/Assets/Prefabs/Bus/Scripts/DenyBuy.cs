using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DenyBuy : MonoBehaviour
{
    private Canvas canvasCar;
    private Canvas canvasHud;

	public void Start()
	{
        canvasHud = GameObject.Find("HUD").GetComponentInChildren<Canvas>();
        canvasCar = GameObject.Find("Bus").GetComponentInChildren<Canvas>();
	}
	public void Click()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        canvasCar.enabled = false;
        canvasHud.enabled = true;
	}
}
