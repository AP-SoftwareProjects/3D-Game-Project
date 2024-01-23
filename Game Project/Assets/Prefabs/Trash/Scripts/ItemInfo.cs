using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    public BinTypes Type { get; set; }
    public float Duration { get; set; }
    public int Price { get; set; }
}
public enum BinTypes
{
    RED,
    ORANGE,
    GREEN
}