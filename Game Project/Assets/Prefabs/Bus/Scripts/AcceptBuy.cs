using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AcceptBuy : MonoBehaviour
{
	public string levelName = "";
	public int amountToPay;

	[SerializeField] private TextMeshProUGUI priceText;

    private void Start()
    {
		priceText.text = amountToPay.ToString();
    }

    public void Click()
    {
		//Check coins
		//remove coins
		if (GameManager.Instance.CheckMoneyAndSubstract(amountToPay))
		{
			SceneManager.LoadScene(levelName);
			Time.timeScale = 1;
			Cursor.visible = false;
			return;
		}
		return;
	}
}
