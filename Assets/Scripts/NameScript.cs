using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NameScript : MonoBehaviour
{
    public TMP_InputField namePlayer;
    public TextMeshProUGUI highScore;
    private MenuManager manager;

    private void Start()
    {
        manager = FindAnyObjectByType<MenuManager>();
        manager.namePlayer = namePlayer;
        if(MenuManager.Instance.nameOfPlayer != "")
        {
            highScore.text = "Score of " + MenuManager.Instance.nameOfPlayer + " : " + MenuManager.Instance.score.ToString();
        }
        else if (MenuManager.Instance.nameOfPlayer == "")
        {
            highScore.text = "Score of Name : 0 ";
        }
    }

    public void SetName()
    {
        MenuManager.Instance.nameOfPlayer = namePlayer.text;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        // Check if the application is running in the Unity Editor
#if UNITY_EDITOR
        // Exit play mode in the editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Quit the application
        Application.Quit();
#endif
    }
}
