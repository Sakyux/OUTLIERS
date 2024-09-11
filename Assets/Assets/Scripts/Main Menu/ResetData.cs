using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
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
    public float initialPitch;
    public float delay = 0.1f;

    public Animator animator;

    private void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            isHolding = true;
            StartPlayingSFX();
            PlayDestroyAnimation();
            Debug.Log("Currently holding: TRUE");
            
        }

        if (Input.GetButtonUp("Submit"))
        {
            Reset();
            StopPlayingSFX();
            StopDestroyAnimation();
            Debug.Log("Currently holding: FALSE");
        }

        if (isHolding)
        {
            currentHoldTime += Time.deltaTime;

            if (currentHoldTime >= requiredHoldTime)
            {
                if (onLongClick != null) onLongClick.Invoke();

                Reset();
                HoldResetData();
            }
        }
    }

    private void Reset()
    {
        isHolding = false;
        currentHoldTime = 0f;
    }

    public void HoldResetData()
    {
        Debug.Log("Data has been reset!");
        string audioFilePath = Application.dataPath + "/AudioConfig.txt";
        string bootFilePath = Application.dataPath + "/FirstBoot.txt";

        string defaultContent = "Master Volume: 0\nSFX Volume: 0\nMusic Volume: 0";

        File.WriteAllText(audioFilePath, defaultContent);
        File.WriteAllText(bootFilePath, "TRUE");

        audioMixer.SetFloat("Master Volume", 0);
        audioMixer.SetFloat("SFX Volume", 0);
        audioMixer.SetFloat("Music Volume", 0);

        SceneManager.LoadScene("SplashScreen");
    }

    private void PlayDestroyAnimation()
    {
        if (animator != null)
        {
            animator.SetFloat("Speed", 1f);
            animator.SetBool("isHolding", true);
        }
    }

    private void StopDestroyAnimation()
    {
        if (animator != null)
        {
            animator.SetFloat("Speed", -3f);
            animator.SetBool("isHolding", false);
        }
    }

    private IEnumerator PlayResetSFX()
    {
        float pitch = initialPitch;

        while (isHolding == true)
        {
            pitch = Mathf.Min(pitch + 0.2f, 3f);
            resetSFX.pitch = pitch;
            resetSFX.Play();

            yield return new WaitForSeconds(delay);
            yield return null;
        }
    }

    private void StartPlayingSFX()
    {
        StartCoroutine(PlayResetSFX());
    }

    private void StopPlayingSFX()
    {
        StopCoroutine(PlayResetSFX());
    }
}
