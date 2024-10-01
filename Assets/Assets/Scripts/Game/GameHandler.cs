using System.Collections;
using System.Threading;
using UnityEngine;

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

    public AudioSource tutorialSFX;
    public AudioSource tutorialStop;

    public AudioClip PhaseTwo;

    public AudioSource GameMusic;
    public AudioSource GameMusic2;

    public GameObject PauseIcon;
    public GameObject TutorialUiIcon;

    public GameObject AudioConductor;

    private void Start()
    {
        StartCoroutine(StartDelay());
        StartCoroutine(PreloadPhaseTwo());
    }

    private IEnumerator StartDelay()
    {
        IntroVideo.SetActive(true);

        yield return new WaitForSeconds(5f);
        Intro.SetActive(false);

        StartAnimation.SetActive(true);
        StartCoroutine(PlayMusic());
    }

    private IEnumerator PlayMusic()
    {
        yield return new WaitForSeconds(3.5f);
        StartCoroutine(OpenTutorial());
        Music.SetActive(true);
        yield return null;
    }

    private IEnumerator OpenTutorial()
    {
        Tutorial.SetActive(true);
        TutorialAnimator.Play("Intro");
        TutorialAnimator.SetBool("IsOn", true);
        tutorialIsOn = true;

        TutorialText.SetBool("isActive", true);

        tutorialSFX.Play();
        PauseIcon.SetActive(true);

        JudgementLine.SetBool("Tutorial Mode", true);
        yield return null;
    }

    private void Update()
    {
        if (tutorialIsOn == true)
        {

            if (Input.GetButtonDown("Submit"))
            {
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

                closeTutorial = true;
                StartCoroutine(PlayPhaseTwo());
            }
        }
    }

    private IEnumerator PlayPhaseTwo()
    {
        GameMusic2.Play();
        Debug.Log("Play Phase Two");

        AudioConductor.SetActive(true);
        yield return null;
    }

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
}