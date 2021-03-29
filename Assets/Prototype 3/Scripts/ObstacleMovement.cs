using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : JMC
{
    public float speed;
    public float posLimit;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);

        if (transform.position.z < posLimit)
        {
            Destroy(gameObject);
            _SM3.currentNumber -= 1;
        }
    }
}
