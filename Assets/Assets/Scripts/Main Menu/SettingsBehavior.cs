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

    private void ResetData()
    {
        Debug.Log("Data has been reset!");
        string audioFilePath = Application.dataPath + "/AudioConfig.txt";
        string bootFilePath = Application.dataPath + "/FirstBoot.txt";

        string defaultContent = "Master Volume: 0\nSFX Volume: 0\nMusic Volume: 0";

        File.WriteAllText(audioFilePath, defaultContent);
        File.WriteAllText(bootFilePath, "TRUE");

        audioMixer.SetFloat("Master Volume", 0);
        audioMixer.SetFloat("SFX Volume", 0);
        audioMixer.SetFloat("Music Volume", 0);
    }
}
