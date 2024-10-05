using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Beatmaps : MonoBehaviour
{
    public BeatEvent BeatEvent;
    public GameHandler GameHandler;

    public AudioConductor AudioConductor;

    public Animator JudgementLine;

    public GameObject PauseBG;

    public GameplayControls controls;
    
    public GameObject ResultsMusic;
    private bool showResults = false;
    public TextMeshProUGUI ResultsText;

    public GameObject exitTransition;
    public Animator exitAnimation;

    public GameObject inputMenu;
    public TMP_InputField inputField;

    public UploadScore uploadScore;

    public GameObject hitMarker;

    private string filePath = Path.Combine(Application.dataPath, "leaderboard");

    private void Awake()
    {
        controls = new GameplayControls();
        controls.Enable();
    }

    private void Update()
    {
        if (GameHandler.HasCloseTutorial() == true)
        {
            BeatEvent.Beat(2, "Cross", 8f);
            BeatEvent.Beat(2, "Cross", 10f);
            BeatEvent.Beat(2, "Square", 12f);
            BeatEvent.Beat(2, "Cross", 14f);
            BeatEvent.Beat(2, "Triangle", 16f);
            BeatEvent.Beat(2, "Circle", 18f);
            BeatEvent.Beat(2, "RightButton", 20f);

            BeatEvent.Beat(1, "LeftButton", 22f);
            BeatEvent.Beat(3, "RightButton", 24f);
            BeatEvent.Beat(1, "LeftArrow", 26f);
            BeatEvent.Beat(2, "UpArrow", 28f);
            BeatEvent.Beat(1, "LeftButton", 30f);
            BeatEvent.Beat(1, "LeftArrow", 32f);
            BeatEvent.Beat(3, "RightArrow", 34f);
            BeatEvent.Beat(2, "Circle", 36f);
            BeatEvent.Beat(3, "Cross", 38f);

            BeatEvent.Beat(1, "UpArrow", 40f);
            BeatEvent.Beat(3, "Triangle", 42f);
            BeatEvent.Beat(3, "Triangle", 44f);
            BeatEvent.Beat(1, "Cross", 46f);
            BeatEvent.Beat(2, "DownArrow", 48f);
            BeatEvent.Beat(3, "Circle", 50f);
            BeatEvent.Beat(1, "Square", 52f);
            BeatEvent.Beat(2, "RightArrow", 54f);
            BeatEvent.Beat(1, "LeftArrow", 56f);
            BeatEvent.Beat(3, "RightButton", 58f);

            BeatEvent.Beat(2, "Square", 60f);
            BeatEvent.Beat(3, "Square", 62f);
            BeatEvent.Beat(1, "Cross", 64f);
            BeatEvent.Beat(3, "RightTrigger", 66f);
            BeatEvent.Beat(2, "Square", 68f);
            BeatEvent.Beat(1, "LeftButton", 70f);
            BeatEvent.Beat(1, "Square", 72f);
            BeatEvent.Beat(2, "Cross", 74f);
            BeatEvent.Beat(1, "Square", 76f);
            BeatEvent.Beat(2, "RightButton", 78f);
            BeatEvent.Beat(3, "Triangle", 80f);
            BeatEvent.Beat(3, "Cross", 82f);
            BeatEvent.Beat(2, "DownArrow", 84f);
            BeatEvent.Beat(3, "Circle", 86f);
            BeatEvent.Beat(3, "Square", 88f);
            BeatEvent.Beat(3, "RightArrow", 90f);
            BeatEvent.Beat(1, "LeftArrow", 92f);
            BeatEvent.Beat(3, "RightButton", 94f);
            BeatEvent.Beat(2, "Cross", 96f);
            BeatEvent.Beat(3, "Triangle", 98f);
            BeatEvent.Beat(2, "Cross", 100f);
            BeatEvent.Beat(2, "Triangle", 102f);
            BeatEvent.Beat(1, "Circle", 104f);
            BeatEvent.Beat(2, "Triangle", 106f);
            BeatEvent.Beat(1, "Circle", 108f);
            BeatEvent.Beat(3, "Triangle", 110f);
            BeatEvent.Beat(2, "DownArrow", 112f);

            BeatEvent.Beat(1, "UpArrow", 114f);
            BeatEvent.Beat(3, "Triangle", 116f);
            BeatEvent.Beat(1, "Cross", 118f);
            BeatEvent.Beat(2, "DownArrow", 120f);
            BeatEvent.Beat(3, "Circle", 122f);
            BeatEvent.Beat(1, "Square", 124);
            BeatEvent.Beat(3, "RightArrow", 126f);
            BeatEvent.Beat(2, "LeftArrow", 128f);
            BeatEvent.Beat(3, "RightButton", 130f);

            BeatEvent.Beat(1, "UpArrow", 132f);
            BeatEvent.Beat(3, "Triangle", 134f);
            BeatEvent.Beat(1, "Cross", 136f);
            BeatEvent.Beat(2, "DownArrow", 138f);
            BeatEvent.Beat(3, "Circle", 140f);
            BeatEvent.Beat(1, "Square", 142f);
            BeatEvent.Beat(2, "RightArrow", 144f);
            BeatEvent.Beat(1, "LeftArrow", 146f);
            BeatEvent.Beat(3, "RightButton", 148f);

            BeatEvent.Beat(2, "Cross", 150f);
            BeatEvent.Beat(2, "Cross", 152f);
            BeatEvent.Beat(2, "Square", 154f);
            BeatEvent.Beat(2, "Cross", 156f);
            BeatEvent.Beat(2, "Triangle", 158f);
            BeatEvent.Beat(2, "Circle", 160f);
            BeatEvent.Beat(3, "RightButton", 162f);

            BeatEvent.Beat(1, "LeftButton", 164f);
            BeatEvent.Beat(3, "RightButton", 166f);
            BeatEvent.Beat(1, "LeftArrow", 168f);
            BeatEvent.Beat(2, "UpArrow", 170f);
            BeatEvent.Beat(1, "LeftButton", 172f);
            BeatEvent.Beat(1, "LeftArrow", 174f);
            BeatEvent.Beat(2, "RightArrow", 176f);
            BeatEvent.Beat(2, "Circle", 178f);
            BeatEvent.Beat(3, "Cross", 180f);

            BeatEvent.Beat(1, "UpArrow", 182f);
            BeatEvent.Beat(3, "Triangle", 184f);
            BeatEvent.Beat(3, "Triangle", 186f);
            BeatEvent.Beat(1, "Cross", 188f);
            BeatEvent.Beat(2, "DownArrow", 190f);
            BeatEvent.Beat(3, "Circle", 192f);
            BeatEvent.Beat(1, "Square", 194f);
            BeatEvent.Beat(1, "RightArrow", 196f);
            BeatEvent.Beat(1, "LeftArrow", 198f);
            BeatEvent.Beat(3, "RightButton", 200f);

            BeatEvent.Beat(2, "Square", 202f);
            BeatEvent.Beat(3, "Square", 204f);
            BeatEvent.Beat(1, "Cross", 206f);
            BeatEvent.Beat(3, "RightTrigger", 208f);
            BeatEvent.Beat(2, "Square", 210f);
            BeatEvent.Beat(1, "LeftButton", 212f);
            BeatEvent.Beat(1, "Square", 214f);
            BeatEvent.Beat(2, "Cross", 216f);
            BeatEvent.Beat(1, "Square", 218f);
            BeatEvent.Beat(2, "RightButton", 220f);
            BeatEvent.Beat(3, "Triangle", 222f);
            BeatEvent.Beat(3, "Cross", 224f);
            BeatEvent.Beat(2, "DownArrow", 226f);
            BeatEvent.Beat(3, "Circle", 228f);
            BeatEvent.Beat(3, "Square", 230f);
            BeatEvent.Beat(3, "RightArrow", 232f);
            BeatEvent.Beat(1, "LeftArrow", 234f);
            BeatEvent.Beat(3, "RightButton", 236f);
            BeatEvent.Beat(2, "Cross", 238f);
            BeatEvent.Beat(3, "RightButton", 240f);
            BeatEvent.Beat(2, "Cross", 242f);
            BeatEvent.Beat(3, "RightButton", 244f);
            BeatEvent.Beat(2, "Circle", 246f);
            BeatEvent.Beat(1, "LeftTrigger", 248f);
            BeatEvent.Beat(2, "Circle", 250f);
            BeatEvent.Beat(1, "LeftTrigger", 252f);
            BeatEvent.Beat(2, "DownArrow", 254f);

            BeatEvent.Beat(2, "UpArrow", 256f);
            BeatEvent.Beat(3, "Triangle", 258f);
            BeatEvent.Beat(1, "Cross", 260f);
            BeatEvent.Beat(2, "DownArrow", 262f);
            BeatEvent.Beat(3, "Circle", 264f);
            BeatEvent.Beat(1, "Square", 266);
            BeatEvent.Beat(3, "RightArrow", 268f);
            BeatEvent.Beat(1, "LeftArrow", 270f);
            BeatEvent.Beat(3, "RightButton", 272f);

            BeatEvent.Beat(1, "Cross", 274f);
        }

        if (AudioConductor.getSongBeatPosition() >= 276f)
        {
            JudgementLine.SetBool("Song End", true);
            JudgementLine.SetFloat("Speed", -2);
            controls.Disable();

            StartCoroutine(DisableHitMarker());
            StartCoroutine(ShowResults());
        }

        if (uploadScore.GetEnteredInput())
        {
            CalculateResults();

            if (!showResults && Input.GetButton("Submit"))
            {
                string leaderboard = "";
                showResults = true;

                if (File.Exists(filePath))
                {
                    leaderboard = File.ReadAllText(filePath);
                    ResultsText.text = leaderboard;
                }
                else
                {
                    Debug.LogError("File not found: " + filePath);
                }

                if  (showResults && Input.GetButton("Submit"))
                {
                    exitTransition.SetActive(true);
                    exitAnimation.Play("W-B D-U");
                }
            }
        }
    }

    private IEnumerator ShowResults()
    {
        yield return new WaitForSeconds(3f);

        PauseBG.SetActive(true);
        inputMenu.SetActive(true);

        ResultsMusic.SetActive(true);
        EventSystem.current.SetSelectedGameObject(inputField.gameObject);
    }

    private IEnumerator ReturnToTitle()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("TitleScreen");
    }

    public string CalculateResults() 
    {
        ResultsText.text = "TOTAL SCORE: " + BeatEvent.GetTotalScore()
        + "\nMAX COMBO: " + BeatEvent.GetMaxCombo()
        + "\n\nPERFECT HITS: " + BeatEvent.GetPerfectCount()
        + "\nGOOD HITS: " + BeatEvent.GetGoodCount()
        + "\nMEH HITS" + BeatEvent.GetMehCount()
        + "\nMISS HITS" + BeatEvent.GetMissCount()
        + "\n\nLEVEL COMPLETE!";

        return ResultsText.text;
    }

    private IEnumerator DisableHitMarker()
    {
        yield return new WaitForSeconds(1f);
        hitMarker.SetActive(false);
    }
}
