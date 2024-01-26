using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AcceptBuy : MonoBehaviour
{
	public string levelName = "";
	public int amountToPay;
	private Canvas canvasHud;

	[SerializeField] private TextMeshProUGUI priceText;

    private void Start()
    {
		priceText.text = amountToPay.ToString();
    }

    public void Click()
    {
        canvasHud = GameObject.Find("HUD").GetComponentInChildren<Canvas>();
        //Check coins
        //remove coins
        if (GameManager.Instance.CheckMoneyAndSubstract(amountToPay))
		{
			RandomGenerator.Counter = 0;
			SceneManager.LoadScene(levelName);
			Time.timeScale = 1;
            if (levelName == "EndMenu")
                canvasHud.enabled = false;
            else
                canvasHud.enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            return;
		}
		return;
	}
}
