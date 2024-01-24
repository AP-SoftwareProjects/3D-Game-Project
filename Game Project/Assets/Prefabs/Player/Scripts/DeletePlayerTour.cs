using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeletePlayerTour : MonoBehaviour
{
    private GameObject playerPlayable;
    private Canvas hud;
    void Start()
    {
        playerPlayable = GameObject.FindGameObjectsWithTag("Player").First();
        hud = GameObject.Find("HUD").GetComponentInChildren<Canvas>();
        playerPlayable.SetActive(false);
        hud.gameObject.SetActive(false);
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(22);
        Destroy(gameObject);
        playerPlayable.SetActive(true);
        hud.gameObject.SetActive(true);
    }
}
