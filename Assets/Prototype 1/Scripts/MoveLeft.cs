using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveLeft : JMC
{

    public float speed = 20;
    float currentSpeed;
    public float maxSpeed = 40;
    private float leftBound = -15;


    void Start()
    {

    }
    void Update()
    {
        int rnd = Random.Range(1, 2);
        currentSpeed = speed;

        if(_PC1.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * currentSpeed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        if(currentSpeed < maxSpeed)
        {
            if(_GM1.currentTime > 20)
            {
                speed += Time.deltaTime;
                
            }
        }

    }
}
