using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : JMC
{

    public GameObject[] obstacle;
    public GameObject fallingObstacles;

    //private Vector3 spawnPos = new Vector3(25, 0, 0);
    public Transform[] spawnPos;
    private float startDelay = 2;
    public float repeatRate;



    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);

    }

    void SpawnObstacle()
    {



        if (_PC1.gameOver == false && _GM1.currentTime <= 20)
        {
            Instantiate(obstacle[Random.Range(0, obstacle.Length)], spawnPos[1].position, spawnPos[1].rotation);
        }
        else if (_PC1.gameOver == false && _GM1.currentTime > 20)
        {
            int rnd = Random.Range(1, 3);

            if (rnd == 1)
            {
                Instantiate(obstacle[Random.Range(0, obstacle.Length)], spawnPos[1].position, spawnPos[1].rotation);
            }

            if(rnd == 2)
            {
                Instantiate(fallingObstacles, spawnPos[0].position, spawnPos[0].rotation);
            }


            print(rnd);
        }

    }
}
