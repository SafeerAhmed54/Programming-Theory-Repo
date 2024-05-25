using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> obj;
    private Vector3 spawnPoint;
    private float outBoundX = 3.8f;
    private float startTime = 1f;
    private float delayTime = 1f;
    private PlayerScript player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<PlayerScript>();

        InvokeRepeating("InitiateObj", delayTime, startTime);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void InitiateObj()
    {
        if (!player.gameOver)
        {
            float randBoundX = Random.RandomRange(-outBoundX, outBoundX);
            spawnPoint = new Vector3(randBoundX, 0.5f, 104.02f);
            int rand = Random.RandomRange(0, 2);
            Instantiate(obj[rand], spawnPoint, obj[rand].transform.rotation);
        }
    }
}
