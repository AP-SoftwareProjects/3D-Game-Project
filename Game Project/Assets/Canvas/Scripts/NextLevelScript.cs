using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScript : MonoBehaviour
{
    public string levelName = "Level5";

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(levelName);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(levelName);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
