using UnityEngine;
using UnityEngine.EventSystems;

public class HoverTextScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator animator;
    public Texture2D cursorTexture;

    public AudioClip hoverSound;
    private AudioSource audioSource;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayHoverAnimation(true);
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);

        if (audioSource != null && hoverSound != null)
        {
            audioSource.PlayOneShot(hoverSound);
        }
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
   
}
