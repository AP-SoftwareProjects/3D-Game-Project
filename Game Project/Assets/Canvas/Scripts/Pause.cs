using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public Canvas pauseMenuCanvas;
    public Button continueButton;

    private bool isPaused = false;

    void Start()    
    {
        if (pauseMenuCanvas != null)
        {
            pauseMenuCanvas.enabled = false;
        }

        if (continueButton != null)
        {
            continueButton.onClick.AddListener(ContinueGame);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void TogglePauseMenu()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
 
            Time.timeScale = 0f;

            if (pauseMenuCanvas != null)
            {
                pauseMenuCanvas.enabled = true;
            }
        }
        else
        {
           
            Time.timeScale = 1f;

            if (pauseMenuCanvas != null)
            {
                pauseMenuCanvas.enabled = false;
            }
        }
    }

    void ContinueGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuCanvas.enabled = false;

    }
}
