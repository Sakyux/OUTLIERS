using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Beatmaps : MonoBehaviour
{
    public BeatEvent BeatEvent;
    public GameHandler GameHandler;

    

    private void Start()
    {
        
    }

    private void Update()
    {
        if (GameHandler.HasCloseTutorial() == true)
        {

        }
    }

}
