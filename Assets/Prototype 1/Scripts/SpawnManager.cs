using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : JMC
{

    public GameObject[] obstacle;

    //private Vector3 spawnPos = new Vector3(25, 0, 0);
    public Transform spawnPos;
    private float startDelay = 2;
    public float[] repeatRate;


    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate[Random.Range(0, repeatRate.Length)]); // Trying to get the obstacles randomly spawning at different times

    }

    void SpawnObstacle()
    {
        if (_PC1.gameOver == false)
        {
            Instantiate(obstacle[Random.Range(0, obstacle.Length)], spawnPos.position, spawnPos.rotation);
            print(repeatRate[repeatRate.Length - 1]);
        }
    }
}
