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
    }

    private void InitializeAudioConfig()
    {
        string audioFilePath = Application.dataPath + "/AudioConfig.txt";
    }
}
