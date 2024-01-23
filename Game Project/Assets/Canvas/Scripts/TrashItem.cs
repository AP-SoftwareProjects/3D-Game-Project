using UnityEngine;

public class TrashItem: MonoBehaviour
{
    public BinType Type { get; set; }
    public float Duration { get; set; }
    public float Price { get; set; }


}
public enum BinType
{
    RED,
    ORANGE,
    GREEN
}
