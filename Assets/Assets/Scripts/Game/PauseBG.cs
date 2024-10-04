using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBG : MonoBehaviour
{
    public GameObject background;
    public AudioSource pauseSFX;
    public AudioSource resumeSFX;
    public AudioSource backgroundSFX;

    public GameplayControls controls;
    public GameHandler gameHandler;

    public Animator animator;

    private void Awake()
    {
        controls = new GameplayControls();
        controls.PauseMenu.Pause.Enable();

        animator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    void Update()
    {
        if (controls.PauseMenu.Pause.WasPressedThisFrame() && background.activeInHierarchy && gameHandler.HasCloseTutorial())
        {
            pauseSFX.Play();
            backgroundSFX.Play();
        }

        else if (controls.PauseMenu.Pause.WasPressedThisFrame() && !background.activeInHierarchy && gameHandler.HasCloseTutorial())
        {
            resumeSFX.Play();
            backgroundSFX.Stop();
        }
    }

    public void StopBackgroundSFX()
    {
        backgroundSFX.Stop();
    }
}
