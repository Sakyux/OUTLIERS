using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider masterVolumeSlider;
    public Slider sfxVolumeSlider;
    public Slider musicVolumeSlider;

    private void Start()
    {
        LoadAudioConfig();
        SetMinimumVolume();

        masterVolumeSlider.onValueChanged.AddListener(SaveAudioConfig);
        sfxVolumeSlider.onValueChanged.AddListener(SaveAudioConfig);
        musicVolumeSlider.onValueChanged.AddListener(SaveAudioConfig);
    }

    private void LoadAudioConfig()
    {
        string audioFilePath = Application.dataPath + "/AudioConfig.txt";

        if (File.Exists(audioFilePath))
        {
            string settingsText = File.ReadAllText(audioFilePath);
            string[] lines = settingsText.Split('\n');

            masterVolumeSlider.value = float.Parse(lines[0].Split(": ")[1]);
            audioMixer.SetFloat("Master Volume", float.Parse(lines[0].Split(": ")[1]));

            sfxVolumeSlider.value = float.Parse(lines[1].Split(": ")[1]);
            audioMixer.SetFloat("SFX Volume", float.Parse(lines[1].Split(": ")[1]));

            musicVolumeSlider.value = float.Parse(lines[2].Split(": ")[1]);
            audioMixer.SetFloat("Music Volume", float.Parse(lines[2].Split(": ")[1]));
        }
        else
        {
            SaveAudioConfig(1f);
        }
    }

    public void SaveAudioConfig(float value)
    {
        string audioFilePath = Application.dataPath + "/AudioConfig.txt";

        string settingsText = $"Master Volume: {masterVolumeSlider.value}\nSFX Volume: {sfxVolumeSlider.value}\nMusic Volume: {musicVolumeSlider.value}";
        File.WriteAllText(audioFilePath, settingsText);
    }

    private void SetMinimumVolume()
    {
        audioMixer.GetFloat("Master Volume", out float masterVolume);
        audioMixer.GetFloat("SFX Volume", out float sfxVolume);
        audioMixer.GetFloat("Music Volume", out float musicVolume);

        if (masterVolume <= -30f)
        {
            audioMixer.SetFloat("Master Volume", -80f);
        }

        if (sfxVolume <= -30f)
        {
            audioMixer.SetFloat("SFX Volume", -80f);
        }

        if (musicVolume <= -30f)
        {
            audioMixer.SetFloat("Music Volume", -80f);
        }
    }
}
