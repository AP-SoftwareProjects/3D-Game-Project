using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DenyBuy : MonoBehaviour
{
    public Canvas canvasCar;
    public Canvas canvasHud;
    public void Click()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        canvasCar.enabled = false;
        canvasHud.enabled = true;

	}
}
