using UnityEngine;
using UnityEngine.UI;
public class ButtonClickListener : MonoBehaviour
{
    private Button button;
    private CardScript card;
    public ButtonActions buttonAction;
    private AudioSource audioSource;

    void Start()
    {
        button = GetComponent<Button>();
        card = transform.parent.GetComponent<CardScript>();
        audioSource = GetComponent<AudioSource>();

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

        if (GameManager.Instance.PlayerBalance.Coins >= card.priceValue)
            GameManager.Instance.PlayerBalance.SubtractCoins(card.priceValue);
        else return;

        card.priceValue *= 1.5f;

        switch (buttonAction)
        {
            case ButtonActions.TRASH_SPAWN_RATE:
                foreach (var item in randomGenerator)
                {
                    if (item.period - card.upgradeValue <= 0.2f)
                    {
                        item.period = 0.2f;
                    }
                    else
                    {
                        card.value -= card.upgradeValue;
                        item.period = card.value;
                    }
                }
                break;
            case ButtonActions.TRASH_PRICE:
                card.value += card.upgradeValue;
                card.upgradeValue *= 1.05f;
                PickUpScript.ITEM_BONUS_VALUE = (int) card.value;
                break;
            case ButtonActions.TRASH_SIZE:
                card.value += card.upgradeValue;
                foreach (var item in randomGenerator)
                {
                    //item.scale += 0.05f;
                }
                break;
            case ButtonActions.PLAYER_MOVEMENT_SPEED:
                card.value += card.upgradeValue;
                card.upgradeValue *= 1.1f;
                playerController.playerWalkSpeed = card.value;
                playerController.playerSprintSpeed = card.value + 1f;
                break;
            case ButtonActions.TRASH_PICKUP_SPEED:
                if (card.value - card.upgradeValue <= 0.1f)
                {
                    pickUpScript.pickupDuration = 0.1f;
                }
                else
                {
                    card.value -= card.upgradeValue;
                    pickUpScript.pickupDuration = card.value;
                }
                break;
            case ButtonActions.TRASH_PICKUP_DELAY:
                if (card.value - card.upgradeValue <= 0.1f)
                {
                    pickUpScript.pickupCooldown = 0.1f;
                }
                else
                {
                    card.value -= card.upgradeValue;
                    pickUpScript.pickupCooldown = card.value;
                }
                break;
            case ButtonActions.INVENTORY_MAX_SIZE:
                card.value += card.upgradeValue;
                GameManager.Instance.MAX_INVENTORY_SIZE = (int) card.value;
                break;
        }
        audioSource.PlayOneShot(audioSource.clip);
        card.level++;
        CardManagerScript.Instance.UpdateValues();
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
