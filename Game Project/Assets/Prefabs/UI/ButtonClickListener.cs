using UnityEngine;
using UnityEngine.UI;
public class ButtonClickListener : MonoBehaviour
{
    private Button button;
    private Upgrade upgrade;

    public UpgradeType buttonAction;
    private AudioSource audioSource;

    void Start()
    {
        button = GetComponent<Button>();
        upgrade = UpgradeManager.Instance.GetUpgrade(buttonAction);

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
            case UpgradeType.SPAWN_RATE:
                if (randomGenerator[0].period <= 0.2f)
                    return;
                break;
            case UpgradeType.PICKUP_SPEED:
                if (pickUpScript.pickupDuration <= 0.1f)
                    return;
                break;
            case UpgradeType.PICKUP_DELAY:
                if (pickUpScript.pickupCooldown <= 0.1f) return;
                break;
        }

        if (GameManager.Instance.PlayerBalance.Coins >= upgrade.PriceValue)
            GameManager.Instance.PlayerBalance.SubtractCoins(upgrade.PriceValue);
        else return;

        upgrade.PriceValue *= 1.15f;

        switch (buttonAction)
        {
            case UpgradeType.SPAWN_RATE:
                foreach (var item in randomGenerator)
                {
                    if (item.period - upgrade.UpgradeValue <= 0.2f)
                    {
                        item.period = 0.2f;
                    }
                    else
                    {
                        upgrade.Value -= upgrade.UpgradeValue;
                        item.period = upgrade.Value;
                    }
                }
                break;
            case UpgradeType.COIN_BONUS:
                upgrade.Value += upgrade.UpgradeValue;
                upgrade.UpgradeValue *= 1.05f;
                break;
            case UpgradeType.TRASH_SIZE:
                upgrade.Value += upgrade.UpgradeValue;
                foreach (var item in randomGenerator)
                {
                    //item.scale += 0.05f;
                }
                break;
            case UpgradeType.PLAYER_SPEED:
                upgrade.Value += upgrade.UpgradeValue;
                upgrade.UpgradeValue *= 1.1f;
                playerController.playerWalkSpeed = upgrade.Value;
                playerController.playerSprintSpeed = upgrade.Value + 1f;
                break;
            case UpgradeType.PICKUP_SPEED:
                if (upgrade.Value - upgrade.UpgradeValue <= 0.1f)
                {
                    pickUpScript.pickupDuration = 0.1f;
                }
                else
                {
                    upgrade.Value -= upgrade.UpgradeValue;
                    pickUpScript.pickupDuration = upgrade.Value;
                }
                break;
            case UpgradeType.PICKUP_DELAY:
                if (upgrade.Value - upgrade.UpgradeValue <= 0.1f)
                {
                    pickUpScript.pickupCooldown = 0.1f;
                }
                else
                {
                    upgrade.Value -= upgrade.UpgradeValue;
                    pickUpScript.pickupCooldown = upgrade.Value;
                }
                break;
            case UpgradeType.INVENTORY_SIZE:
                upgrade.Value += upgrade.UpgradeValue;
                GameManager.Instance.MAX_INVENTORY_SIZE = (int)upgrade.Value;
                break;
        }
        audioSource.PlayOneShot(audioSource.clip);
        upgrade.Level++;
        CardManagerScript.Instance.UpdateValues();
    }
}