using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class HoverTextScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Animator animator;
    public string levelToLoad = "Level1";
    public Texture2D cursorTexture;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayHoverAnimation(true);
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PlayHoverAnimation(false);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private void PlayHoverAnimation(bool isHovering)
    {
        if (animator != null)
        {
            animator.SetBool("IsHovering", isHovering);
        }
    }
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
        LoadLevel();
    }
}
