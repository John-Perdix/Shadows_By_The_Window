using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public PlayerCam playerCam; // Reference to the PlayerCam script

    void Start()
    {
        // Ensure the pause menu is inactive at the start
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }
        else
        {
            Debug.LogError("pauseMenuUI is not assigned in the Inspector");
        }

        if (playerCam == null)
        {
            playerCam = FindObjectOfType<PlayerCam>();
            if (playerCam == null)
            {
                Debug.LogError("PlayerCam script is not found in the scene");
            }
        }

        GameIsPaused = false;
    }

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
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }
        else
        {
            Debug.LogError("pauseMenuUI is not assigned in the Inspector");
        }

        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor back
        Cursor.visible = false; // Hide the cursor

        if (playerCam != null)
        {
            playerCam.enabled = true; // Enable the camera controller
        }
    }

    void Pause()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true);
        }
        else
        {
            Debug.LogError("pauseMenuUI is not assigned in the Inspector");
        }

        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Show the cursor

        if (playerCam != null)
        {
            playerCam.enabled = false; // Disable the camera controller
        }
    }
}
