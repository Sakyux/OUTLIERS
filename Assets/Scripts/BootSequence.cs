using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class BootSequence : MonoBehaviour
{
    [TextArea(3, 10)]
    public List<string> texts = new List<string>();

    public TextMeshProUGUI displayText;

    public float letterDelay = 0.05f;
    public float sentenceDelay = 1f;
    public float pauseDelay = 0.05f;

    public AudioClip audio1;
    public AudioClip audio2;

    public static bool loadComplete = false;

    private void Start()
    {
        StartCoroutine(DisplayTexts()); // Performs action over time
    }

    IEnumerator DisplayTexts()
    {
        yield return new WaitForSeconds(8f);

        AudioSource loadingSFX = GetComponent<AudioSource>();
        loadingSFX.clip = audio1;
        loadingSFX.volume = 0.2f;
        loadingSFX.Play();

        foreach (string text in texts) // Nested foreach loop
        {
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                displayText.text += c.ToString(); // Builds strings
                yield return new WaitForSeconds(letterDelay);

                if (i == text.Length - 1)
                {
                    loadingSFX.Pause();
                    displayText.text += "\t";
                    for (int j = 0; j < 5; j++)
                    {
                        yield return new WaitForSeconds(0.3f);
                        displayText.text += ".";
                    }
                }
            }

            displayText.text += "\n"; // Display on new line 
            yield return new WaitForSeconds(sentenceDelay);
        }

        displayText.text += "\n\n";
        displayText.text += "Device Model : " + SystemInfo.deviceModel + "\n";
        loadingSFX.Play();
        yield return new WaitForSeconds(pauseDelay);

        displayText.text += "Device Name : " + SystemInfo.deviceName + "\n";
        yield return new WaitForSeconds(pauseDelay);

        displayText.text += "Processor : " + SystemInfo.processorType + "\n";
        yield return new WaitForSeconds(pauseDelay);


        displayText.text += "Frequency : " + SystemInfo.processorFrequency + "Hrz\n";
        yield return new WaitForSeconds(0.3f);


        displayText.text += "System Memory : " + SystemInfo.systemMemorySize + "MB" + "\n";
        yield return new WaitForSeconds(pauseDelay);


        displayText.text += "Graphics Device : " + SystemInfo.graphicsDeviceName + "\n";
        yield return new WaitForSeconds(pauseDelay);

        displayText.text += "VRAM : " + SystemInfo.graphicsMemorySize + "MB" + "\n\n\n";
        yield return new WaitForSeconds(0.3f);

        displayText.text += "Loading OS : " + SystemInfo.operatingSystem + "\n";
        displayText.text += "\t";

        loadingSFX.Pause();

        for (int j = 0; j < 3; j++)
        {
            yield return new WaitForSeconds(0.5f);
            displayText.text += ".";
        }

        displayText.text += "Device Type : " + SystemInfo.deviceType + "\n";
        yield return new WaitForSeconds(pauseDelay);

        displayText.text += "Battery Level : " + (SystemInfo.batteryLevel * 100) + "%\n\n\n";
        yield return new WaitForSeconds(pauseDelay);

        StartCoroutine(LoadScreen());
    }

    public IEnumerator LoadScreen()
    {
        AudioSource loadingSFX = GetComponent<AudioSource>();
        loadingSFX.clip = audio2;

        for (int j = 0; j < 5; j++)
        {
            yield return new WaitForSeconds(0.5f);
            displayText.text += ".";

            if (j == 4)
            {
                displayText.text += "\n\n" + "Booting Sequence Complete.";
                loadingSFX.clip = audio2;
                yield return new WaitForSeconds(2f);

                loadingSFX.Play();
            }
        }

        loadComplete = true;
        SceneManager.LoadScene("WelcomeScreen");
    }
}



