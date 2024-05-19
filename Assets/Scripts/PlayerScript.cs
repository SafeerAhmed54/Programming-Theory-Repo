using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed;
    private float outBoundX = 4.5f;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }
    public void PlayerMove()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector3.right * horizontalInput * speed, ForceMode.Impulse);

        if(gameObject.transform.position.x <= -outBoundX)
        {
            gameObject.transform.position = new Vector3(-outBoundX, 1, 0);
        }
        if (gameObject.transform.position.x >= outBoundX)
        {
            gameObject.transform.position = new Vector3(outBoundX, 1, 0);
        }

    }
}
