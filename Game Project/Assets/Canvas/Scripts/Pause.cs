using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public Canvas pauseMenuCanvas;
    public Button restartButton;

    private bool isPaused = false;

    void Start()    
    {
        if (pauseMenuCanvas != null)
        {
            pauseMenuCanvas.enabled = false;
        }

        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
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

    void RestartGame()
    {
        pauseMenuCanvas.enabled = false;
    }
}
