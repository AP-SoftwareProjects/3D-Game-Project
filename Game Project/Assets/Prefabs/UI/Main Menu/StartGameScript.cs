using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour, IPointerClickHandler
{
    public GameObject loadingScreen;
    public string levelToLoad = "Level1";

    public AudioClip loadingSound;
    public AudioSource audioSource;

    private void LoadLevel()
    {
        if (!string.IsNullOrEmpty(levelToLoad))
            SceneManager.LoadScene(levelToLoad);
        else
            Debug.LogError("Level name is not specified in HoverTextScript.");
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
        if (audioSource != null && loadingSound != null)
        {
            audioSource.volume = 1;
            audioSource.Stop();
            audioSource.PlayOneShot(loadingSound);
        }
        yield return new WaitForSeconds(2f);

        LoadLevel();
    }
}
