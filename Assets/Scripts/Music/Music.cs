using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource music1;
    [SerializeField] private AudioSource musicLoop;


    void Start()
    {
        /* music1.volume = PlayerPrefs.GetFloat("musicVolume");
        musicLoop.volume = PlayerPrefs.GetFloat("musicVolume"); */
        music1.Play();
        musicLoop.PlayDelayed(music1.clip.length);
    }
    public void StopMusic()
    {
        music1.Stop();
        musicLoop.Stop();
    }

}
