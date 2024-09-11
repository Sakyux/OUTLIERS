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

    public Button PlayButton;
    public Button SettingsButton;
    public Button QuitGameButton;

    private bool allowInput = false;

    private void Start()
    {
        StartCoroutine(WaitBeforeInput(1f));
    }

    public void StartGame()
    {
        if (allowInput)
        {
            StartCoroutine(LoadLevel());
        }
    }

    public void Settings()
    {
        if (allowInput)
        {
            UISFX.Play();
        }
    }

    public void QuitGame()
    {
        if (allowInput)
        {
            UISFX.Play();
            Application.Quit();
        }
    }

    public IEnumerator LoadLevel()
    {
        transitionAnim.SetTrigger("OnClick");
        UISFX.Play();

        PlayButton.enabled = false;
        SettingsButton.enabled = false;
        QuitGameButton.enabled = false;

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

    private IEnumerator WaitBeforeInput(float delay)
    {
        yield return new WaitForSeconds(delay);
        allowInput = true;
    }
}
