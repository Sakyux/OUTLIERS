using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image BG;
    public float fadeDuration = 10f;
    public float delay = 0f;

    private void Start()
    {
        StartCoroutine(FadingIn());
    }

    private IEnumerator FadingIn()
    {
        float timeElapsed = 0;
        yield return new WaitForSeconds(delay);

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float t = timeElapsed / fadeDuration;

            float imageAlpha = Mathf.Lerp(1, 0, t);
            Color targetAlpha = new Color(BG.color.r, BG.color.g, BG.color.b, imageAlpha);

            BG.color = targetAlpha;

            yield return null;
        }
    }
}
