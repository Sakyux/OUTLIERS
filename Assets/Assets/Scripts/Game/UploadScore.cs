using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class UploadScore : MonoBehaviour
{
    private TMP_InputField inputField;
    public GameObject inputObject;
    public Beatmaps beatmaps;
    public BeatEvent BeatEvent;

    private string filePath;
    private string username;
    private bool enteredInput = false;
    private const int MaxEntries = 10;

    [System.Serializable]
    private class ScoreEntry
    {
        public string Username { get; set; }
        public int Score { get; set; }
        public DateTime Timestamp { get; set; }

        public override string ToString()
        {
            return $"{Username}\t{Score}\t{Timestamp:yyyy/MM/dd hh:mm:ss tt}";
        }
    }

    void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        filePath = Path.Combine(Application.dataPath, "Leaderboard.txt");

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "");
        }
    }

    public void OnTextChanged(string newText)
    {
        Debug.Log("Text changed to: " + newText);
        username = newText;
    }

    public void SaveToFile(string text)
    {
        DateTime dateTime = DateTime.Now;

        try
        {
            List<ScoreEntry> entries = new List<ScoreEntry>();

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('\t');
                    if (parts.Length == 3)
                    {
                        entries.Add(new ScoreEntry
                        {
                            Username = parts[0],
                            Score = int.Parse(parts[1]),
                            Timestamp = DateTime.ParseExact(parts[2], "yyyy/MM/dd hh:mm:ss tt", null)
                        });
                    }
                }
            }

            // Add new entry
            entries.Add(new ScoreEntry
            {
                Username = username,
                Score = (int) BeatEvent.GetTotalScore(),
                Timestamp = DateTime.Now
            });

            // My sorting system via date in descending order
            entries = entries.OrderByDescending(e => e.Timestamp)
                            .Take(MaxEntries)
                            .ToList();

            File.WriteAllLines(filePath, entries.Select(e => e.ToString()));

            enteredInput = true;
            Debug.Log("Score saved to: " + filePath);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error saving score: {e.Message}");
        }
    }

    public void CloseInputPanel()
    {
        inputField.enabled = false;
        inputObject.SetActive(false);
    }
}
