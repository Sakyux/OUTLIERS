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

    public void PlayClickSFX()
    {
        ClickSFX.Play();
    }

    public void SetMasterVolume(float masterVolume)
    {
        audioMixer.SetFloat("Master Volume", masterVolume);
    }

    public void SetSfxVolume(float sfxVolume)
    {
        audioMixer.SetFloat("SFX Volume", sfxVolume);
    }

    public void SetMusicVolume(float musicVolume)
    {
        audioMixer.SetFloat("Music Volume", musicVolume);
    }
}
