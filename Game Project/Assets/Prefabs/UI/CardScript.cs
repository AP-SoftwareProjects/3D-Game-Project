using UnityEngine;
using UnityEngine.UI;

public class CardScript : MonoBehaviour
{

    public string title;
    public Sprite iconImg;
    public int priceValue;


    private void Start()
    {
        this.transform.Find("TRASH_SPAWN_TEXT").GetComponent<Text>().text = title;
        this.transform.Find("TRASH_SPAWN_ICON").GetComponent<Image>().sprite = iconImg;
        this.transform.Find("BUY_BUTTON").Find("BUY_BUTTON_TEXT").GetComponent<Text>().text = priceValue.ToString();

    }
}
