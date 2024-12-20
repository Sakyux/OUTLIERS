using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetData : MonoBehaviour
{
    public AudioMixer audioMixer;

    // ------ FOR RESET BUTTON ------
    private Button ResetButton;

    [SerializeField]
    private bool isHolding = false;
    private float currentHoldTime = 0f;
    private float requiredHoldTime = 3f;
    public UnityEvent onLongClick;

    public AudioSource resetSFX;
    public AudioSource cancelSFX;
    public float initialPitch;
    public float delay = 0.1f;

    private bool isSelected = false;

    public Animator animator;

    private void Update()
    {
        // If button is held.
        if (Input.GetButtonDown("Submit") && isSelected == true)
        {
            isHolding = true;
            StartPlayingSFX();
            PlayDestroyAnimation();
            Debug.Log("Currently holding: TRUE");
            
        }

        // If button is let go.
        else if (Input.GetButtonUp("Submit") && isSelected == true)
        {   
            if (isSelected == true)
            {
                cancelSFX.Play();
            }

            Reset();
            StopPlayingSFX();
            StopDestroyAnimation();
            Debug.Log("Currently holding: FALSE");
        }

        // Checks how long the button is held for.
        if (isHolding && isSelected == true)
        {
            currentHoldTime += Time.deltaTime;

            if (currentHoldTime >= requiredHoldTime)
            {
                if (onLongClick != null) onLongClick.Invoke();

                Reset();
                HoldResetData();
            }
        } 

        // Animation that plays when button is held.
        else if (isHolding == true && isSelected == false)
        {
            currentHoldTime = 0f;
            StopDestroyAnimation();
            resetSFX.Stop();
            cancelSFX.Play();
            isHolding = false;
        }
    }

    // Resets hold timer if button is let go.
    private void Reset()
    {
        isHolding = false;
        currentHoldTime = 0f;
        cancelSFX.Play();
    }

    // Method that wipes all existing data.
    public void HoldResetData()
    {
        Debug.Log("Data has been reset!");
        string audioFilePath = Application.dataPath + "/AudioConfig.txt";
        string bootFilePath = Application.dataPath + "/FirstBoot.txt";
        string leaderboardFilePath = Application.dataPath + "/Leaderboard.txt";

        string defaultContent = "Master Volume: 0\nSFX Volume: 0\nMusic Volume: 0";

        File.WriteAllText(audioFilePath, defaultContent);
        File.WriteAllText(bootFilePath, "TRUE");
        File.WriteAllText(leaderboardFilePath, "");

        audioMixer.SetFloat("Master Volume", 0);
        audioMixer.SetFloat("SFX Volume", 0);
        audioMixer.SetFloat("Music Volume", 0);

        SceneManager.LoadScene("SplashScreen");
    }

    // Plays ResetData animation.
    private void PlayDestroyAnimation()
    {
        if (animator != null)
        {
            animator.SetFloat("Speed", 1f);
            animator.SetBool("isHolding", true);
        }
    }

    // Stops ResetData animation.
    private void StopDestroyAnimation()
    {
        if (animator != null)
        {
            animator.SetFloat("Speed", -3f);
            animator.SetBool("isHolding", false);
        }
    }

    // SFX for the animation.
    private IEnumerator PlayResetSFX()
    {
        float pitch = initialPitch;

        while (isHolding)
        {
            pitch = Mathf.Min(pitch + 0.2f, 3f);
            resetSFX.pitch = pitch;
            resetSFX.Play();

            yield return new WaitForSeconds(delay);
            yield return null;
        }
    }

    // Initializes SFX sequence.
    private void StartPlayingSFX()
    {
        StartCoroutine(PlayResetSFX());
    }

    // Stops SFX sequence.
    private void StopPlayingSFX()
    {
        StopCoroutine(PlayResetSFX());
    }

    public void OnSelect()
    {
        isSelected = true;
    }

    public void OffSelect()
    {
        isSelected = false;
    }
}
