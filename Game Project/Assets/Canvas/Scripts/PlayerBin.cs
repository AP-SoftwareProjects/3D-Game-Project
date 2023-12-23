using System.Collections.Generic;

public class PlayerBin
{
    public int Amount { get; private set; } = 0;
    public float Price { get; set; }
    public List<TrashItem> Trash { get; set; }


    public int AddAmount(int amount) => this.Amount += amount;
    public int SubtractAmount(int amount) => this.Amount -= amount;


}

