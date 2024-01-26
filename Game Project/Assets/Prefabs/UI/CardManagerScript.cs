using System;
using TMPro;
using UnityEngine;

public class CardManagerScript : MonoBehaviour
{
    private static CardManagerScript _instance;
    private UpgradeManager upgradeManager;

    public GameObject spawnRateContent;
    public GameObject inventorySizeContent;
    public GameObject trashPriceContent;
    public GameObject trashSizeContent;
    public GameObject playerSpeedContent;
    public GameObject pickupSpeedContent;
    public GameObject pickupDelayContent;

    void Start()
    {
        upgradeManager = UpgradeManager.Instance;
        UpdateValues();
    }

    public static CardManagerScript Instance
    {
        get
        {
            if (_instance == null)
                _instance = new();
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void UpdateValues()
    {
        LoadSpawnRate();
        LoadInventorySize();
        LoadTrashPrice();   
        LoadTrashSize();
        LoadPlayerSpeed();
        LoadPickupSpeed();
        LoadPickupDelay();
    }
    private void LoadSpawnRate()
    {
        Upgrade upgrade = upgradeManager.GetUpgrade(UpgradeType.SPAWN_RATE);

        TextMeshProUGUI title = spawnRateContent.transform.Find("Title Text").GetComponent<TextMeshProUGUI>();
        title.text = upgrade.Name;
        TextMeshProUGUI level = spawnRateContent.transform.Find("== LEVEL ==").Find("Level Text").GetComponent<TextMeshProUGUI>();
        
        level.text = $"Level {upgrade.Level}";
        TextMeshProUGUI currentlyText = spawnRateContent.transform.Find("Current Upgrade Text").Find("Currently Text").GetComponent<TextMeshProUGUI>();
        currentlyText.text = $"Currently: {Math.Round(upgrade.Value, 1)}s";
        TextMeshProUGUI upgradeNewText = spawnRateContent.transform.Find("Current Upgrade Text").Find("Value Text").GetComponent<TextMeshProUGUI>();
        upgradeNewText.text = $"- {Math.Round(upgrade.UpgradeValue, 1)}s";
        TextMeshProUGUI buyText = spawnRateContent.transform.Find("Buy Button").Find("Buy Text").GetComponent<TextMeshProUGUI>();
        buyText.text = $"{Math.Round(upgrade.PriceValue)}";
    }
    private void LoadInventorySize()
    {
        Upgrade upgrade = upgradeManager.GetUpgrade(UpgradeType.INVENTORY_SIZE);
       
        TextMeshProUGUI title = inventorySizeContent.transform.Find("Title Text").GetComponent<TextMeshProUGUI>();
        title.text = upgrade.Name;
        TextMeshProUGUI level = inventorySizeContent.transform.Find("== LEVEL ==").Find("Level Text").GetComponent<TextMeshProUGUI>();
        
        level.text = $"Level {upgrade.Level}";
        TextMeshProUGUI currentlyText = inventorySizeContent.transform.Find("Current Upgrade Text").Find("Currently Text").GetComponent<TextMeshProUGUI>();
        currentlyText.text = $"Currently: {Math.Round(upgrade.Value, 1)}";
        TextMeshProUGUI upgradeNewText = inventorySizeContent.transform.Find("Current Upgrade Text").Find("Value Text").GetComponent<TextMeshProUGUI>();
        upgradeNewText.text = $"+ {Math.Round(upgrade.UpgradeValue)}";
        TextMeshProUGUI buyText = inventorySizeContent.transform.Find("Buy Button").Find("Buy Text").GetComponent<TextMeshProUGUI>();
        buyText.text = $"{Math.Round(upgrade.PriceValue)}";
    }
    private void LoadTrashPrice()
    {
        Upgrade upgrade = upgradeManager.GetUpgrade(UpgradeType.COIN_BONUS);
       
        TextMeshProUGUI title = trashPriceContent.transform.Find("Title Text").GetComponent<TextMeshProUGUI>();
        title.text = upgrade.Name;
        TextMeshProUGUI level = trashPriceContent.transform.Find("== LEVEL ==").Find("Level Text").GetComponent<TextMeshProUGUI>();
        
        level.text = $"Level {upgrade.Level}";
        TextMeshProUGUI currentlyText = trashPriceContent.transform.Find("Current Upgrade Text").Find("Currently Text").GetComponent<TextMeshProUGUI>();
        currentlyText.text = $"Currently: €{Math.Round(upgrade.Value, 1)}";
        TextMeshProUGUI upgradeNewText = trashPriceContent.transform.Find("Current Upgrade Text").Find("Value Text").GetComponent<TextMeshProUGUI>();
        upgradeNewText.text = $"+ €{Math.Round(upgrade.UpgradeValue)}";
        TextMeshProUGUI buyText = trashPriceContent.transform.Find("Buy Button").Find("Buy Text").GetComponent<TextMeshProUGUI>();
        buyText.text = $"{Math.Round(upgrade.PriceValue)}";
    }
    private void LoadTrashSize()
    {
        Upgrade upgrade = upgradeManager.GetUpgrade(UpgradeType.TRASH_SIZE);
       
        TextMeshProUGUI title = trashSizeContent.transform.Find("Title Text").GetComponent<TextMeshProUGUI>();
        title.text = upgrade.Name;
        TextMeshProUGUI level = trashSizeContent.transform.Find("== LEVEL ==").Find("Level Text").GetComponent<TextMeshProUGUI>();
        
        level.text = $"Level {upgrade.Level}";
        TextMeshProUGUI currentlyText = trashSizeContent.transform.Find("Current Upgrade Text").Find("Currently Text").GetComponent<TextMeshProUGUI>();
        currentlyText.text = $"Currently: {Math.Round(upgrade.Value, 1)}";
        TextMeshProUGUI upgradeNewText = trashSizeContent.transform.Find("Current Upgrade Text").Find("Value Text").GetComponent<TextMeshProUGUI>();
        upgradeNewText.text = $"+ {Math.Round(upgrade.UpgradeValue, 1)}";
        TextMeshProUGUI buyText = trashSizeContent.transform.Find("Buy Button").Find("Buy Text").GetComponent<TextMeshProUGUI>();
        buyText.text = $"{Math.Round(upgrade.PriceValue)}";
    }
    private void LoadPlayerSpeed()
    {
        Upgrade upgrade = upgradeManager.GetUpgrade(UpgradeType.PLAYER_SPEED);
       
        TextMeshProUGUI title = playerSpeedContent.transform.Find("Title Text").GetComponent<TextMeshProUGUI>();
        title.text = upgrade.Name;
        TextMeshProUGUI level = playerSpeedContent.transform.Find("== LEVEL ==").Find("Level Text").GetComponent<TextMeshProUGUI>();
       
        level.text = $"Level {upgrade.Level}";
        TextMeshProUGUI currentlyText = playerSpeedContent.transform.Find("Current Upgrade Text").Find("Currently Text").GetComponent<TextMeshProUGUI>();
        currentlyText.text = $"Currently: {Math.Round(upgrade.Value, 1)}";
        TextMeshProUGUI upgradeNewText = playerSpeedContent.transform.Find("Current Upgrade Text").Find("Value Text").GetComponent<TextMeshProUGUI>();
        upgradeNewText.text = $"+ {Math.Round(upgrade.UpgradeValue, 1)}";
        TextMeshProUGUI buyText = playerSpeedContent.transform.Find("Buy Button").Find("Buy Text").GetComponent<TextMeshProUGUI>();
        buyText.text = $"{Math.Round(upgrade.PriceValue)}";
    }
    private void LoadPickupSpeed()
    {
        Upgrade upgrade = upgradeManager.GetUpgrade(UpgradeType.PICKUP_SPEED);
       
        TextMeshProUGUI title = pickupSpeedContent.transform.Find("Title Text").GetComponent<TextMeshProUGUI>();
        title.text = upgrade.Name;
        TextMeshProUGUI level = pickupSpeedContent.transform.Find("== LEVEL ==").Find("Level Text").GetComponent<TextMeshProUGUI>();
        
        level.text = $"Level {upgrade.Level}";
        TextMeshProUGUI currentlyText = pickupSpeedContent.transform.Find("Current Upgrade Text").Find("Currently Text").GetComponent<TextMeshProUGUI>();
        currentlyText.text = $"Currently: {Math.Round(upgrade.Value, 1)}s";
        TextMeshProUGUI upgradeNewText = pickupSpeedContent.transform.Find("Current Upgrade Text").Find("Value Text").GetComponent<TextMeshProUGUI>();
        upgradeNewText.text = $"- {Math.Round(upgrade.UpgradeValue, 1)}s";
        TextMeshProUGUI buyText = pickupSpeedContent.transform.Find("Buy Button").Find("Buy Text").GetComponent<TextMeshProUGUI>();
        buyText.text = $"{Math.Round(upgrade.PriceValue)}";
    }
    private void LoadPickupDelay()
    {
        Upgrade upgrade = upgradeManager.GetUpgrade(UpgradeType.PICKUP_DELAY);
       
        TextMeshProUGUI title = pickupDelayContent.transform.Find("Title Text").GetComponent<TextMeshProUGUI>();
        title.text = upgrade.Name;
        TextMeshProUGUI level = pickupDelayContent.transform.Find("== LEVEL ==").Find("Level Text").GetComponent<TextMeshProUGUI>();
        
        level.text = $"Level {upgrade.Level}";
        TextMeshProUGUI currentlyText = pickupDelayContent.transform.Find("Current Upgrade Text").Find("Currently Text").GetComponent<TextMeshProUGUI>();
        currentlyText.text = $"Currently: {Math.Round(upgrade.Value, 1)}s";
        TextMeshProUGUI upgradeNewText = pickupDelayContent.transform.Find("Current Upgrade Text").Find("Value Text").GetComponent<TextMeshProUGUI>();
        upgradeNewText.text = $"- {Math.Round(upgrade.UpgradeValue, 1)}s";
        TextMeshProUGUI buyText = pickupDelayContent.transform.Find("Buy Button").Find("Buy Text").GetComponent<TextMeshProUGUI>();
        buyText.text = $"{Math.Round(upgrade.PriceValue)}";
    }
}
