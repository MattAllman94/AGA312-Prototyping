using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : JMC
{

    public float speed = 20;
    public float maxSpeed = 40;
    private float leftBound = -15;
 
   

    void Start()
    {

    }
    void Update()
    {


        if(_PC1.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        if(speed < maxSpeed)
        {
            if(_GM1.currentTime > 20)
            {
                speed += Time.deltaTime;
            }
        }

    }
}
