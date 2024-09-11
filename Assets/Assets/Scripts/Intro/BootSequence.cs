using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

[System.Serializable]
public class BootSequence : MonoBehaviour

{
    [TextArea(3, 10)]
    public List<string> texts = new List<string>();

    public TextMeshProUGUI displayText;
    public GameObject Icons;
    public GameObject LoadingGIF;
    public GameObject WarningImage;
    public Image CreditsImage;
    public TextMeshProUGUI CreditsText;
    public TextMeshProUGUI UserText;

    public float letterDelay = 0.05f;
    public float sentenceDelay = 1f;
    public float pauseDelay = 0.05f;

    public AudioClip audio1;
    public AudioClip audio2;
    public AudioClip BGNoise;
    public AudioClip BGNoise2;

    public AudioSource loadingSFX;
    public AudioSource startUpSFX;

    private AudioSource BGAudio;
    public float fadeTime = 2.0f;

    
    public bool firstBoot = true;

    private void Start()
    {
        string FirstBootPath = Application.dataPath + "/FirstBoot.txt";
        if (File.Exists(FirstBootPath))
        {
            string firstBootText = File.ReadAllText(FirstBootPath);

            if (firstBootText.Equals("TRUE"))
            {
                firstBoot = true;
            }
            else if (firstBootText.Equals("FALSE"))
            {
                firstBoot = false;
            }
        }

        Icons.SetActive(false);
        WarningImage.SetActive(false);

        StartCoroutine(LoadingUI());
        if (firstBoot == true) StartCoroutine(FirstStartUp());
        else StartCoroutine(SplashScreen());
    }

    private IEnumerator LoadingUI()
    {
        BGAudio = GetComponent<AudioSource>();
        BGAudio.clip = BGNoise;
        BGAudio.Play();

        yield return new WaitForSeconds(5f);
        LoadingGIF.SetActive(false);
    }

    private IEnumerator FirstStartUp()
    {
        StartCoroutine(SFXDuration());
        yield return new WaitForSeconds(5f);
        Icons.SetActive(true);

        yield return new WaitForSeconds(3f);

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

        displayText.text += "VRAM : " + SystemInfo.graphicsMemorySize + "MB" + "\n\n\n";
        yield return new WaitForSeconds(0.3f);

        displayText.text += "Loading OS : " + SystemInfo.operatingSystem + "\n";

        displayText.text += "IP Address Located: " + GetLocalIPAddress() + "..... Information uploaded.\n";

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

        AudioSource beepSFX = GetComponent<AudioSource>();

        for (int j = 0; j < 5; j++)
        {
            yield return new WaitForSeconds(0.5f);
            displayText.text += ".";

            if (j == 4)
            {
                displayText.text += "\n\n" + "Booting Sequence Complete.";
                yield return new WaitForSeconds(2f);
                
                beepSFX.clip = audio2;
                beepSFX.Play();
            }
        }

        Icons.SetActive(false);
        displayText.ClearMesh();

        WarningImage.SetActive(true);
        yield return new WaitForSeconds(5f);
        WarningImage.SetActive(false);

        float targetAlpha = 1f;
        float timeElapsed = 0;
        float fadeDuration = 1.5f;

        startUpSFX.clip = BGNoise2;
        startUpSFX.volume = 0.3f;
        startUpSFX.Play();

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float t = timeElapsed / fadeDuration;

            float ImageAlpha = Mathf.Lerp(0, targetAlpha, t);
            Color ImageColor = new Color(CreditsImage.color.r, CreditsImage.color.g, CreditsImage.color.b, ImageAlpha);
            Color UserTextColor = new Color(UserText.color.r, UserText.color.g, UserText.color.b, ImageAlpha);

            CreditsImage.color = ImageColor;
            CreditsText.color = ImageColor;
            UserText.color = UserTextColor;

            yield return null;
        }

        timeElapsed = 0;
        yield return new WaitForSeconds(3f);

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float t = timeElapsed / fadeDuration;

            float ImageAlpha = Mathf.Lerp(1, 0, t);
            Color ImageColor = new Color(CreditsImage.color.r, CreditsImage.color.g, CreditsImage.color.b, ImageAlpha);
            Color UserTextColor = new Color(UserText.color.r, UserText.color.g, UserText.color.b, ImageAlpha);

            CreditsText.color = ImageColor;
            UserText.color = UserTextColor;
            yield return null;
        }

        firstBoot = false;
        SceneManager.LoadScene("TitleScreen");
    }

    private IEnumerator SplashScreen() 
    {
        StartCoroutine(SFXDuration());
        yield return new WaitForSeconds(5f);
        WarningImage.SetActive(true);
        yield return new WaitForSeconds(5f);
        WarningImage.SetActive(false);

        float targetAlpha = 1f;
        float timeElapsed = 0;
        float fadeDuration = 1.5f;

        startUpSFX.clip = BGNoise2;
        startUpSFX.volume = 0.3f;
        startUpSFX.Play();

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime; 
            float t = timeElapsed / fadeDuration; 
            
            float ImageAlpha = Mathf.Lerp(0, targetAlpha, t);
            Color ImageColor = new Color(CreditsImage.color.r, CreditsImage.color.g, CreditsImage.color.b, ImageAlpha);
            Color UserTextColor = new Color(UserText.color.r, UserText.color.g, UserText.color.b, ImageAlpha);

            CreditsImage.color = ImageColor; 
            CreditsText.color = ImageColor;
            UserText.color = UserTextColor;

            yield return null;
        } 

        timeElapsed = 0;
        yield return new WaitForSeconds(3f);

        //StartCoroutine(FadeOutAudio(startUpSFX, 1f));     // Screws with sound but I'm too lazy to fix it.

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float t = timeElapsed / fadeDuration;

            float ImageAlpha = Mathf.Lerp(1, 0, t);
            Color ImageColor = new Color(CreditsImage.color.r, CreditsImage.color.g, CreditsImage.color.b, ImageAlpha);
            Color UserTextColor = new Color(UserText.color.r, UserText.color.g, UserText.color.b, ImageAlpha);

            CreditsText.color = ImageColor;
            UserText.color = UserTextColor;

            yield return null;
        }

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("TitleScreen");
    }

    private IEnumerator FadeOutAudio(AudioSource audioSource, float fadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > -80)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeTime; ;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }

    private IEnumerator SFXDuration()
    {
        if (firstBoot == true)
        {
            yield return new WaitForSeconds(42f);
            StartCoroutine(FadeOutAudio(BGAudio, fadeTime));
        }
        else if (firstBoot == false)
        {
            yield return new WaitForSeconds(16f);
            StartCoroutine(FadeOutAudio(BGAudio, fadeTime));
        }
    }

    private string GetLocalIPAddress()
    {
        string localIP = "";
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                localIP = ip.ToString();
                break;
            }
        }
        return localIP;
    }
}

