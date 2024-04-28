using UnityEngine;

public class FindAudioListeners : MonoBehaviour
{
    void Start()
    {
        AudioListener[] listeners = FindObjectsOfType<AudioListener>();
        foreach (AudioListener listener in listeners)
        {
            Debug.LogWarning("Found Audio Listener on GameObject: " + listener.gameObject.name);
        }
    }
}
