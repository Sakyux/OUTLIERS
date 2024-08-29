using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsBehavior : MonoBehaviour
{
    public AudioSource ClickSFX;

    public float masterVolume = 1.0f;
    public float sfxVolume = 1.0f;
    public float musicVolume = 1.0f;

    public void PlayClickSFX()
    {
        ClickSFX.Play();
    }
}
