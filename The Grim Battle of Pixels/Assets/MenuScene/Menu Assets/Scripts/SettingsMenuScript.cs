using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SettingsMenuScript : MonoBehaviour
{
    private bool isFullScreen = true;
    private float musicVolume;
    public AudioMixer am;
    public Slider slid;


    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }

    public void AudioVolume()
    {
        musicVolume = slid.value;
        if (musicVolume == -60f)
            musicVolume = -80f;

        am.SetFloat("masterVolume", musicVolume);
    }

}
