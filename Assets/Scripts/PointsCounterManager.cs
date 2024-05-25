using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PointsCounterManager : MonoBehaviour
{
    private int point = 0;
    public Text score;
    [SerializeField]
    private List<int> intArray = new List<int> { 0, 100, 200, 300 };

    void Start()
    {
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Points are : " + point);
        if (other.CompareTag("Obsticle"))
        {
            point++;
            score.text = " Score : " + point.ToString();
            Debug.Log("Points are : " + point);
            for (int i = 0; i < intArray.Count; i++)
            {
                if (point == intArray[i])
                {
                    GameManager.Instance.Speed += i * 10;
                }
            }
        }
    }

    public void GameOver()
    {
        string playerName = MenuManager.Instance.nameOfPlayer; // Get the player name from the input field
        HighScoreManager.Instance.CheckForHighScore(playerName, point);
        // Transition to main menu or another scene here
        SceneManager.LoadScene("MainMenu"); // Replace with your main menu scene name
    }
}
