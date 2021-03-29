using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype3
{
    public class SpawnManager : Singleton<SpawnManager>
    {

        public GameObject obstacle;
        private int obstacleLimit = 50;
        public int currentNumber = 0;
        public float spawnRate;
        private float currentSpawnRate;

        void Start()
        {

        }

        void Update()
        {
            currentSpawnRate -= Time.deltaTime;
            SpawnObstacle();
        }

        void SpawnPickup()
        {

        }

        void SpawnObstacle()
        {
            if (currentNumber <= obstacleLimit)
            {
                if (currentSpawnRate <= 0)
                {
                    Vector3 obstacleSpawnPos = new Vector3(Random.Range(-13f, 13f), Random.Range(14f, -12f), 0);
                    Instantiate(obstacle, new Vector3(obstacleSpawnPos.x, obstacleSpawnPos.y, 30), transform.rotation);
                    currentSpawnRate = spawnRate;
                    currentNumber += 1;
                }
            }
        }
    }
}
