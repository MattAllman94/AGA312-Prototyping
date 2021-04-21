using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleMovement : JMC
{

    public float posLimit;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * _SM3.currentSpeed);

        if (transform.position.z < posLimit)
        {
            Destroy(gameObject);
            _SM3.obstacles.Remove(this);
        }
    }


}
