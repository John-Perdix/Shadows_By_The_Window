using UnityEngine;
using UnityEngine.UI; // Import UI namespace for Image

public class Crossair : MonoBehaviour
{
    public Image CrosshairImage; // Assign the crosshair image in Inspector

    void Start()
    {
        // Lock the cursor (consider user experience and provide unlock)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Check for Escape key to unlock (optional)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // Position the crosshair image at the center of the screen
        if (CrosshairImage != null) // Check if image is assigned
        {
            CrosshairImage.rectTransform.anchoredPosition = Vector2.zero;
        }
    }
}