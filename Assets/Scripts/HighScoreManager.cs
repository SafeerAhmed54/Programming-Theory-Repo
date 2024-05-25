using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance;

    public List<HighScoreEntry> highScores = new List<HighScoreEntry>();
    private const int maxScores = 10;
    private string filePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            filePath = Path.Combine(Application.persistentDataPath, "highscores.json");
            LoadHighScores();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void LoadHighScores()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            highScores = JsonUtility.FromJson<HighScoreList>(json).highScores;
        }
    }

    private void SaveHighScores()
    {
        HighScoreList highScoreList = new HighScoreList { highScores = highScores };
        string json = JsonUtility.ToJson(highScoreList, true);
        File.WriteAllText(filePath, json);
    }

    public void CheckForHighScore(string playerName, int score)
    {
        for (int i = 0; i < highScores.Count; i++)
        {
            if (score > highScores[i].score)
            {
                highScores.Insert(i, new HighScoreEntry(playerName, score));
                if (highScores.Count > maxScores)
                {
                    highScores.RemoveAt(highScores.Count - 1);
                }
                SaveHighScores();
                return;
            }
        }

        if (highScores.Count < maxScores)
        {
            highScores.Add(new HighScoreEntry(playerName, score));
            SaveHighScores();
        }
    }

    public List<HighScoreEntry> GetHighScores()
    {
        return new List<HighScoreEntry>(highScores);
    }

    [System.Serializable]
    private class HighScoreList
    {
        public List<HighScoreEntry> highScores;
    }
}
