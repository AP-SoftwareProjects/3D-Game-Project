#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScript : MonoBehaviour
{
    public string triggerLevelName = "Level5";

    void Start()
    {

    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
            SceneManager.LoadScene(triggerLevelName);
    }

    void Update()
    {
    }

}
