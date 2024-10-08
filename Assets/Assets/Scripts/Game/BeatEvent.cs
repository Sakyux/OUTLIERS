using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class BeatEvent : MonoBehaviour
{
    public SpriteRenderer lane1;
    public SpriteRenderer lane2;
    public SpriteRenderer lane3;

    public Sprite Cross;
    public Sprite Square;
    public Sprite Triangle;
    public Sprite Circle;
    public Sprite UpArrow;
    public Sprite DownArrow;
    public Sprite LeftArrow;
    public Sprite RightArrow;
    public Sprite LeftButton;
    public Sprite RightButton;
    public Sprite LeftTrigger;
    public Sprite RightTrigger;

    public GameObject ComboCounter;
    public GameObject ScoreCounter;

    public float score = 0;
    public float combo = 0;
    public float maxCombo = 0;

    public const float PerfectHit = 300f;
    public const float GoodHit = 100f;
    public const float MehHit = 50f;

    private double PerfectCount = 0;
    private double GoodCount = 0;
    private double MehCount = 0;
    private double MissCount = 0;

    public float Multiplier = 1;

    private string input;

    private bool canInput = false;

    private float currentBeat = 0f;

    public AudioConductor conductor;
    public GameplayControls controls;
    public GameHandler gameHandler;

    private float timeElapsed;
    private float hitMarkerTime = 0f;

    public Animator lane1Animation;
    public Animator lane2Animation;
    public Animator lane3Animation;

    public Image HitMarker;
    public Animator HitMarkerAnimator;

    public Sprite PERFECT;
    public Sprite GOOD;
    public Sprite MEH;
    public Sprite MISS;

    public AudioSource HitSFX;
    public AudioSource ComboBreakSFX;

    public Button ResumeButton;

    public PauseMenu PauseMenu;
    private void Awake()
    {
        controls = new GameplayControls();
        controls.Enable();
    }

    public void Beat(int lane, string key, float position)
    {
        Sprite beatSprite = null;

        // Defines what kind of "Note" appears as.
        switch (key)
        {
            case "Cross":
                beatSprite = Cross;
                break;

            case "Square":
                beatSprite = Square;
                break;

            case "Triangle":
                beatSprite = Triangle;
                break;

            case "Circle":
                beatSprite = Circle;
                break;

            case "UpArrow":
                beatSprite = UpArrow;
                break;

            case "DownArrow":
                beatSprite = DownArrow;
                break;

            case "LeftArrow":
                beatSprite = LeftArrow;
                break;

            case "RightArrow":
                beatSprite = RightArrow;
                break;

            case "LeftButton":
                beatSprite = LeftButton;
                break;

            case "RightButton":
                beatSprite = RightButton;
                break;

            case "LeftTrigger":
                beatSprite = LeftTrigger;
                break;

            case "RightTrigger":
                beatSprite = RightTrigger;
                break;
        }

        // Defines which lane the "Notes" appears in.
        if (beatSprite != null)
        {
            if (conductor.songPositionInBeats >= position - 0.1f && conductor.songPositionInBeats <= position + 0.1f)
            {
                input = key;

                switch (lane)
                {
                    case 1:
                        lane1.sprite = beatSprite;
                        canInput = true;
                        lane1Animation.SetBool("isMiss", false);
                        lane1Animation.SetBool("isHit", false);
                        lane1Animation.Play("SpawnLane1");
                        currentBeat = conductor.songPositionInBeats;
                        break;
                    case 2:
                        lane2.sprite = beatSprite;
                        canInput = true;
                        lane2Animation.SetBool("isMiss", false);
                        lane2Animation.SetBool("isHit", false);
                        lane2Animation.Play("SpawnLane2");
                        currentBeat = conductor.songPositionInBeats;
                        break;
                    case 3:
                        lane3.sprite = beatSprite;
                        canInput = true;
                        lane3Animation.SetBool("isMiss", false);
                        lane3Animation.SetBool("isHit", false);
                        lane3Animation.Play("SpawnLane3");
                        currentBeat = conductor.songPositionInBeats;
                        break;
                }
            }
        }

        else
        {
            Debug.LogError($"Failed to load sprite: {key}");
        }
    }

    private void Update()
    {
        RoundOffScore(); // Rounds off the decimals in Score
        ShowCombo(); // Displays Combo if Combo != 0.
        ShowScore(); // Shows Score if Score != 0.
        UpdateCombo(); // Updates Combo upon each hit or miss.

        // REMOVES HIT MARKER AFTER 3 SEC OF INACTIVITY
        if (HitMarker.sprite != null)
        {
            hitMarkerTime += Time.deltaTime;

            if (hitMarkerTime > 3f)
            {
                HitMarker.sprite = null;
                HitMarker.gameObject.SetActive(false);
                hitMarkerTime = 0f;
            }
        }

        // RESET MULTIPLIER
        if (combo == 0)
        {
            Multiplier = 1f;
        }

        // GAMEPLAY LOGIC
        if (!gameHandler.GetPaused() && controls.Gameplay.enabled)
        {
            // UPON LANE 1 EXIST
            if (lane1.sprite != null)
            {
                float calculateBeat = 0f;
                calculateBeat = conductor.getSongBeatPosition() - currentBeat;
                // Debug.Log("Beat existing for: " + calculateBeat);

                // CHECKS IF NOTES ARE TOO LATE
                if (calculateBeat >= 1.3f && canInput)
                {
                    lane1.sprite = null;
                    input = null;
                    SetMissedHit();
                    ShowHitMarker(MISS);
                    Debug.Log("Missed!");
                    lane1Animation.SetBool("isMiss", true);
                    HitMarkerAnimator.Play("Spawn");
                    timeElapsed = 0f;
                    hitMarkerTime = 0f;
                    MissCount++;
                    canInput = false;
                    return;
                }

                // Checks if "input" is pressed
                if (controls.FindAction(input).WasPressedThisFrame() && canInput && !controls.PauseMenu.Pause.WasPerformedThisFrame() && PauseMenu.IsGameResumed())
                {
                    CalculateScore(calculateBeat, lane1, lane1Animation);
                    hitMarkerTime = 0f;
                }

                // Checks if wrong "input" is pressed
                else if (controls.Any(action => action.WasPressedThisFrame() && !action.Equals(input) && !controls.PauseMenu.Pause.WasPerformedThisFrame()) && PauseMenu.IsGameResumed())
                {
                    SetMissedHit();
                    Debug.Log("Incorrect Input!");
                    timeElapsed = 0f;
                    hitMarkerTime = 0f;
                    canInput = false;
                    ShowHitMarker(MISS);
                    lane1Animation.SetBool("isMiss", true);
                    HitMarkerAnimator.Play("Spawn");
                    StartCoroutine(WaitBeforeDestroy(lane1, lane1Animation));
                }
            }

            // UPON LANE 2 EXIST
            if (lane2.sprite != null)
            {
                float calculateBeat = 0f;
                calculateBeat = conductor.getSongBeatPosition() - currentBeat;
                // Debug.Log("Beat existing for: " + calculateBeat);

                // CHECKS IF NOTES ARE TOO LATE
                if (calculateBeat >= 1.3f && canInput)
                {
                    lane2.sprite = null;
                    input = null;
                    SetMissedHit();
                    ShowHitMarker(MISS);
                    lane2Animation.SetBool("isMiss", true);
                    Debug.Log("Missed!");
                    HitMarkerAnimator.Play("Spawn");
                    timeElapsed = 0f;
                    hitMarkerTime = 0f;
                    MissCount++;
                    canInput = false;
                    return;
                }

                // Checks if "input" is pressed
                if (controls.FindAction(input).WasPressedThisFrame() && canInput && !controls.PauseMenu.Pause.WasPerformedThisFrame() && PauseMenu.IsGameResumed())
                {
                    CalculateScore(calculateBeat, lane2, lane2Animation);
                    hitMarkerTime = 0f;
                }

                // Checks if wrong "input" is pressed
                else if (controls.Any(action => action.WasPressedThisFrame() && !action.Equals(input) && !controls.PauseMenu.Pause.WasPerformedThisFrame()) && PauseMenu.IsGameResumed())
                {
                    SetMissedHit();
                    Debug.Log("Incorrect Input!");
                    timeElapsed = 0f;
                    hitMarkerTime = 0f;
                    canInput = false;
                    ShowHitMarker(MISS);
                    lane2Animation.SetBool("isMiss", true);
                    HitMarkerAnimator.Play("Spawn");
                    StartCoroutine(WaitBeforeDestroy(lane2, lane2Animation));
                }
            }

            // UPON LANE 3 EXIST
            if (lane3.sprite != null)
            {
                float calculateBeat = 0f;
                calculateBeat = conductor.getSongBeatPosition() - currentBeat;

                // CHECKS IF NOTES ARE TOO LATE.
                if (calculateBeat >= 1.3f && canInput)
                {
                    lane3.sprite = null;
                    input = null;
                    SetMissedHit();
                    ShowHitMarker(MISS);
                    Debug.Log("Missed!");
                    lane3Animation.SetBool("isMiss", true);
                    HitMarkerAnimator.Play("Spawn");
                    timeElapsed = 0f;
                    hitMarkerTime = 0f;
                    canInput = false;
                    MissCount++;
                    return;
                }

                // Checks if "input" is pressed
                if (controls.FindAction(input).WasPressedThisFrame() && canInput && !controls.PauseMenu.Pause.WasPerformedThisFrame() && PauseMenu.IsGameResumed())
                {
                    CalculateScore(calculateBeat, lane3, lane3Animation);
                    hitMarkerTime = 0f;
                }

                // Checks if wrong "input" is pressed
                else if (controls.Any(action => action.WasPressedThisFrame() && !action.Equals(input) && !controls.PauseMenu.Pause.WasPerformedThisFrame()) && PauseMenu.IsGameResumed())
                {
                    SetMissedHit();
                    Debug.Log("Incorrect Input!");
                    timeElapsed = 0f;
                    hitMarkerTime = 0f;
                    canInput = false;
                    ShowHitMarker(MISS);
                    lane3Animation.SetBool("isMiss", true);
                    HitMarkerAnimator.Play("Spawn");
                    StartCoroutine(WaitBeforeDestroy(lane3, lane3Animation));
                }
            }

        }
    }

    // Updates score multiplier scaling off of current combo.
    private void UpdateMultiplier()
    {
        Multiplier += (1 + Mathf.Exp(combo/100));
    }

    // Upon "Perfect" hit
    private void SetPerfectHit()
    {
        score += Mathf.Round(PerfectHit * Multiplier);
        combo++;
        HitMarkerAnimator.Play("Spawn");
        HitSFX.Play();
        UpdateMultiplier();
    }

    // Upon "Good" hit
    private void SetGoodHit()
    {
        score += Mathf.Round(GoodHit * Multiplier);
        combo++;
        HitMarkerAnimator.Play("Spawn");
        HitSFX.Play();
        UpdateMultiplier();
    }

    // Upon "Meh" hit
    private void SetMehHit()
    {
        score += Mathf.Round(MehHit * Multiplier);
        combo++;
        HitMarkerAnimator.Play("Spawn");
        HitSFX.Play();
        UpdateMultiplier();
    }

    // Upon miss; resets combo.
    private void SetMissedHit()
    {
        if (combo > 5)
        {
            ComboBreakSFX.Play();
            combo = 0;
        } 
        else combo = 0;

        HitMarker.gameObject.SetActive(true);
        HitMarkerAnimator.Play("Spawn");
    }

    // Shows Combo if Combo != 0.
    private void ShowCombo()
    {
        if (combo > 0 )
        {
            ComboCounter.SetActive(true);
        }

        else if (combo <= 0)
        {
            ComboCounter.SetActive(false);
        }
    }

    // Updates value of maximum combo achieved.
    private void UpdateCombo()
    {
        if (maxCombo <= combo)
        {
            maxCombo = combo;
        }
    }

    // SCORE CALCULATION LOGIC
    private void CalculateScore(float calculateBeat, SpriteRenderer lane, Animator animator)
    {
        // Checks if "input" is pressed
        if (controls.FindAction(input).WasPressedThisFrame() && canInput == true)
        {
            float currentBeat = calculateBeat;
            HitMarker.gameObject.SetActive(true);
            HitMarkerAnimator.Play("Spawn");

            // THE GRAND HOLY JUDGEMENT LINE
            if (currentBeat <= 1f && currentBeat >= 0.80f)
            {
                SetPerfectHit();
                Debug.Log("Perfect Hit!");
                StartCoroutine(WaitBeforeDestroy(lane, animator));
                ShowHitMarker(PERFECT);
                animator.SetBool("isHit", true);
                animator.SetBool("isMiss", false);
                HitSFX.Play();
                PerfectCount++;
                canInput = false;
            }

            else if (currentBeat <= 0.80f && currentBeat > 0.75f)
            {
                SetGoodHit();
                Debug.Log("Good Hit!");
                StartCoroutine(WaitBeforeDestroy(lane, animator));
                ShowHitMarker(GOOD);
                animator.SetBool("isHit", true);
                animator.SetBool("isMiss", false);
                HitSFX.Play();
                GoodCount++;
                canInput = false;
            }

            else if (currentBeat <= 0.75f && currentBeat > 0.70f)
            {
                SetMehHit();
                Debug.Log("Meh Hit!");
                StartCoroutine(WaitBeforeDestroy(lane, animator));
                ShowHitMarker(MEH);
                animator.SetBool("isHit", true);
                animator.SetBool("isMiss", false);
                HitSFX.Play();
                MehCount++;
                canInput = false;
            }

            else if (currentBeat > 1.1f || currentBeat < 0.70f)
            {
                SetMissedHit();
                Debug.Log("Missed!");
                StartCoroutine(WaitBeforeDestroy(lane, animator));
                ShowHitMarker(MISS);
                MissCount++;
                animator.SetBool("isHit", false);
                animator.SetBool("isMiss", true);
            }
        }
    }

    // Displays Score if Score != 0.
    private void ShowScore()
    {
        if (score > 0)
        {
            ScoreCounter.SetActive(true);
        }
    }

    // Delay before notes are destroyed after hit or miss.
    private IEnumerator WaitBeforeDestroy(SpriteRenderer lane, Animator animator)
    {
        if (lane != null)
        {
            yield return new WaitForSeconds(0.3f);
            lane.sprite = null;
        }
    }

    // Rounds off decimals of Score.
    private void RoundOffScore()
    {
        score = Mathf.Round(score);
    }

    // Displays hit marker, such as "Perfect", "Good", "Meh" or "Miss"
    private void ShowHitMarker(Sprite sprite)
    {
        HitMarker.gameObject.SetActive(true);
        HitMarker.sprite = sprite;
    }

    public float GetTotalScore()
    {
        return score;
    }

    public float GetMaxCombo()
    {
        return maxCombo;
    }

    public double GetPerfectCount()
    {
        return PerfectCount;
    }

    public double GetGoodCount()
    {
        return GoodCount;
    }

    public double GetMehCount()
    {
        return MehCount;
    }

    public double GetMissCount()
    {
        return MissCount;
    }

    // Method to disable input.
    public void DisableControls()
    {
        controls.Disable();
    }
}
