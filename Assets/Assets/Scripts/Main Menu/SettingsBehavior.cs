using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsBehavior : MonoBehaviour
{
    public AudioSource ClickSFX;

    public AudioMixer audioMixer;

    private void Start()
    {
        audioMixer.GetFloat("Master Volume", out float masterVolume);
        audioMixer.GetFloat("SFX Volume", out float sfxVolume);
        audioMixer.GetFloat("Music Volume", out float musicVolume);

        SetMasterVolume(masterVolume);
        SetSfxVolume(sfxVolume);
        SetMusicVolume(musicVolume);
    }

    // THE FOLLOWING METHODS IS ASSIGNED TO BUTTONS FOR TITLE SCREEN SETTINGS HENCE THE REPETITION.
    public void PlayClickSFX()
    {
        ClickSFX.Play();
    }

    public void SetMasterVolume(float masterVolume)
    {
        if (masterVolume <= -30) // Similar to repeated code below, after -30 the sound mutes itself.
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
