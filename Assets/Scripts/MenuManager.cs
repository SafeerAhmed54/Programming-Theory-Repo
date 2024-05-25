using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TMP_InputField namePlayer;
    public string nameOfPlayer;

    public static MenuManager Instance;

    public int score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mark this GameObject as persistent
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }


}
