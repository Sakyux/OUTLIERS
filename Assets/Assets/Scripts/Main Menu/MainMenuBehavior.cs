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

    // THE FOLLOWING IS ASSIGNED TO BUTTONS IN THE MAIN MENU.
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

    // Method dedicated to the "Start Game" button that launches the gameplay.
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

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level 1 - Jam 17");
    }

    // Fixes misinput issue.
    private IEnumerator WaitBeforeInput(float delay)
    {
        yield return new WaitForSeconds(delay);
        allowInput = true;
    }
}
