using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private Vector3 initialPos;
    public float outBoundZ = 4.45f;
    private GameObject road;
    private GameManager game;

    private void Awake()
    {
        
    }

    void Start()
    {
        game = FindAnyObjectByType<GameManager>();
        road = GameObject.FindGameObjectWithTag("Road");
        road = game.road;
        initialPos = game.initialPos;

        Debug.Log("Road is : " + road.name);
        Debug.Log("Initial Pos is : " + initialPos);
    }

    void Update()
    {
        if (road != null)
        {
            MovePlane();
            MoveObjects();
        }
    }

    public void MovePlane()
    {
        road = GameObject.FindGameObjectWithTag("Road");
        if (road.transform.position.z >= 125)
        {
            road.transform.position -= new Vector3(0, 0, 1) * GameManager.Instance.Speed * Time.deltaTime;
        }
        else
        {
            road.transform.position = initialPos;
            Debug.Log("Initial Pos is here " + initialPos);
        }
    }

    public void MoveObjects()
    {
        // Move and destroy all obstacles
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obsticle");
        foreach (GameObject obstacle in obstacles)
        {
            obstacle.transform.position -= new Vector3(0, 0, 1) * GameManager.Instance.Speed * Time.deltaTime;
            if (obstacle.transform.position.z <= -outBoundZ)
            {
                Destroy(obstacle);
            }
        }

        // Move and destroy all boosts
        GameObject[] boosts = GameObject.FindGameObjectsWithTag("Boost");
        foreach (GameObject boost in boosts)
        {
            boost.transform.position -= new Vector3(0, 0, 1) * GameManager.Instance.Speed * Time.deltaTime;
            if (boost.transform.position.z <= -outBoundZ)
            {
                Destroy(boost);
            }
        }
    }
}
