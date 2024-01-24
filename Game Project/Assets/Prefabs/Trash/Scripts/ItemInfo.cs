using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    public BinTypes Type;
    public float Duration;
    public int Price;
}
public enum BinTypes
{
    RED,
    ORANGE,
    GREEN
}