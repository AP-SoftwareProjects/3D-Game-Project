using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    [SerializeField] private Image uiFill;
    [SerializeField] private TextMeshProUGUI uiText;

    public int Duration;

    private int remainingDuration;

    public void Start()
    {
        Being(Duration);
    }
    private void Being(int Second)
    {
        remainingDuration = Second;
        StartCoroutine(UpdateTimer());
    }
    private IEnumerator UpdateTimer()
    {
        uiText.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
        uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
        remainingDuration--;
        yield return new WaitForSeconds(1f);
    }
    private void onEnd()
    {
        print("end");
    }
}
