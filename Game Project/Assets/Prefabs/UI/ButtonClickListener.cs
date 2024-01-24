using UnityEngine;
using UnityEngine.UI;
public class ButtonClickListener : MonoBehaviour
{
    private Button button;
    private CardScript card;
    private int price;
    public ButtonActions buttonAction;
    private AudioSource audioSource;

    private const float PLAYER_WALK_INCREASE = 0.1f;
    private const float PLAYER_PICKUP_DECREASE = 0.1f;
    private const float PLAYER_PICKUP_COOLDOWN_DECREASE = 0.05f;
    void Start()
    {
        button = GetComponent<Button>();
        card = transform.parent.GetComponent<CardScript>();
        audioSource = GetComponent<AudioSource>();

        price = card.priceValue;
        if (button != null)
        {
            button.onClick.AddListener(OnClick);
        }
    }

    void OnClick()
    {
        PickUpScript pickUpScript = FindObjectOfType<PickUpScript>();
        PlayerController playerController = FindAnyObjectByType<PlayerController>();
        RandomGenerator[] randomGenerator = FindObjectsOfType<RandomGenerator>();

        switch (buttonAction)
        {
            case ButtonActions.TRASH_SPAWN_RATE:
                if (randomGenerator[0].period <= 0.2f)
                    return;
                break;
            case ButtonActions.TRASH_PICKUP_SPEED:
                if (pickUpScript.pickupDuration <= 0.1f)
                    return;
                break;
            case ButtonActions.TRASH_PICKUP_DELAY:
                if (pickUpScript.pickupCooldown <= 0.1f) return;
                break;
        }

        if (GameManager.Instance.PlayerBalance.Coins >= price)
            GameManager.Instance.PlayerBalance.SubtractCoins(price);
        else return;

        switch (buttonAction)
        {
            case ButtonActions.TRASH_SPAWN_RATE:
                foreach (var item in randomGenerator)
                {
                    if (item.period - 0.2f <= 0.2f)
                    {
                        item.period = 0.2f;
                    }
                    else
                        item.period -= 0.2f;
                }
                break;
            case ButtonActions.TRASH_PRICE:
                PickUpScript.ITEM_BONUS_VALUE += 10;
                break;
            case ButtonActions.TRASH_SIZE:
                foreach (var item in randomGenerator)
                {
                    //item.scale += 0.05f;
                }
                break;
            case ButtonActions.PLAYER_MOVEMENT_SPEED:
                playerController.playerWalkSpeed += PLAYER_WALK_INCREASE;
                playerController.playerSprintSpeed += PLAYER_WALK_INCREASE;
                break;
            case ButtonActions.TRASH_PICKUP_SPEED:
                if (pickUpScript.pickupDuration - PLAYER_PICKUP_DECREASE <= 0.1f)
                {
                    pickUpScript.pickupCooldown = 0.1f;
                }
                else pickUpScript.pickupDuration -= 0.1f;
                break;
            case ButtonActions.TRASH_PICKUP_DELAY:
                if (pickUpScript.pickupCooldown - PLAYER_PICKUP_COOLDOWN_DECREASE <= 0.1f)
                {
                    pickUpScript.pickupCooldown = 0.1f;
                }
                else
                    pickUpScript.pickupCooldown -= 0.05f;
                break;
            case ButtonActions.INVENTORY_MAX_SIZE:
                GameManager.Instance.MAX_INVENTORY_SIZE += 10;
                break;
        }
        audioSource.PlayOneShot(audioSource.clip);
    }
}


public enum ButtonActions
{
    TRASH_SPAWN_RATE,
    TRASH_PRICE,
    TRASH_SIZE,
    PLAYER_MOVEMENT_SPEED,
    TRASH_PICKUP_SPEED,
    TRASH_PICKUP_DELAY,
    INVENTORY_MAX_SIZE
}
