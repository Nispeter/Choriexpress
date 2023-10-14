using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PointCounter : MonoBehaviour
{
    public int score = 0;
    private string saveFilePath;
    public void AddScore(int points)
    {
        score += points;
    }
    public void SubScore(int points)
    {
        score -= points;
    }
    public void SaveDailyScore()
    {
        string scoreEntry = $"Day {DayManager.currentDay} : {score} points\n";
        saveFilePath = Path.Combine(Application.persistentDataPath, "dailyScores.txt");
    }
    public Dictionary<int, int> LoadDailyScores()
    {
        Dictionary<int, int> dailyScores = new Dictionary<int, int>();
        if (File.Exists(saveFilePath))
        {
            string[] lines = File.ReadAllLines(saveFilePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(':'); // Split the line at the colon
                if (parts.Length == 2) // Ensure there are two parts
                {
                    int day = int.Parse(parts[0].Replace("Day", "").Trim()); // Parse the day
                    int score = int.Parse(parts[1].Replace("points", "").Trim()); // Parse the score
                    dailyScores[day] = score;
                }
            }
        }
        else
        {
            Debug.LogError("Scores file does not exist!");
        }

        return dailyScores;
    }
}


