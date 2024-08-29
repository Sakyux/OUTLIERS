using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuBehavior : MonoBehaviour
{
    [SerializeField] Animator transitionAnim;
    public AudioSource UISFX;
    public AudioSource BGMusic;

    public void StartGame()
    {
        StartCoroutine(LoadLevel());
    }

    public void Settings()
    {
        UISFX.Play();
    }

    public void QuitGame()
    {
        UISFX.Play();
        Application.Quit();
    }

    public IEnumerator LoadLevel()
    {
        transitionAnim.SetTrigger("OnClick");
        UISFX.Play();

        float fadeDuration = 1f;
        float startVolume = BGMusic.volume;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            BGMusic.volume = Mathf.Lerp(startVolume, 0f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("DefaultScreen");
    }

}
