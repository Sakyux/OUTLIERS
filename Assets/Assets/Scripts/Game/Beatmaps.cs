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
            BeatEvent.Beat(2, "Square", 8f);
            BeatEvent.Beat(2, "Square", 10f);
            BeatEvent.Beat(2, "Square", 12f);
            BeatEvent.Beat(2, "Square", 14f);
            BeatEvent.Beat(2, "Square", 16f);
            BeatEvent.Beat(2, "Square", 18f);
            BeatEvent.Beat(2, "Square", 20f);
        }
    }

}
