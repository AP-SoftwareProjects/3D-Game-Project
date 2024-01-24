using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashItem: MonoBehaviour
{
    public BinType Type { get; set; }
    public float Duration { get; set; }
    public int Price { get; set; }

    public TrashItem(BinType type, int price)
    {
        Type = type;
        Price = price;
    }

}
public enum BinType
{
    RED,
    ORANGE,
    GREEN
}
