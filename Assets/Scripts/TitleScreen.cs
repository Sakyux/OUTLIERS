using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TitleScreen : BootSequence
{
    private string username = (System.Environment.UserName);
    public TMP_Text welcomeMessage;


    private void Start()
    {
        if (loadComplete == true)
        {
            welcomeMessage.text = "Welcome Back";
        }
    }
}
