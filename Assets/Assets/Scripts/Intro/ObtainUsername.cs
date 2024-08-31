using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtainUsername : MonoBehaviour
{
    private string username;
    public TMPro.TextMeshProUGUI usernameText;

    void Start()
    {
        username = Environment.UserName.ToUpper();
        Debug.Log("Windows Username: " + username);
        StartCoroutine(DisplayUser());
    }

    private IEnumerator DisplayUser()
    {
        usernameText.text = "Welcome, " + username;
        yield return null;
    }
}
