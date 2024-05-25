using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class MainMenuScript : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        DisplayHighScores();
    }

    private void DisplayHighScores()
    {
        List<HighScoreEntry> highScores = HighScoreManager.Instance.GetHighScores();
        highScoreText.text = "High Scores:\n";
        foreach (var entry in highScores)
        {
            highScoreText.text += $"{entry.playerName}: {entry.score}\n";
        }
    }
}
