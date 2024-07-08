using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WelcomeScreen : MonoBehaviour
{
    public TextMeshProUGUI welcomeMessage;
    public Image profile;
    public Image background;
    public float BGFadeDuration;
    public Color BGColor = new Color32(243, 227, 201, 255);

    public AudioClip audio1;
    private string username = (System.Environment.UserName);

    private void Start()
    {
        StartCoroutine(ExitWelcome());
    }

    IEnumerator ExitWelcome()
    {
        AudioSource startSFX = GetComponent<AudioSource>();
        startSFX.clip = audio1;
        startSFX.Play();

        welcomeMessage.text = "Welcome Back\n\n\n\n\n" + username;
        Color color = profile.color;
        color.a = 100;
        profile.color = color;

        float startTime = Time.time;
        float endTime = startTime + BGFadeDuration;

        while (Time.time < endTime)
        {
            float t = (endTime - startTime) / BGFadeDuration;
            background.color = Color.Lerp(Color.black, BGColor, t);
        }

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("TitleScreen");
    }
}
