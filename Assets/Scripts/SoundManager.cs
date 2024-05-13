using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
        [SerializeField] Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Carregar();
        }
        else
        {
            Carregar();
        }
        
    }
    public void AlterarVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Guardar();
    }
     public void Carregar()
    {
        volumeSlider.value =PlayerPrefs.GetFloat("musicVolume");
    }
     public void Guardar()
    {
       PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

}
