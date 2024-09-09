using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsBehavior : MonoBehaviour
{
    public AudioSource ClickSFX;

    public AudioMixer audioMixer;

    private void Start()
    {
        audioMixer.GetFloat("Master Volume", out float masterVolume);
        audioMixer.GetFloat("SFX Volume", out float sfxVolume);
        audioMixer.GetFloat("Music Volume", out float musicVolume);

        if (masterVolume <= -30)
        {
            audioMixer.SetFloat("Master Volume", -80);
        }

        if (sfxVolume <= -30)
        {
            audioMixer.SetFloat("SFX Volume", -80);
        }

        if (musicVolume <= -30)
        {
            audioMixer.SetFloat("Music Volume", -80);
        }
    }

    public void PlayClickSFX()
    {
        ClickSFX.Play();
    }

    public void SetMasterVolume(float masterVolume)
    {
        if (masterVolume <= -30)
        {
            audioMixer.SetFloat("Master Volume", -80);
        } 
        else audioMixer.SetFloat("Master Volume", masterVolume);
    }

    public void SetSfxVolume(float sfxVolume)
    {
        if (sfxVolume <= -30)
        {
            audioMixer.SetFloat("SFX Volume", -80);
        }
        else audioMixer.SetFloat("SFX Volume", sfxVolume);
    }

    public void SetMusicVolume(float musicVolume)
    {
        if (musicVolume <= -30)
        {
            audioMixer.SetFloat("Music Volume", -80);
        }
        else audioMixer.SetFloat("Music Volume", musicVolume);
    }
}
