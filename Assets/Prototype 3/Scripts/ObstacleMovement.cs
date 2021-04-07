using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleMovement : Singleton<ObstacleMovement>
{
    public float currentSpeed;
    public float speed;
    public float posLimit;
    public Ease ease;


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

    public void SpeedUp()
    {
        DOTween.To(() => speed, x => speed = x, 40, 3).SetEase(ease).OnUpdate(UpdateSpeed);

    }

    void UpdateSpeed()
    {
        currentSpeed = speed;
    }
}
