using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioConductor : MonoBehaviour
{
    public float bpm;
    public float secPerBeat;
    public float songPosition; // In seconds
    public float songPositionInBeats; // In beats
    public float dspSongTime;
    public float offset;
    public AudioSource musicSource;

    public GameHandler gameHandler;
    public GameplayControls controls;

    // FOR PAUSE SYSTEM
    private float pauseTime = 0f;

    private void Awake()
    {
        controls = new GameplayControls();
        controls.PauseMenu.Enable();
    }

    private void Start()
    {
        secPerBeat = 60f / bpm;
        dspSongTime = (float)AudioSettings.dspTime; // Records the time when music starts.
    }

    private void Update()
    {
        // Pauses the game, somehow.
        if (gameHandler.GetPaused() && controls.PauseMenu.Pause.WasPressedThisFrame()) 
        {
            songPosition = (float)(AudioSettings.dspTime - dspSongTime - offset) - pauseTime;
        }
        
        if (!gameHandler.GetPaused() && controls.PauseMenu.Pause.WasPressedThisFrame())
        {
            pauseTime = (float)(AudioSettings.dspTime - dspSongTime - offset) - songPosition;
        }

        if (!gameHandler.GetPaused())
        {
            songPosition = (float)(AudioSettings.dspTime - dspSongTime - offset) - pauseTime; // Determine how many seconds since start.
            songPositionInBeats = songPosition / secPerBeat; // Determine how many beats since start
        }
    }

    public float getSongPosition()
    {
        return songPosition;
    }

    public float getSongBeatPosition()
    {
        return songPositionInBeats;
    }

    public float getSecPerBeat()
    {
        return secPerBeat;
    }

    public void SetPauseTime()
    {
        pauseTime = (float)(AudioSettings.dspTime - dspSongTime - offset) - songPosition;
    }
}
