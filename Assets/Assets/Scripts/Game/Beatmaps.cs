using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Beatmaps : MonoBehaviour
{
    public BeatEvent BeatEvent;
    public GameHandler GameHandler;

    private void Update()
    {
        if (GameHandler.HasCloseTutorial() == true)
        {
            BeatEvent.Beat(2, "Cross", 8f);
            BeatEvent.Beat(2, "Square", 10f);
            BeatEvent.Beat(2, "Cross", 12f);
            BeatEvent.Beat(2, "Triangle", 14f);
            BeatEvent.Beat(2, "Circle", 16f);
            BeatEvent.Beat(2, "RightButton", 18f);
            BeatEvent.Beat(2, "RightButton", 20f);
            BeatEvent.Beat(2, "RightButton", 22f);
        }
    }

}
