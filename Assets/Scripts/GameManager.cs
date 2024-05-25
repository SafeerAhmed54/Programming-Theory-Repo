using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float Speed { get; set; } = 10.0f; // Shared speed variable, made public for access
    private PlayerScript player;
    public GameObject road;
    public Vector3 initialPos;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        player = FindAnyObjectByType<PlayerScript>();

        road = GameObject.FindGameObjectWithTag("Road");
        
        initialPos = road.transform.position;
    }

    public void AdjustSpeedTemporarily(float factor, float duration)
    {
        StartCoroutine(TemporarySpeedAdjustment(factor, duration));
    }

    private IEnumerator TemporarySpeedAdjustment(float factor, float duration)
    {
        player.boost = true;
        Speed *= factor; // Reduce speed
        yield return new WaitForSeconds(duration); // Wait for the specified duration
        Speed /= factor; // Restore speed to original value
        player.boost = false;
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene(0);
    }


}
