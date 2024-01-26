using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class WaitToAppearButton : MonoBehaviour
{

	private Button button;
    void Start()
    {
		button = gameObject.GetComponentInChildren<Button>();
		StartCoroutine(Waiter());
	}
    IEnumerator Waiter()
    {
		button.gameObject.SetActive(false);
		yield return new WaitForSeconds(33);
		button.gameObject.SetActive(true);
	}
}
