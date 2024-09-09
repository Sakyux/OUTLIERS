using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public GameObject StartAnimation;
    public GameObject Music;

    public void Start()
    {
        StartCoroutine(StartDelay());
    }

    private IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(1f);
        StartAnimation.SetActive(true);
        StartCoroutine(PlayMusic());
    }

    private IEnumerator PlayMusic()
    {
        yield return new WaitForSeconds(5f);
        Music.SetActive(true);
        yield return null;
    }
}
