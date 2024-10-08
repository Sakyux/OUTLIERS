using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class Beatmaps : MonoBehaviour
{
    public BeatEvent BeatEvent;
    public GameHandler GameHandler;

    public AudioConductor AudioConductor;

    public Animator JudgementLine;

    public GameObject PauseBGObject;

    public GameplayControls controls;
    
    public GameObject ResultsMusic;
    private bool showResults = false;
    public TextMeshProUGUI ResultsText;
    public GameObject ResultsObject;

    public GameObject exitTransition;
    public Animator exitAnimation;

    public GameObject inputMenu;
    public TMP_InputField inputField;

    public UploadScore uploadScore;

    public GameObject Stats;
    public GameObject InputFieldObject;
    public GameObject headers;
    public GameObject inputUI;

    public GameObject endLevel;
    public GameObject GameplayMusic;

    public PauseBG PauseBG;

    private bool endAnimation = false;
    private float timeElapsed = 0f;
    private bool isFinished = false;

    private string filePath = Path.Combine(Application.dataPath, "Leaderboard.txt");

    private void Awake()
    {
        controls = new GameplayControls();
        controls.Enable();
    }

    private void Update()
    {
        // BLUEPRINT FOR HOW THE "NOTES" APPEAR
        // PARAMETERS: lane number, button type, appears at...
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
            BeatEvent.Beat(3, "RightTrigger", 98f);
            BeatEvent.Beat(2, "Cross", 100f);
            BeatEvent.Beat(2, "LeftTrigger", 102f);
            BeatEvent.Beat(1, "Circle", 104f);
            BeatEvent.Beat(2, "RightButton", 106f);
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
            BeatEvent.Beat(2, "LeftButton", 128f);
            BeatEvent.Beat(3, "RightButton", 130f);
        }

        // Function for end of beatmap.
        if (AudioConductor.getSongBeatPosition() >= 136f)
        {
            JudgementLine.SetBool("Song End", true); // Set bool for animation parameter.
            JudgementLine.SetFloat("Speed", -2); // Reverse Judgement Line animation.
            GameHandler.DisableBackground();

            // DISABLES ALL CONTROLS AFTER GAMEPLAY ENDS.
            controls.Disable();
            BeatEvent.DisableControls();
            GameHandler.DisableControls();
            PauseBG.DisableControls();

            // DISABLES GAMEPLAY UI AFTER GAMEPLAY ENDS.
            StartCoroutine(DisableHitMarker());
            StartCoroutine(InputUsername());
        }

        // Function that triggers after animation has played.
        if (AudioConductor.getSongBeatPosition() >= 136f && endAnimation == true)
        {
            GameplayMusic.SetActive(false);
            CalculateResults();
            string leaderboard = "";
            inputUI.SetActive(true);

            if (!InputFieldObject.activeInHierarchy)
            {
                timeElapsed += Time.deltaTime;
            }

            // Shows player score.
            if (!InputFieldObject.activeInHierarchy && !isFinished)
            {
                ResultsObject.SetActive(true);

                if (timeElapsed > 1f)
                {
                    showResults = true;
                }

                // Shows leaderboard.
                if (showResults && Input.GetButtonDown("Submit"))
                {
                    if (File.Exists(filePath))
                    {
                        headers.SetActive(true);
                        leaderboard = File.ReadAllText(filePath);
                        ResultsText.text = leaderboard;
                        timeElapsed = 0f;
                        isFinished = true;
                    }
                    else
                    {
                        Debug.LogError("File not found: " + filePath);
                    }
                }
            }

            // Exits game and returns to Title Screen.
            if (isFinished && Input.GetButtonDown("Submit") && timeElapsed > 1f)
            {
                if (Input.GetButtonDown("Submit"))
                {
                    exitTransition.SetActive(true);
                    exitAnimation.Play("W-B D-U"); 
                    StartCoroutine(ReturnToTitle());
                }
            }
        }
    }

    // Sequence after gameplay ends.
    private IEnumerator InputUsername()
    {
        endLevel.SetActive(true);
        controls.PauseMenu.Pause.Disable();
        yield return new WaitForSeconds(3f);

        PauseBGObject.SetActive(true);
        inputMenu.SetActive(true);

        ResultsMusic.SetActive(true);
        EventSystem.current.SetSelectedGameObject(inputField.gameObject);
        endAnimation = true;
    }

    private IEnumerator ReturnToTitle()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("TitleScreen");
    }

    // Returns string to TextMeshPro.
    public string CalculateResults() 
    {
        if (!showResults)
        {
            ResultsText.text = "TOTAL SCORE: " + BeatEvent.GetTotalScore()
        + "\nMAX COMBO: " + BeatEvent.GetMaxCombo()
        + "\n\nPERFECT HITS: " + BeatEvent.GetPerfectCount()
        + "\nGOOD HITS: " + BeatEvent.GetGoodCount()
        + "\nMEH HITS: " + BeatEvent.GetMehCount()
        + "\nMISS HITS: " + BeatEvent.GetMissCount()
        + "\n\nLEVEL COMPLETE!";
        }

        return ResultsText.text;
    }

    // Disables Hit Marker after gameplay.
    private IEnumerator DisableHitMarker()
    {
        yield return new WaitForSeconds(0.2f);
        Stats.SetActive(false);
    }
}
