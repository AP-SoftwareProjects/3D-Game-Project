using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemInfoScript : MonoBehaviour
{
    public float prijs;
    public float Duration;
    public BinType Type;

}
public enum BinType
{
    RED,
    ORANGE,
    GREEN
}