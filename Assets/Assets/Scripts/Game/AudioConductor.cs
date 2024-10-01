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

    private void Start()
    {
        secPerBeat = 60f / bpm;
        dspSongTime = (float)AudioSettings.dspTime; // Records the time when music starts.
    }

    private void Update()
    {
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - offset); // Determins how many seconds since start.
        songPositionInBeats = songPosition / secPerBeat; // Determine how many beats since start
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
}
