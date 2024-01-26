public class PlayerBalance
{

    public float Coins { get; set; } = 0;
    public int Points { get; set; } = 0;
    public PlayerBalance()
    {

    }

    public void AddCoins(float coins) => this.Coins += coins;
    public void AddPoints(int points) => this.Points += points;
    public void SubtractCoins(float coins) => this.Coins -= coins;
    public void SubtractPoints(int points) => this.Points -= points;

}
