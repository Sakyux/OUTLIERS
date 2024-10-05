using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class UploadScore : MonoBehaviour
{
    private TMP_InputField inputField;
    public GameObject inputObject;
    public Beatmaps beatmaps;

    private string filePath;
    private bool enteredInput = false;

    void Start()
    {
        inputField = GetComponent<TMP_InputField>();

        filePath = Path.Combine(Application.dataPath, "Leaderboard.txt");
    }

    public void OnTextChanged(string newText)
    {
        Debug.Log("Text changed to: " + newText);
    }

    public void SaveToFile(string text)
    {
        try
        {
            text += "\n-------------------------" + beatmaps.CalculateResults() + "\n\n";
            using (StreamWriter writer = new StreamWriter(filePath, true)) // true = append mode
            {
                writer.WriteLine(text);
            }
            Debug.Log("Text saved to: " + filePath);
            enteredInput = true;
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error appending to file: {e.Message}");
        }
    }

    public void CloseInputPanel()
    {
        inputField.enabled = false;
        inputObject.SetActive(false);
    }
    
    public bool GetEnteredInput()
    {
        return enteredInput;
    }
}
