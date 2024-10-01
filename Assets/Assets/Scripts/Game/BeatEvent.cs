using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Linq;
using UnityEngine.VFX;
using TMPro;
using Autodesk.Fbx;

public class BeatEvent : MonoBehaviour
{
    public SpriteRenderer lane1;
    public SpriteRenderer lane2;
    public SpriteRenderer lane3;

    public Sprite cross;
    public Sprite square;
    public Sprite triangle;
    public Sprite circle;
    public Sprite upArrow;
    public Sprite downArrow;
    public Sprite leftArrow;
    public Sprite rightArrow;
    public Sprite leftButton;
    public Sprite rightButton;
    public Sprite leftTrigger;
    public Sprite rightTrigger;

    public GameObject ComboCounter;
    public GameObject ScoreCounter;

    public float score = 0;
    public float combo = 0;

    public const float PerfectHit = 300f;
    public const float GoodHit = 100f;
    public const float MehHit = 50f;

    public float Multiplier = 1;

    private string input;

    private bool canInput = false;

    private float currentBeat = 0f;

    public AudioConductor conductor;

    public GameplayControls controls;

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

    private void Awake()
    {
        controls = new GameplayControls();
        controls.Enable();
    }

    public void Beat(int lane, string key, float position)
    {
        Sprite beatSprite = null;

        switch (key)
        {
            case "Cross":
                beatSprite = cross;
                break;

            case "Square":
                beatSprite = square;
                break;

            case "Triangle":
                beatSprite = triangle;
                break;

            case "Circle":
                beatSprite = circle;
                break;

            case "UpArrow":
                beatSprite = upArrow;
                break;

            case "DownArrow":
                beatSprite = downArrow;
                break;

            case "LeftArrow":
                beatSprite = leftArrow;
                break;

            case "RightArrow":
                beatSprite = rightArrow;
                break;

            case "LeftButton":
                beatSprite = leftButton;
                break;

            case "RightButton":
                beatSprite = rightButton;
                break;

            case "LeftTrigger":
                beatSprite = leftTrigger;
                break;

            case "RightTrigger":
                beatSprite = rightTrigger;
                break;
        }

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
                        lane1Animation.Play("SpawnLane1");
                        currentBeat = conductor.songPositionInBeats;
                        break;
                    case 2:
                        lane2.sprite = beatSprite;
                        canInput = true;
                        lane2Animation.Play("SpawnLane2");
                        currentBeat = conductor.songPositionInBeats;
                        break;
                    case 3:
                        lane3.sprite = beatSprite;
                        canInput = true;
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
        ShowCombo();
        ShowScore();
        RoundOffScore();

        // REMOVES HIT MARKER AFTER 3 SEC
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

        // UPON LANE 1 EXIST
        if (lane1.sprite != null)
        {
            float calculateBeat = 0f;
            calculateBeat = conductor.getSongBeatPosition() - currentBeat;
            // Debug.Log("Beat existing for: " + calculateBeat);

            if (calculateBeat >= 1.3f && canInput)
            {
                lane1.sprite = null;
                input = null;
                SetMissedHit();
                ShowHitMarker(MISS);
                Debug.Log("Missed!");
                HitMarkerAnimator.Play("Spawn");
                timeElapsed = 0f;
                hitMarkerTime = 0f;
                canInput = false;
                return;
            }

            // Checks if "input" is pressed
            if (controls.FindAction(input).WasPressedThisFrame() && canInput)
            {
                CalculateScore(calculateBeat, lane1);
                hitMarkerTime = 0f;
            }

            // Checks if wrong "input" is pressed
            else if (controls.Any(action => action.WasPressedThisFrame() && !action.Equals(input)))
            {
                SetMissedHit();
                Debug.Log("Incorrect Input!");
                timeElapsed = 0f;
                hitMarkerTime = 0f;
                canInput = false;
                ShowHitMarker(MISS);
                HitMarkerAnimator.Play("Spawn");
                StartCoroutine(WaitBeforeDestroy(lane1));
            }
        }

        // UPON LANE 2 EXIST
        if (lane2.sprite != null)
        {
            float calculateBeat = 0f;
            calculateBeat = conductor.getSongBeatPosition() - currentBeat;
            // Debug.Log("Beat existing for: " + calculateBeat);

            if (calculateBeat >= 1.3f && canInput)
            {
                lane2.sprite = null;
                input = null;
                SetMissedHit();
                ShowHitMarker(MISS);
                Debug.Log("Missed!");
                HitMarkerAnimator.Play("Spawn");
                timeElapsed = 0f;
                hitMarkerTime = 0f;
                canInput = false;
                return;
            }

            // Checks if "input" is pressed
            if (controls.FindAction(input).WasPressedThisFrame() && canInput)
            {
                CalculateScore(calculateBeat, lane2);
                hitMarkerTime = 0f;
            }

            // Checks if wrong "input" is pressed
            else if (controls.Any(action => action.WasPressedThisFrame() && !action.Equals(input)))
            {
                SetMissedHit();
                Debug.Log("Incorrect Input!");
                timeElapsed = 0f;
                hitMarkerTime = 0f;
                canInput = false;
                ShowHitMarker(MISS);
                HitMarkerAnimator.Play("Spawn");
                StartCoroutine(WaitBeforeDestroy(lane2));
            }
        }

        // UPON LANE 3 EXIST
        if (lane3.sprite != null)
        {
            float calculateBeat = 0f;
            calculateBeat = conductor.getSongBeatPosition() - currentBeat;

            if (calculateBeat >= 1.3f && canInput)
            {
                lane3.sprite = null;
                input = null;
                SetMissedHit();
                ShowHitMarker(MISS);
                Debug.Log("Missed!");
                HitMarkerAnimator.Play("Spawn");
                timeElapsed = 0f;
                hitMarkerTime = 0f;
                canInput = false;
                return;
            }

            // Checks if "input" is pressed
            if (controls.FindAction(input).WasPressedThisFrame() && canInput)
            {
                CalculateScore(calculateBeat, lane3);
                hitMarkerTime = 0f;
            }

            // Checks if wrong "input" is pressed
            else if (controls.Any(action => action.WasPressedThisFrame() && !action.Equals(input)))
            {
                SetMissedHit();
                Debug.Log("Incorrect Input!");
                timeElapsed = 0f;
                hitMarkerTime = 0f;
                canInput = false;
                ShowHitMarker(MISS);
                HitMarkerAnimator.Play("Spawn");
                StartCoroutine(WaitBeforeDestroy(lane3));
            }
        }
    }

    private void UpdateMultiplier()
    {
        Multiplier += (combo / 100);
    }

    private void SetPerfectHit()
    {
        score += PerfectHit * Multiplier;
        combo++;
        HitMarkerAnimator.Play("Spawn");
        UpdateMultiplier();
    }

    private void SetGoodHit()
    {
        score += GoodHit * Multiplier;
        combo++;
        HitMarkerAnimator.Play("Spawn");
        UpdateMultiplier();
    }

    private void SetMehHit()
    {
        score += MehHit * Multiplier;
        combo++;
        HitMarkerAnimator.Play("Spawn");
        UpdateMultiplier();
    }

    private void SetMissedHit()
    {
        combo = 0;
        HitMarker.gameObject.SetActive(true);
        HitMarkerAnimator.Play("Spawn");
    }

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

    private void CalculateScore(float calculateBeat, SpriteRenderer lane)
    {
        // Checks if "input" is pressed
        if (controls.FindAction(input).WasPressedThisFrame() && canInput == true)
        {
            float currentBeat = calculateBeat;
            HitMarker.gameObject.SetActive(true);
            HitMarkerAnimator.Play("Spawn");

            // SECOND WORKING ITERATION OF THE JUDGEMENT LINE ----- TWEAKED VALUES FOR DIFFICULT BALANCING
            if (currentBeat <= 1f && currentBeat >= 0.90f)
            {
                SetPerfectHit();
                Debug.Log("Perfect Hit!");
                StartCoroutine(WaitBeforeDestroy(lane));
                ShowHitMarker(PERFECT);
                canInput = false;
            }

            else if (currentBeat <= 0.90f && currentBeat > 0.70f)
            {
                SetGoodHit();
                Debug.Log("Good Hit!");
                StartCoroutine(WaitBeforeDestroy(lane));
                ShowHitMarker(GOOD);
                canInput = false;
            }

            else if (currentBeat <= 0.70f && currentBeat > 0.60f)
            {
                SetMehHit();
                Debug.Log("Meh Hit!");
                StartCoroutine(WaitBeforeDestroy(lane));
                ShowHitMarker(MEH);
                canInput = false;
            }

            else if (currentBeat > 1.1f || currentBeat < 0.60f)
            {
                SetMissedHit();
                Debug.Log("Missed!");
                StartCoroutine(WaitBeforeDestroy(lane));
                ShowHitMarker(MISS);
            }
        }
    }

    private void ShowScore()
    {
        if (score > 0)
        {
            ScoreCounter.SetActive(true);
        }
    }

    private IEnumerator WaitBeforeDestroy(SpriteRenderer lane)
    {
        yield return new WaitForSeconds(0.1f);
        lane.sprite = null;
    }

    private void RoundOffScore()
    {
        score = Mathf.Round(score);
    }

    private void ShowHitMarker(Sprite sprite)
    {
        HitMarker.gameObject.SetActive(true);
        HitMarker.sprite = sprite;
    }
}
