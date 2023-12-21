public class PlayerBin
{
    public int Amount { get; private set; } = 0;
    public BIN_TYPES BinType;
    public PlayerBin(BIN_TYPES binType)
    {
        BinType = binType;
    }

    public int AddAmount(int amount) => this.Amount += amount;
    public int SubtractAmount(int amount) => this.Amount -= amount;


}

public enum BIN_TYPES
{
    RED,
    ORANGE,
    GREEN
}
