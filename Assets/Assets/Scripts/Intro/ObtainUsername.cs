using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ObtainUsername : MonoBehaviour
{
    private string username;
    private string ipAddress;
    public TMPro.TextMeshProUGUI usernameText;

    void Start()
    {
        username = Environment.UserName.ToUpper();
        Debug.Log("Windows Username: " + username);
        StartCoroutine(DisplayUser());

        
        Debug.Log("Local IP Address: " + ipAddress);
    }

    private IEnumerator DisplayUser()
    {
        usernameText.text = "Welcome, " + username;
        yield return null;
    }

    
}
