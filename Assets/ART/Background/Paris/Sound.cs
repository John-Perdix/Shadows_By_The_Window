using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource SoundFX;
    // Start is called before the first frame update
    void Start()
    {
        SoundFX.Play();
    }
}
