using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : GameEntity
{
    private Rigidbody playerRb;
    public float speed;
    private float outBoundX = 4.5f;
    public bool gameOver = false;
    public bool boost = false;
    private PointsCounterManager point;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        point = FindAnyObjectByType<PointsCounterManager>();
    }

    void Update()
    {
        if (!gameOver)
        {
            Move();
        }
    }

    public override void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector3.right * horizontalInput * speed, ForceMode.Impulse);

        if (transform.position.x <= -outBoundX)
        {
            transform.position = new Vector3(-outBoundX, transform.position.y, transform.position.z);
        }
        if (transform.position.x >= outBoundX)
        {
            transform.position = new Vector3(outBoundX, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obsticle"))
        {
            Debug.Log("Player Hit Obsticle");
            gameOver = true;
            GameManager.Instance.Speed = 0;
            playerRb.velocity = Vector3.zero;  // Stop the player's movement
            point.GameOver();
        }
        else if (other.CompareTag("Boost"))
        {
            if (!boost)
            {
                Debug.Log("Player Achieved Boost");
                GameManager.Instance.AdjustSpeedTemporarily(1 / 3f, 10f); // Reduce speed for 10 seconds
                Destroy(other.gameObject);
            }
            Destroy(other.gameObject);
        }
    }
}
