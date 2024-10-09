using System.Collections;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class GameHandler : MonoBehaviour
{
    public GameObject IntroVideo;
    public GameObject StartAnimation;
    public GameObject Music;
    public GameObject Music2;
    public GameObject Intro;

    public GameObject Tutorial;
    public GameObject SongDisplay;

    private bool tutorialIsOn = false;
    private bool closeTutorial = false;

    public Animator TutorialAnimator;
    public Animator BackgroundAnimator;
    public Animator JudgementLine;
    public Animator TutorialText;

    public VideoPlayer IntroVid;
    public VideoPlayer TutorialVid;

    public AudioSource tutorialSFX;
    public AudioSource tutorialStop;

    public AudioClip PhaseTwo;

    public AudioSource GameMusic;
    public AudioSource GameMusic2;

    public GameObject PauseIcon;
    public GameObject TutorialUiIcon;

    public GameObject AudioConductor;
    public AudioConductor audioConductor;

    public GameObject TutorialVideo;

    public GameplayControls controls;

    public GameObject pauseIcon;
    public GameObject PauseBG;
    public GameObject PauseMenu;

    private bool isPaused = false;
    private bool playingMusic = false;

    public GameObject FirstButtonSelected;

    public PauseMenu pauseMenu;
    public GameObject backgroundVideo;
    public VideoPlayer backgroundVideoPlayer;

    // Activate controls.
    private void Awake()
    {
        controls = new GameplayControls();
        controls.Enable();

        IntroVid.Prepare(); // Preloads video to fix stutters.
    }

    private void Start()
    {
        StartCoroutine(StartDelay());
        StartCoroutine(PreloadPhaseTwo());
    }

    // Delay between intro and gameplay.
    private IEnumerator StartDelay()
    {
        IntroVideo.SetActive(true);

        yield return new WaitForSeconds(5f);
        Intro.SetActive(false);

        StartAnimation.SetActive(true);
        StartCoroutine(PlayMusic());
    }

    // Method to play game music.
    private IEnumerator PlayMusic()
    {
        yield return new WaitForSeconds(3.5f);
        StartCoroutine(OpenTutorial());
        Music.SetActive(true);
        yield return null;
    }

    // Animation to open and play tutorial video.
    private IEnumerator OpenTutorial()
    {
        Tutorial.SetActive(true);
        TutorialAnimator.Play("Intro");
        TutorialAnimator.SetBool("IsOn", true);
        tutorialIsOn = true;

        playingMusic = true;
        TutorialText.SetBool("isActive", true);

        tutorialSFX.Play();
        PauseIcon.SetActive(true);

        JudgementLine.SetBool("Tutorial Mode", true);

        TutorialVideo.SetActive(true);
        yield return null;
    }

    private void Update()
    {
        // Transition between tutorial and gameplay.
        if (tutorialIsOn == true)
        {
            if (Input.GetButtonDown("Submit"))
            {
                TutorialVideo.SetActive(false);
                TutorialAnimator.SetBool("IsOn", false);
                tutorialIsOn = false;
                BackgroundAnimator.SetFloat("Speed", -3f);

                JudgementLine.SetBool("Tutorial Mode", false);
                JudgementLine.SetFloat("Speed", -1f);

                TutorialText.SetBool("isActive", false);
                TutorialText.SetFloat("Speed", -1f);

                GameMusic.loop = false;
                GameMusic.Stop();

                tutorialSFX.Stop();
                tutorialStop.Play();

                PauseIcon.SetActive(false);
                TutorialUiIcon.SetActive(false);

                SongDisplay.SetActive(true);
                backgroundVideo.SetActive(true);

                closeTutorial = true;
                StartCoroutine(PlayPhaseTwo());
            }
        }
            
        if (tutorialIsOn == false && playingMusic == true && pauseMenu.GetCanInput())
        {
            if (controls.PauseMenu.Pause.WasPressedThisFrame() && isPaused == false)
            {
                Pause();
            }

            else if (controls.PauseMenu.Pause.WasPressedThisFrame() && isPaused == true)
            {
                StartCoroutine(GameplayDelay());
                Resume();
            }
        }
    }

    // Starts AudioConductor which tracks beats and song duration.
    private IEnumerator PlayPhaseTwo()
    {
        GameMusic2.Play();
        Debug.Log("Play Phase Two");

        backgroundVideo.SetActive(true);
        AudioConductor.SetActive(true);
        yield return null;
    }

    // Preloads audio clip.
    private IEnumerator PreloadPhaseTwo()
    {
        GameMusic2.clip.LoadAudioData();

        while (GameMusic2.clip.loadState == AudioDataLoadState.Loading)
        {
            yield return null;
        }
    }

    public bool HasCloseTutorial()
    {
        return closeTutorial;
    }

    // Freezes the game and deactivating gameplay input.
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseIcon.SetActive(true);
        controls.Gameplay.Disable();
        GameMusic2.Pause();
        PauseBG.SetActive(true);
        PauseMenu.SetActive(true);
        isPaused = true;
        backgroundVideoPlayer.Pause();

        pauseMenu.SetGameResumed(false);

        EventSystem.current.SetSelectedGameObject(FirstButtonSelected.gameObject); // Selects Pause Menu UI.
    }

    // Unfreezes the game and reactivates gameplay input.
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseIcon.SetActive(false);
        GameMusic2.Play();
        PauseBG.SetActive(false);
        PauseMenu.SetActive(false);
        isPaused = false;
        backgroundVideoPlayer.Play();
    }

    public bool GetPaused()
    {
        return isPaused;
    }

    // Delay before gameplay starts.
    public IEnumerator GameplayDelay()
    {
        controls.Gameplay.Disable();
        yield return new WaitForSeconds(0.3f);
        controls.Gameplay.Enable();
    }

    public void DisableControls()
    {
        controls.Disable();
    }

    public void DisableBackground()
    {
        backgroundVideo.SetActive(false);
    }
}