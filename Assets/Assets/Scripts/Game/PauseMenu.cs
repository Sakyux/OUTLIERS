using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameHandler gameHandler;
    public GameObject exitTransition;
    public Animator exitAnimation;

    public PauseBG PauseBG;

    public GameplayControls controls;
    public AudioConductor AudioConductor;

    public Button ResumeButton;
    public Button RestartButton;
    public Button SettingsButton;
    public Button QuitButton;

    public Slider FirstSliderSelected;

    public GameObject MenuPause;
    public GameObject MenuSettings;

    private bool gameResumed = true;
    private bool canInput = true;

    private void Awake()
    {
        controls = new GameplayControls();
        controls.PauseMenu.Enable();

        exitAnimation.updateMode = AnimatorUpdateMode.UnscaledTime; // To fix animation freeze bug.
    }

    // The following are methods to be attached to buttons in game.
    public void Resume()
    {
        StartCoroutine(GameplayDelay());
        AudioConductor.SetPauseTime();
        gameHandler.Resume();
        PauseBG.StopBackgroundSFX();

        StartCoroutine(GameplayDelay());
    }

    public void Restart()
    {
        StartCoroutine(RestartGame());
        Time.timeScale = 1.0f;
        DisableControls();
    }

    public void Settings()
    {
        MenuPause.SetActive(false);
        MenuSettings.SetActive(true);

        EventSystem.current.SetSelectedGameObject(FirstSliderSelected.gameObject);
    }

    public void Quit()
    {
        StartCoroutine(QuitGame());
        Time.timeScale = 1.0f;
        DisableControls();
    }

    // Sequence that restarts the game.
    private IEnumerator RestartGame()
    {
        exitTransition.SetActive(true);
        exitAnimation.Play("W-B D-U");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Quite literally exits the gameplay.
    private IEnumerator QuitGame()
    {
        exitTransition.SetActive(true);
        exitAnimation.Play("W-B D-U");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("TitleScreen");
    }

    // Fixes a bug that causes sudden input when resuming game.
    public IEnumerator GameplayDelay()
    {
        yield return new WaitForSeconds(0.1f);
        gameResumed = true;
    }

    public void SetGameResumed(bool condition)
    {
        gameResumed = condition;
    }

    public bool IsGameResumed()
    {
        return gameResumed; 
    }

    // Disable Pause Menu buttons.
    public void DisableControls()
    {
        ResumeButton.enabled = false;
        RestartButton.enabled = false;
        SettingsButton.enabled = false;
        QuitButton.enabled = false;

        canInput = false;
    }

    // To go back from Settings to Pause Menu.
    public void Back()
    {
        MenuPause.gameObject.SetActive(true);
        MenuSettings.gameObject.SetActive(false);

        EventSystem.current.SetSelectedGameObject(ResumeButton.gameObject);
    }

    public bool GetCanInput()
    {
        return canInput;
    }
}
