using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    public float speed = 20;
    public float maxSpeed = 40;
    private float leftBound = -15;
    public float currentTime;
    private PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        currentTime = Time.unscaledDeltaTime;
    }
    void Update()
    {
        if(playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        if(speed < maxSpeed)
        {
            if(currentTime > 60)
            {
                speed += Time.deltaTime;
            }
        }

    }
}
