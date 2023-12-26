#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScript : MonoBehaviour
{
    public string triggerLevelName = "Level5";
    public string devLevel = "Level1";

    void Start()
    {
        #if UNITY_EDITOR
            string currentSceneName = GetCurrentSceneName();
            if (devLevel == currentSceneName || triggerLevelName == currentSceneName) return;
        #endif

        SceneManager.LoadScene("YourNextSceneName");
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
            SceneManager.LoadScene(triggerLevelName);
    }

    void Update()
    {
    }
    #if UNITY_EDITOR
    private string GetCurrentSceneName()
    {
        string scenePath = UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene().path;
        string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);
        return sceneName;
    }
    #endif
}
