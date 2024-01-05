using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string devLevel = "Level1";
    private static GameManager instance;
    public PlayerBalance PlayerBalance { get; }
    public List<TrashItem> TrashItems { get; }

    public Text CoinsText;
    public Text PointsText;

    public Text RedBinText;
    public Text OrangeBinText;
    public Text GreenBinText;

    private GameManager()
    {
        this.PlayerBalance = new();
        this.TrashItems = new();
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
                instance = new();
            return instance;
        }
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

#if UNITY_EDITOR
        string currentSceneName = GetCurrentSceneName();
        if (devLevel == currentSceneName) return;
#endif

        SceneManager.LoadScene(devLevel);
    }
#if UNITY_EDITOR
    private string GetCurrentSceneName()
    {
        string scenePath = UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene().path;
        string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);
        return sceneName;
    }
#endif
    public void AddTrash(TrashItem trashItem)
    {
        TrashItems.Add(trashItem);
    }
    void Update()
    {


        /*

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
         */

        if (CoinsText != null && PointsText != null)
        {
            this.CoinsText.text = this.PlayerBalance.Coins.ToString();
            this.PointsText.text = this.PlayerBalance.Points.ToString();
        }
        if (RedBinText != null && OrangeBinText != null && GreenBinText != null)
        {
            this.RedBinText.text = this.TrashItems.Count(item => item.Type == TrashItem.BinType.RED).ToString();
            this.OrangeBinText.text = this.TrashItems.Count(item => item.Type == TrashItem.BinType.ORANGE).ToString();
            this.GreenBinText.text = this.TrashItems.Count(item => item.Type == TrashItem.BinType.GREEN).ToString();
        }
    }
}
