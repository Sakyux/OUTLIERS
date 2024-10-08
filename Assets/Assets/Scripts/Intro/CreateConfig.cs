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

    // Initializes configuration if it is first launch.
    private void InitializeFirstBootConfig()
    {
        string bootFilePath = Application.dataPath + "/FirstBoot.txt";
        string defaultContent = "TRUE";

        if (!File.Exists(bootFilePath))
        {
            File.WriteAllText(bootFilePath, defaultContent);
        }
    }
    // Initializes audio configuration upon first launch.
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
