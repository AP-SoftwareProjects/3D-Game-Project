using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardScript : MonoBehaviour
{
    public int priceValue;
    public int level = 1;
    public float value = 10;
    public float upgradeValue = 5;
    public TextMeshProUGUI priceText;

    private void Start()
    {
        this.priceText.text = priceValue.ToString();
    }
}
