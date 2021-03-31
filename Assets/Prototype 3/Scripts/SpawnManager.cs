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
        public float currentSpawnRate;

        public GameObject[] pickup;
        public float pickupSpawnRate;
        public float currentPickupSpawnRate;

        void Start()
        {

        }

        void Update()
        {
            currentSpawnRate -= Time.deltaTime;
            SpawnObstacle();

            currentPickupSpawnRate -= Time.deltaTime;
            SpawnPickup();
        }

        void SpawnPickup()
        {
            if(currentPickupSpawnRate <= 0)
            {
                int rnd = Random.Range(0, pickup.Length);
                //Vector3 pickupSpawnPos = new Vector3(Random.Range(-12f, 12f), Random.Range(14f, -12f), 0);
                Vector3 pickupSpawnPos = new Vector3(Random.Range(-5f, 5f), Random.Range(4f, -4f), 0);
                Instantiate(pickup[rnd], new Vector3(pickupSpawnPos.x, pickupSpawnPos.y, 30), transform.rotation);
                currentPickupSpawnRate = pickupSpawnRate;
            }
        }

        void SpawnObstacle()
        {
            if (currentNumber <= obstacleLimit)
            {
                if (currentSpawnRate <= 0)
                {
                    Vector3 obstacleSpawnPos = new Vector3(Random.Range(-13f, 13f), Random.Range(14f, -12f), 0);
                    //Vector3 obstacleSpawnPos = new Vector3(Random.Range(-5f, 5f), Random.Range(4f, -4f), 0);
                    Instantiate(obstacle, new Vector3(obstacleSpawnPos.x, obstacleSpawnPos.y, 30), transform.rotation);
                    currentSpawnRate = spawnRate;
                    currentNumber += 1;
                }
            }
        }
    }
}
