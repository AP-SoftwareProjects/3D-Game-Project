using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardManagerScript : MonoBehaviour
{
    private static CardManagerScript _instance;

    public GameObject spawnRateContent;
    public GameObject inventorySizeContent;
    public GameObject trashPriceContent;
    public GameObject trashSizeContent;
    public GameObject playerSpeedContent;
    public GameObject pickupSpeedContent;
    public GameObject pickupDelayContent;

    void Start()
    {
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
        TextMeshProUGUI title = spawnRateContent.transform.Find("Title Text").GetComponent<TextMeshProUGUI>();
        title.text = "Spawn Rate";
        TextMeshProUGUI level = spawnRateContent.transform.Find("== LEVEL ==").Find("Level Text").GetComponent<TextMeshProUGUI>();
        CardScript cardScript = spawnRateContent.GetComponent<CardScript>();
        level.text = $"Level {cardScript.level}";
        TextMeshProUGUI currentlyText = spawnRateContent.transform.Find("Current Upgrade Text").Find("Currently Text").GetComponent<TextMeshProUGUI>();
        currentlyText.text = $"Currently: {cardScript.value}s";
        TextMeshProUGUI upgradeNewText = spawnRateContent.transform.Find("Current Upgrade Text").Find("Value Text").GetComponent<TextMeshProUGUI>();
        upgradeNewText.text = $"- {cardScript.upgradeValue}s";
        TextMeshProUGUI buyText = spawnRateContent.transform.Find("Buy Button").Find("Buy Text").GetComponent<TextMeshProUGUI>();
        buyText.text = $"{cardScript.priceValue}s";
    }
    private void LoadInventorySize()
    {
        TextMeshProUGUI title = inventorySizeContent.transform.Find("Title Text").GetComponent<TextMeshProUGUI>();
        title.text = "Inventory Size";
        TextMeshProUGUI level = inventorySizeContent.transform.Find("== LEVEL ==").Find("Level Text").GetComponent<TextMeshProUGUI>();
        CardScript cardScript = inventorySizeContent.GetComponent<CardScript>();
        level.text = $"Level {cardScript.level}";
        TextMeshProUGUI currentlyText = inventorySizeContent.transform.Find("Current Upgrade Text").Find("Currently Text").GetComponent<TextMeshProUGUI>();
        currentlyText.text = $"Currently: {cardScript.value}";
        TextMeshProUGUI upgradeNewText = inventorySizeContent.transform.Find("Current Upgrade Text").Find("Value Text").GetComponent<TextMeshProUGUI>();
        upgradeNewText.text = $"+ {cardScript.upgradeValue}";
        TextMeshProUGUI buyText = inventorySizeContent.transform.Find("Buy Button").Find("Buy Text").GetComponent<TextMeshProUGUI>();
        buyText.text = $"{cardScript.priceValue}";
    }
    private void LoadTrashPrice()
    {
        TextMeshProUGUI title = trashPriceContent.transform.Find("Title Text").GetComponent<TextMeshProUGUI>();
        title.text = "Trash Price";
        TextMeshProUGUI level = trashPriceContent.transform.Find("== LEVEL ==").Find("Level Text").GetComponent<TextMeshProUGUI>();
        CardScript cardScript = trashPriceContent.GetComponent<CardScript>();
        level.text = $"Level {cardScript.level}";
        TextMeshProUGUI currentlyText = trashPriceContent.transform.Find("Current Upgrade Text").Find("Currently Text").GetComponent<TextMeshProUGUI>();
        currentlyText.text = $"Currently: €{cardScript.value}";
        TextMeshProUGUI upgradeNewText = trashPriceContent.transform.Find("Current Upgrade Text").Find("Value Text").GetComponent<TextMeshProUGUI>();
        upgradeNewText.text = $"+ €{cardScript.upgradeValue}";
        TextMeshProUGUI buyText = trashPriceContent.transform.Find("Buy Button").Find("Buy Text").GetComponent<TextMeshProUGUI>();
        buyText.text = $"{cardScript.priceValue}";
    }
    private void LoadTrashSize()
    {
        TextMeshProUGUI title = trashSizeContent.transform.Find("Title Text").GetComponent<TextMeshProUGUI>();
        title.text = "Trash Size";
        TextMeshProUGUI level = trashSizeContent.transform.Find("== LEVEL ==").Find("Level Text").GetComponent<TextMeshProUGUI>();
        CardScript cardScript = trashSizeContent.GetComponent<CardScript>();
        level.text = $"Level {cardScript.level}";
        TextMeshProUGUI currentlyText = trashSizeContent.transform.Find("Current Upgrade Text").Find("Currently Text").GetComponent<TextMeshProUGUI>();
        currentlyText.text = $"Currently: {cardScript.value}";
        TextMeshProUGUI upgradeNewText = trashSizeContent.transform.Find("Current Upgrade Text").Find("Value Text").GetComponent<TextMeshProUGUI>();
        upgradeNewText.text = $"+ {cardScript.upgradeValue}";
        TextMeshProUGUI buyText = trashSizeContent.transform.Find("Buy Button").Find("Buy Text").GetComponent<TextMeshProUGUI>();
        buyText.text = $"{cardScript.priceValue}";
    }
    private void LoadPlayerSpeed()
    {
        TextMeshProUGUI title = playerSpeedContent.transform.Find("Title Text").GetComponent<TextMeshProUGUI>();
        title.text = "Player Speed";
        TextMeshProUGUI level = playerSpeedContent.transform.Find("== LEVEL ==").Find("Level Text").GetComponent<TextMeshProUGUI>();
        CardScript cardScript = playerSpeedContent.GetComponent<CardScript>();
        level.text = $"Level {cardScript.level}";
        TextMeshProUGUI currentlyText = playerSpeedContent.transform.Find("Current Upgrade Text").Find("Currently Text").GetComponent<TextMeshProUGUI>();
        currentlyText.text = $"Currently: {cardScript.value}";
        TextMeshProUGUI upgradeNewText = playerSpeedContent.transform.Find("Current Upgrade Text").Find("Value Text").GetComponent<TextMeshProUGUI>();
        upgradeNewText.text = $"+ {cardScript.upgradeValue}";
        TextMeshProUGUI buyText = playerSpeedContent.transform.Find("Buy Button").Find("Buy Text").GetComponent<TextMeshProUGUI>();
        buyText.text = $"{cardScript.priceValue}";
    }
    private void LoadPickupSpeed()
    {
        TextMeshProUGUI title = pickupSpeedContent.transform.Find("Title Text").GetComponent<TextMeshProUGUI>();
        title.text = "Pickup Speed";
        TextMeshProUGUI level = pickupSpeedContent.transform.Find("== LEVEL ==").Find("Level Text").GetComponent<TextMeshProUGUI>();
        CardScript cardScript = pickupSpeedContent.GetComponent<CardScript>();
        level.text = $"Level {cardScript.level}";
        TextMeshProUGUI currentlyText = pickupSpeedContent.transform.Find("Current Upgrade Text").Find("Currently Text").GetComponent<TextMeshProUGUI>();
        currentlyText.text = $"Currently: {cardScript.value}s";
        TextMeshProUGUI upgradeNewText = pickupSpeedContent.transform.Find("Current Upgrade Text").Find("Value Text").GetComponent<TextMeshProUGUI>();
        upgradeNewText.text = $"- {cardScript.upgradeValue}s";
        TextMeshProUGUI buyText = pickupSpeedContent.transform.Find("Buy Button").Find("Buy Text").GetComponent<TextMeshProUGUI>();
        buyText.text = $"{cardScript.priceValue}";
    }
    private void LoadPickupDelay()
    {
        TextMeshProUGUI title = pickupDelayContent.transform.Find("Title Text").GetComponent<TextMeshProUGUI>();
        title.text = "Pickup Delay";
        TextMeshProUGUI level = pickupDelayContent.transform.Find("== LEVEL ==").Find("Level Text").GetComponent<TextMeshProUGUI>();
        CardScript cardScript = pickupDelayContent.GetComponent<CardScript>();
        level.text = $"Level {cardScript.level}";
        TextMeshProUGUI currentlyText = pickupDelayContent.transform.Find("Current Upgrade Text").Find("Currently Text").GetComponent<TextMeshProUGUI>();
        currentlyText.text = $"Currently: {cardScript.value}s";
        TextMeshProUGUI upgradeNewText = pickupDelayContent.transform.Find("Current Upgrade Text").Find("Value Text").GetComponent<TextMeshProUGUI>();
        upgradeNewText.text = $"- {cardScript.upgradeValue}s";
        TextMeshProUGUI buyText = pickupDelayContent.transform.Find("Buy Button").Find("Buy Text").GetComponent<TextMeshProUGUI>();
        buyText.text = $"{cardScript.priceValue}s";
    }
}
