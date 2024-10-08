using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkipIntro : MonoBehaviour
{
    public Text SkipText;
    private float count = 0;
    private bool allowSkip = false;

    private void Start()
    {
        StartCoroutine(WaitBeforeSkip(3f));
    }

    // Skips intro if user desires.
    private void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            StartCoroutine(FadeInSkipText());
            
            if (allowSkip == true)
            {
                count++;
            }

            if (count == 2)
            {
                Skip();
            }
        }
    }

    // Animation that displays confirmation.
    private IEnumerator FadeInSkipText()
    {
        float timeElapsed = 0;
        float fadeDuration = 0.5f;

        if (allowSkip == true)
        {
            // FADE IN
            while (timeElapsed < fadeDuration)
            {
                timeElapsed += Time.deltaTime;
                float t = timeElapsed / fadeDuration;

                float SkipTextAlpha = Mathf.Lerp(0, 1, t);
                Color SkipTextColor = new Color(SkipText.color.r, SkipText.color.g, SkipText.color.b, SkipTextAlpha);

                SkipText.color = SkipTextColor;
                yield return null;
            }

            yield return new WaitForSeconds(1f);
            timeElapsed = 0f;

            // FADE OUT
            while (timeElapsed < fadeDuration)
            {
                timeElapsed += Time.deltaTime;
                float t = timeElapsed / fadeDuration;

                float SkipTextAlpha = Mathf.Lerp(1, 0, t);
                Color SkipTextColor = new Color(SkipText.color.r, SkipText.color.g, SkipText.color.b, SkipTextAlpha);

                SkipText.color = SkipTextColor;
                yield return null;
            }
            count = 0;
        }
    }

    private void Skip()
    {
        string FirstBootPath = Application.dataPath + "/FirstBoot.txt";
        File.WriteAllText(FirstBootPath, "FALSE");
        SceneManager.LoadScene("TitleScreen");
    }

    private IEnumerator WaitBeforeSkip(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        allowSkip = true;
    }
}
