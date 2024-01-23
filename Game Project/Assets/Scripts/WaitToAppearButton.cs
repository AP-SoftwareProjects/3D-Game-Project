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
		Debug.Log("Deactivating GameObject");
		button.gameObject.SetActive(false);

		yield return new WaitForSeconds(33);

		Debug.Log("Activating GameObject after 2 seconds");
		button.gameObject.SetActive(true);
	}
}
