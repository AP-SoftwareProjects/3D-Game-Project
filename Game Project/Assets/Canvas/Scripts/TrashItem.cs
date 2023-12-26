using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashItem
{
    public BinType Type { get; set; }
    public int Price { get; set; }

    public TrashItem(BinType binType, int price)
    {
        Type = binType;
        Price = price;
    }
    public enum BinType
    {
        RED,
        ORANGE,
        GREEN
    }

}
