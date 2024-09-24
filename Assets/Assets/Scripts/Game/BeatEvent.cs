using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Linq;

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

    public float score = 0;
    public int combo = 0;

    public const float PerfectHit = 300f;
    public const float GoodHit = 100f;
    public const float MehHit = 50f;

    public float Multiplier = 1;

    private string input;

    private AudioConductor conductor;

    GameplayControls controls;

    private void Start()
    {

    }

    public void Beat(int lane, string key, float position)
    {
        Sprite beatSprite = null;

        switch (key)
        {
            case "Cross":
                beatSprite = cross;
                input = key;
                break;

            case "Square":
                beatSprite = square;
                input = key;
                break;

            case "Triangle":
                beatSprite = triangle;
                input = key;
                break;

            case "Circle":
                beatSprite = circle;
                input = key;
                break;

            case "UpArrow":
                beatSprite = upArrow;
                input = key;
                break;

            case "DownArrow":
                beatSprite = downArrow;
                input = key;
                break;

            case "LeftArrow":
                beatSprite = leftArrow;
                input = key;
                break;

            case "RightArrow":
                beatSprite = rightArrow;
                input = key;
                break;

            case "LeftButton":
                beatSprite = leftButton;
                input = key;
                break;

            case "RightButton":
                beatSprite = rightButton;
                input = key;
                break;

            case "LeftTrigger":
                beatSprite = leftTrigger;
                input = key;
                break;

            case "RightTrigger":
                beatSprite = rightTrigger;
                input = key;
                break;
        }

        if (beatSprite != null)
        {
            switch (lane)
            {
                case 1:
                    lane1.sprite = beatSprite;
                    break;
                case 2:
                    lane2.sprite = beatSprite;
                    break;
                case 3:
                    lane3.sprite = beatSprite;
                    break;
            }
        }
        else
        {
            Debug.LogError($"Failed to load sprite: {key}");
        }
    }

    private void Update()
    {
        if (lane1.sprite != null)
        {
            float timeElapsed = -1f;

            timeElapsed += Time.deltaTime;

            if (timeElapsed > 1f)
            {
                lane1.sprite = null;
                input = null;
                ResetCombo();
            }

            if (controls.FindAction(input).WasPressedThisFrame())
            {
                if (timeElapsed <= -0.25f || timeElapsed >= 0.25f)
                {
                    SetPerfectHit();
                    Debug.Log("Perfect Hit!");
                }

                else if (timeElapsed >= -0.75f && timeElapsed > -0.25f || timeElapsed <= 0.75f && timeElapsed < 0.25f)
                {
                    SetGoodHit();
                    Debug.Log("Good Hit!");
                }

                else if (timeElapsed < -0.75f || timeElapsed > 0.75f)
                {
                    SetMehHit();
                    Debug.Log("Meh Hit!");
                }

            } else if (controls.Any(action => action.WasPressedThisFrame() && !controls.FindAction(input).WasPressedThisFrame()))
            {
                ResetCombo();
                Debug.Log("Incorrect Input!");
            }
        }

        // UPDATING MULTIPLIER
        if (combo != 0)
        {
            Multiplier += (combo / 100);
        }
        else Multiplier = 1f;
    }

    private void SetPerfectHit()
    {
        score += PerfectHit;
        combo++;
    }

    private void SetGoodHit()
    {
        score += GoodHit;
        combo++;
    }

    private void SetMehHit()
    {
        score += MehHit;
        combo++;
    }

    private void ResetCombo()
    {
        combo = 0;
    }
}
