using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CreateConfig : MonoBehaviour
{
    void Start()
    {
        InitializeFirstBootConfig();
        InitializeAudioConfig();
    }

    private void InitializeFirstBootConfig()
    {
        string bootFilePath = Application.dataPath + "/FirstBoot.txt";
        string defaultContent = "TRUE";

        if (!File.Exists(bootFilePath))
        {
            File.WriteAllText(bootFilePath, defaultContent);
        }
    }

    private void InitializeAudioConfig()
    {
        string audioFilePath = Application.dataPath + "/AudioConfig.txt";
        string defaultContent = "Master Volume: 0\nSFX Volume: 0\nMusic Volume: 0";

        if (!File.Exists(audioFilePath))
        {
            File.WriteAllText(audioFilePath, defaultContent);
        }
    }
}
