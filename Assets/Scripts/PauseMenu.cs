using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Reference to the buttons that need reinitialization
    public ButtonHover[] buttons;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        // Reinitialize buttons
        foreach (ButtonHover button in buttons)
        {
            button.Initialize();
        }
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu...");
        // Add logic to load the main menu scene if needed
        // SceneManager.LoadScene("MenuScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        // Add logic to quit the application
        // Application.Quit();
    }
}
