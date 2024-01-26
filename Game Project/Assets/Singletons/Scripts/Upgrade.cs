using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade
{
    public string Name { get; set; }
    public float PriceValue { get; set; }
    public int Level { get; set; } = 1;
    public float Value { get; set; } = 10;
    public float UpgradeValue { get; set; } = 5;

    public Upgrade(string name, float priceValue, int level, float value, float upgradeValue)
    {
        Name = name;
        PriceValue = priceValue;
        Level = level;
        Value = value;
        UpgradeValue = upgradeValue;
    }
}
