using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerCanvasScript : MonoBehaviour
{
    public bool countingUp = true;
    public float minCount = 0f;
    public float maxCount = 60f;
    private TextMeshProUGUI _counterText;

    private float currentTime;
    public bool autoDestroy = false;

    void Start()
    {
        currentTime = countingUp ? minCount : maxCount;

        GameObject textTransform = transform.Find("Time").gameObject;
        if (textTransform != null)
            _counterText = textTransform.GetComponent<TextMeshProUGUI>();

        UpdateCounterText();
    }

    void Update()
    {
        if (countingUp)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= maxCount)
            {
                currentTime = maxCount;
                countingUp = false;
            }
        }
        else
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= minCount)
            {
                currentTime = minCount;
                countingUp = true;

                if (autoDestroy)
                    RemoveCanvas();
            }
        }

        UpdateCounterText();
    }

    void UpdateCounterText()
    {
        int seconds = Mathf.FloorToInt(currentTime);
        int milliseconds = (int)Mathf.Floor(Mathf.FloorToInt((currentTime - seconds) * 1000f) / 100);

        string timeString = string.Format("{0}.{1}", seconds, milliseconds);

        if (_counterText != null)
            _counterText.text = timeString;
    }

    void RemoveCanvas()
    {
        Destroy(gameObject);
    }
}
