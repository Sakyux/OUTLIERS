using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountStats : MonoBehaviour
{
    public BeatEvent BeatEvent;
    public TextMeshProUGUI ComboText;
    public TextMeshProUGUI ScoreText;

    // ACTIVELY UPDATES STATS DURING GAMEPLAY
    void Update()
    {
        ComboText.text = "COMBO: " + BeatEvent.combo;
        ScoreText.text = "" + BeatEvent.score;
    }
}
