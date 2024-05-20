using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private PressKeyOpenDoor pressKeyOpenDoor;
    public AudioSource musica;

    // Start is called before the first frame update
    void Start()
    {
        pressKeyOpenDoor = FindObjectOfType<PressKeyOpenDoor>();
        // Cache the PressKeyOpenDoor component
        if (pressKeyOpenDoor == null)
        {
            Debug.LogError("PressKeyOpenDoor component not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if PressKeyOpenDoor component is null
        if (pressKeyOpenDoor == null)
            return;

        // Check window status and play/stop music accordingly
        if (!pressKeyOpenDoor.windowClosed && !musica.isPlaying)
        {
            musica.Play();
        }
        else if (pressKeyOpenDoor.windowClosed && musica.isPlaying)
        {
            musica.Stop();
        }
    }
}