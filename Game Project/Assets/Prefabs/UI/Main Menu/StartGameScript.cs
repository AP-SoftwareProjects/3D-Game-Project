using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour, IPointerClickHandler
{
    public GameObject loadingScreen;
    public string levelToLoad = "Level1";

    private void LoadLevel()
    {
        if (!string.IsNullOrEmpty(levelToLoad))
        {
            SceneManager.LoadScene(levelToLoad);
        }
        else
        {
            Debug.LogError("Level name is not specified in HoverTextScript.");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(LoadLevelWithLoadingScreen());
    }
    private IEnumerator LoadLevelWithLoadingScreen()
    {
        Animator animator = loadingScreen.GetComponent<Animator>();
        if (loadingScreen != null)
        {
            loadingScreen.SetActive(true);
            animator.SetBool("IsLoading", true);
        }
        yield return new WaitForSeconds(1f);

        LoadLevel();
    }
}
