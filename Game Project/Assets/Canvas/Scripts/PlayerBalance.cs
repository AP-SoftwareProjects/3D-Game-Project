public class PlayerBalance
{

    public int Coins { get; set; } = 0;
    public int Points { get; set; } = 0;
    public PlayerBalance()
    {

    }

    public void AddCoins(int coins) => this.Coins += coins;
    public void AddPoints(int points) => this.Points += points;
    public void SubtractCoins(int coins) => this.Coins -= coins;
    public void SubtractPoints(int points) => this.Points -= points;

}