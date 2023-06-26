using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class MusicPlsWork : MonoBehaviour
{

    private float volume;
    void Start()
    {
        volume = PlayerPrefs.GetFloat("musicVolume");
        AudioListener.volume = volume;
    }

    
}
