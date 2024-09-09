using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    private const string audioFilePath = "Assets/Config/AudioConfig.txt";
    public AudioMixer audioMixer;

    public Slider masterVolumeSlider;
    public Slider sfxVolumeSlider;
    public Slider musicVolumeSlider;

    private void Start()
    {
        LoadAudioConfig();

        masterVolumeSlider.onValueChanged.AddListener(SaveAudioConfig);
        sfxVolumeSlider.onValueChanged.AddListener(SaveAudioConfig);
        musicVolumeSlider.onValueChanged.AddListener(SaveAudioConfig);
    }

    private void LoadAudioConfig()
    {
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
        string settingsText = $"Master Volume: {masterVolumeSlider.value}\nSFX Volume: {sfxVolumeSlider.value}\nMusic Volume: {musicVolumeSlider.value}";
        File.WriteAllText(audioFilePath, settingsText);
    }
}
