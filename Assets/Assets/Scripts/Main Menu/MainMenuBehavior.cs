using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuBehavior : MonoBehaviour
{
    [SerializeField] Animator transitionAnim;

    public void StartGame()
    {
        StartCoroutine(LoadLevel());
    }

    public void Settings()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public IEnumerator LoadLevel()
    {
        transitionAnim.SetTrigger("OnClick");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("DefaultScreen");
    }

}
