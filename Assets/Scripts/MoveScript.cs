using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private Vector3 initialPos;
    public int speed;
    public float outBoundZ = 4.45f;
    
  
    void Start()
    {
        GameObject road = GameObject.FindGameObjectWithTag("Road");
        initialPos = road.transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        MovePlane();
        MoveObj();
    }

    public void MovePlane()
    {
        //float currentPosZ = gameObject.transform.position.z / 2;

        GameObject road = GameObject.FindGameObjectWithTag("Road");

        if (road.transform.position.z <= -5)
        {
            road.transform.position = initialPos;
        }
        else
        {
            road.transform.position -= new Vector3(0, 0, 1) * speed * Time.deltaTime;
        }
    }
        public void MoveObj()
        {
            // Move and destroy all obstacles
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obsticle");
            foreach (GameObject obstacle in obstacles)
            {
                obstacle.transform.position -= new Vector3(0, 0, 1) * speed * Time.deltaTime;
                if (obstacle.transform.position.z <= -outBoundZ)
                {
                    Destroy(obstacle);
                }
            }

            // Move and destroy all boosts
            GameObject[] boosts = GameObject.FindGameObjectsWithTag("Boost");
            foreach (GameObject boost in boosts)
            {
                boost.transform.position -= new Vector3(0, 0, 1) * speed * Time.deltaTime;
                if (boost.transform.position.z <= -outBoundZ)
                {
                    Destroy(boost);
                }
            }
        }
    
}
