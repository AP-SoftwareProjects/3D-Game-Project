using UnityEngine;
using UnityEngine.UI;
public class ButtonClickListener : MonoBehaviour
{
    private Button button;
    private CardScript card;
    private int price;
    public ButtonActions buttonAction;
    void Start()
    {
        button = GetComponent<Button>();
        card = transform.parent.GetComponent<CardScript>();

        price = card.priceValue;
        if (button != null)
        {
            button.onClick.AddListener(OnClick);
        }
    }

    void OnClick()
    {
        if (GameManager.Instance.PlayerBalance.Coins >= price)
            GameManager.Instance.PlayerBalance.SubtractCoins(price);
        else return;

        PickUpScript pickUpScript = FindObjectOfType<PickUpScript>();
        PlayerController playerController = FindAnyObjectByType<PlayerController>();
        switch (buttonAction)
        {
            case ButtonActions.TRASH_SPAWN_RATE:
                break;
            case ButtonActions.TRASH_DENSITY:
                break;
            case ButtonActions.TRASH_PRICE:
                break;
            case ButtonActions.TRASH_SIZE:
                break;
            case ButtonActions.PLAYER_MOVEMENT_SPEED:
                playerController.playerWalkSpeed += 0.1f;
                playerController.playerSprintSpeed += 0.1f;
                break;
            case ButtonActions.TRASH_PICKUP_SPEED:
                pickUpScript.pickupDuration -= 0.1f;
                break;
            case ButtonActions.TRASH_PICKUP_DELAY:
                pickUpScript.pickupCooldown -= 0.05f;
                break;
            case ButtonActions.INVENTORY_MAX_SIZE:
                GameManager.Instance.MAX_INVENTORY_SIZE += 25;
                break;
        }
    }
}


public enum ButtonActions
{
    TRASH_SPAWN_RATE,
    TRASH_DENSITY,
    TRASH_PRICE,
    TRASH_SIZE,
    PLAYER_MOVEMENT_SPEED,
    TRASH_PICKUP_SPEED,
    TRASH_PICKUP_DELAY,
    INVENTORY_MAX_SIZE
}
