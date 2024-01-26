using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private static UpgradeManager instance;
    // Start is called before the first frame update
    public Dictionary<UpgradeType, Upgrade> upgradeDictionary;
    void Start()
    {
        upgradeDictionary = new Dictionary<UpgradeType, Upgrade>();
        AddUpgrade(UpgradeType.SPAWN_RATE, new Upgrade("Spawn Rate", 150, 1, 4, 0.5f));
        AddUpgrade(UpgradeType.INVENTORY_SIZE, new Upgrade("Inventory Size", 200, 1, 5, 1f));
        AddUpgrade(UpgradeType.COIN_BONUS, new Upgrade("Coins Bonus", 300, 1, 0, 20f));
        AddUpgrade(UpgradeType.TRASH_SIZE, new Upgrade("Trash Size", 200, 1, 1, 0.1f));
        AddUpgrade(UpgradeType.PLAYER_SPEED, new Upgrade("Player Speed", 300, 1, 3.2f, 0.1f));
        AddUpgrade(UpgradeType.PICKUP_SPEED, new Upgrade("Pickup Speed", 300, 1, 3, 0.2f));
        AddUpgrade(UpgradeType.PICKUP_DELAY, new Upgrade("Pickup Delay", 200, 1, 2, 0.3f));

        GameManager.Instance.MAX_INVENTORY_SIZE = (int)GetUpgrade(UpgradeType.INVENTORY_SIZE).Value;
    }
    public static UpgradeManager Instance
    {
        get
        {
            if (instance == null)
                instance = new();
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Upgrade GetUpgrade(UpgradeType upgradeType)
    {
        if (upgradeDictionary == null) return null;
        if (upgradeDictionary.ContainsKey(upgradeType))
        {
            return upgradeDictionary[upgradeType];
        }
        else
        {
            Console.WriteLine($"Upgrade of type {upgradeType} not found.");
            return null;
        }
    }
    public void AddUpgrade(UpgradeType upgradeType, Upgrade upgrade)
    {
        upgradeDictionary.Add(upgradeType, upgrade);
    }
}

public enum UpgradeType
{
    SPAWN_RATE,
    COIN_BONUS,
    TRASH_SIZE,
    PLAYER_SPEED,
    PICKUP_SPEED,
    PICKUP_DELAY,
    INVENTORY_SIZE
}