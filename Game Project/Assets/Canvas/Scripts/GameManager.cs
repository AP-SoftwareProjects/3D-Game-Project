using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public PlayerBalance PlayerBalance { get; }
    public List<PlayerBin> PlayerBins { get; }
    public Text CoinsText;
    public Text PointsText;

    public Text RedBinText;
    public Text OrangeBinText;
    public Text GreenBinText;

    private GameManager()
    {
        this.PlayerBalance = new();
        this.PlayerBins = new List<PlayerBin>()
        {
           new PlayerBin(BIN_TYPES.RED),
           new PlayerBin(BIN_TYPES.ORANGE),
           new PlayerBin(BIN_TYPES.GREEN)
        };
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }

    void Start()
    {

    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            this.PlayerBalance.AddCoins(1);
            this.PlayerBins[0].AddAmount(10);
        }
        else
        {
            this.PlayerBalance.SubtractCoins(1);
            this.PlayerBins[1].AddAmount(20);
        }


        if (CoinsText != null && PointsText != null)
        {
            this.CoinsText.text = this.PlayerBalance.Coins.ToString();
            this.PointsText.text = this.PlayerBalance.Points.ToString();
        }
        if (RedBinText != null && OrangeBinText != null && GreenBinText != null)
        {
            this.RedBinText.text = this.PlayerBins.Find((v) => v.BinType == BIN_TYPES.RED).Amount.ToString();
            this.OrangeBinText.text = this.PlayerBins.Find((v) => v.BinType == BIN_TYPES.ORANGE).Amount.ToString();
            this.GreenBinText.text = this.PlayerBins.Find((v) => v.BinType == BIN_TYPES.GREEN).Amount.ToString();
        }
    }
}
